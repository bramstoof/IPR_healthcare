﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserData;

namespace Server {
    class Client {
        private TcpClient client;
        private NetworkStream stream;
        public Thread LoginThread { get; }

        private object sessionLock, connectedClientsLock, connectedDoctorsLock, usersLock;

        private List<Client> connectedClients, connectedDoctors;
        private List<User> users;
        public BikeSession session { get; set; }
        public User User { get; set; }
        public Client patient;
        public Client doctor;

        public Client(TcpClient client, ref List<User> users, ref List<Client> connectedClients, ref List<Client> connectedDoctors, ref object usersLock, ref object connectedClientsLock, ref object connectedDoctorsLock) {
            this.client = client;
            this.connectedClients = connectedClients;
            this.connectedDoctors = connectedDoctors;
            this.users = users;

            sessionLock = new object();
            this.usersLock = usersLock;
            this.connectedClientsLock = connectedClientsLock;
            this.connectedDoctorsLock = connectedDoctorsLock;

            stream = this.client.GetStream();
            LoginThread = new Thread(() => init(this.users));
            LoginThread.Start();
        }

        private void init(List<User> users) {
            string hash, username, password;
            bool valid, found;
            JObject userReceived = readFromStream();
            found = false;
            username = (string)userReceived["username"];
            password = (string)userReceived["password"];

            lock (usersLock) {
                foreach (User user in users) {
                    user.CheckLogin(username, password, out valid, out hash);
                    if (valid) {
                        this.User = user;
                        dynamic response = new {
                            access = true,
                            user = user
                        };
                        writeMessage(response);
                        found = true;
                        new Thread(() => run()).Start();
                        break;
                    }
                }
            }

            if (!found) {
                dynamic response = new {
                    access = false
                };
                writeMessage(response);
                closeStream();
                return;
            }
        }

        private void run() {
            while (client.Connected) {
                JObject message = readFromStream();
                if (message != null) {
                    processIncomingMessage(message);
                }
            }
            if (User.Type == UserType.Doctor) {
                lock (connectedDoctorsLock) {
                    connectedDoctors.Remove(this);
                }
            }
            else {
                lock (connectedClientsLock) {
                    connectedClients.Remove(this);
                }
            }

            if (session != null) {
                session = null;
            }
            closeStream();
            Console.WriteLine(connectedClients.Count + "\t" + connectedDoctors.Count);
        }

        private void processIncomingMessage(JObject obj) {
            switch ((string)obj["id"]) {
                case "update":
                    update((JObject)obj["data"]);
                    break;
                case "reqSession":
                    new Thread(() => sendSessionData((JObject)obj["data"])).Start();
                    break;
                case "latestData":
                    new Thread(() => sendLatestData((JObject)obj["data"])).Start();
                    break;
                case "oldsession":
                    new Thread(() => sendOldSession((JObject)obj["data"])).Start();
                    break;
                case "oldsessionlist":
                    new Thread(() => getOldSessionsName((JObject)obj["data"])).Start();
                    break;
                case "getPatients":
                    new Thread(() => getAllClients()).Start();
                    break;
                case "getconPatients":
                    new Thread(() => getConClients()).Start();
                    break;
                case "startrecording":
                    new Thread(() => StartRecording((JObject)obj["data"])).Start();
                    break;
                case "stoprecording":
                    new Thread(() => StopRecording((JObject)obj["data"])).Start();
                    break;
                case "sendmessagetoperson":
                    new Thread(() => sendPM((JObject)obj["data"])).Start();
                    break;
                case "sendbroadcast":
                    new Thread(() => sendBroadcastMessage((JObject)obj["data"])).Start();
                    break;
                case "add":
                    new Thread(() => addUser((JObject)obj["data"])).Start();
                    break;
                case "delete":
                    new Thread(() => deleteUser((JObject)obj["data"])).Start();
                    break;
                case "changepass":
                    new Thread(() => changePassword((JObject)obj["data"]));
                    break;
                case "changeuser":
                    new Thread(() => changeUsername((JObject)obj["data"])).Start();
                    break;
                case "startTest":
                    new Thread(() => sendPM((JObject)obj["data"])).Start();
                    break;
                case "power":
                    new Thread(() => setPower((JObject)obj["data"])).Start();
                    break;
                case "manual":
                    new Thread(() => setManual((JObject)obj["data"])).Start();
                    break;
                case "disconnect":
                    closeStream();
                    break;
                    
            }
        }

        //private void sendChanges(JObject data) {
        //    foreach (Client client in connectedClients) {
        //        if (client.User.Hashcode == (string)data["hashcode"]) {
        //            lock (sessionLock) {
        //                client.writeMessage(data["data"]);
        //            }
        //            break;
        //        }
        //    }
        //}
        private void startTest()
        {
            foreach (Client user in connectedClients)
            {
                new Thread(() => user.writeMessage("startAstrand")).Start();
            }
        }

        private void sendLatestData(JObject data) {
            lock (connectedClientsLock) {
                foreach (Client client in connectedClients) {
                    if (client.User.Hashcode == (string)data["hashcode"]) {
                        lock (client.sessionLock) {
                            if (client.session != null) {
                                if (client.session.Data.Count > 0)
                                {
                                    List<BikeData> temp = client.session.LatestData;
                                    writeMessage(new
                                    {
                                        id = "latestdata",
                                        data = JsonConvert.SerializeObject(temp)
                                    });
                                }
                                else
                                {
                                    List<BikeData> temp = new List<BikeData>();
                                    temp.Add(new BikeData());
                                    writeMessage(new
                                    {
                                        id = "latestdata",
                                        data = JsonConvert.SerializeObject(temp)
                                    });
                                }
                            }
                        }
                        break;
                    }
                }
            }
        }

        private void sendSessionData(JObject data) {
            lock (connectedClientsLock) {
                foreach (Client client in connectedClients) {
                    if (client.User.Hashcode == (string)data["hashcode"]) {
                        lock (client.sessionLock) {
                            if (client.session != null) {
                                writeMessage(new {
                                    id = "latestdata",
                                    data = JsonConvert.SerializeObject(session.Data)
                                });
                            }
                            break;
                        }
                    }
                }
            }
        }

        private void getOldSessionsName(JObject data) {
            string path = Directory.GetCurrentDirectory() + $@"\data\{data["hashcode"]}";

            if (Directory.Exists(path)) {
                dynamic response = new {
                    status = "alloldfiles",
                    data = Directory.GetFiles(path)
                };
                writeMessage(response);
            }
            else {
                dynamic response = new {
                    status = "not found"
                };
                writeMessage(response);
            }
        }

        private void sendOldSession(JObject data) {
            string hashcode = (string)data["hashcode"];
            string file = (string)data["file"];

            string path = Directory.GetCurrentDirectory() + $@"\data\{hashcode}\{file}";
            if (File.Exists(path)) {
                try {
                    dynamic response = new {
                        status = "oldsession",
                        data = File.ReadAllText(path)
                    };
                    writeMessage(response);
                }
                catch (Exception e) {
                    Console.WriteLine(e.Source);
                }
            }
            else {
                dynamic response = new {
                    status = "not found"
                };
                writeMessage(response);
            }
        }

        private void sendBroadcastMessage(JObject data) {
            string messageFromDoc = (string)data["message"];
            dynamic message = new {
                id = "message",
                data = new {
                    message = messageFromDoc
                }
            };

            lock (connectedDoctorsLock) {
                foreach (Client user in connectedClients) {
                    new Thread(() => user.writeMessage(message)).Start();
                }
            }
        }

        private void sendPM(JObject data) {
            string messageFromDoc = (string)data["message"];
            string hashcode = (string)data["hashcode"];

            lock (connectedClientsLock) {
                foreach (Client client in connectedClients) {
                    if (client.User.Hashcode == hashcode) {
                        writeMessage(messageFromDoc);
                    }
                }
            }
        }

        private void getAllClients() {
            lock (usersLock) {
                new Thread(() => writeMessage(users)).Start();
            }
        }

        private void getConClients() {
            lock (connectedClientsLock) {
                new Thread(() => writeMessage(connectedClients)).Start();
            }
        }

        private void setManual(JObject jObject) {
            //send set manual power
        }

        private void setPower(JObject obj) {
            if (User.Type == UserType.Doctor) {
                Client Tempuser = null;
                string hashcode = (string)obj["hashcode"];
                int power = (int)obj["power"];

                lock (connectedClientsLock) {
                    foreach (Client user in connectedClients) {
                        if (user.User.Hashcode == hashcode) {
                            Tempuser = user;
                            break;
                        }
                    }
                }

                if (Tempuser != null) {
                    dynamic setPower = new {
                        id = "power",
                        data = new {
                            power = power
                        }
                    };
                    dynamic ok = new {
                        status = "ok"
                    };
                    Tempuser.writeMessage(setPower);
                    writeMessage(ok);
                }
                else {
                    dynamic failed = new {
                        status = "User not found"
                    };
                    writeMessage(failed);
                }
            }
            else {
                dynamic failed = new {
                    status = "no permission"
                };
                writeMessage(failed);
            }
        }

        public void StartRecording(JObject data) {
            if (User.Type == UserType.Doctor) {
                foreach (Client client in connectedClients) {
                    if (client.User.Hashcode == (string)data["hashcode"]) {
                        lock (sessionLock) {
                            if (client.session == null) {
                                client.session = new BikeSession(client.User.Hashcode);
                            }
                            client.writeMessage(new {
                                id = "start"
                            });
                        }
                        break;
                    }
                }
            }
        }

        public void StopRecording(JObject data) {
            if (User.Type == UserType.Doctor) {
                foreach (Client client in connectedClients) {
                    if (client.User.Hashcode == (string)data["hashcode"]) {
                        lock (sessionLock) {
                            client.writeMessage(new {
                                id = "stop"
                            });
                            client.session.SaveSessionToFile();
                            client.session = null;
                        }
                        break;
                    }
                }
            }
        }

        private void update(JObject data) {
            if (User.Type == UserType.Client) {
                lock (sessionLock) {
                    if (session != null) {
                        BikeData dataConverted = data["bikeData"].ToObject<BikeData>();
                        session.Data.Add(dataConverted);
                        if (session.LatestData.Count < 5) {
                            session.LatestData.Add(dataConverted);
                        }
                        else {
                            session.LatestData.RemoveAt(0);
                            session.LatestData.Add(dataConverted);
                        }
                    }
                }
            }
        }

        private void addUser(JObject data) {
            if (User.Type == UserType.Doctor) {
                string username = (string)data["username"];
                string password = (string)data["password"];
                string fullName = (string)data["fullname"];
                int clientType = (int)data["type"];
                bool isman = (bool)data["man"];
                DateTime fixedBirthday = new DateTime(1997, 9, 25);
                User tempUser = new User(username, password, fullName,  fixedBirthday.ToString() ,isman, 100, (UserType)clientType );

                bool exists = false;
                lock (usersLock) {
                    foreach (User user in users) {
                        if (user == User) {
                            continue;
                        }
                        else {
                            if (user.Username == tempUser.Username) {
                                exists = true;
                                break;
                            }
                        }
                    }
                }

                if (!exists) {
                    users.Add(new User(username, password, fullName,  fixedBirthday.ToString(), isman, 100, (UserType)clientType));
                    dynamic response = new {
                        status = "ok"
                    };
                    writeMessage(response);
                }
                else {
                    dynamic response = new {
                        status = "User already exist"
                    };
                    writeMessage(response);
                }
            }
            else {
                dynamic response = new {
                    status = "no permission"
                };
                writeMessage(response);
            }
        }

        private void deleteUser(JObject data) {
            if (User.Type == UserType.Doctor) {
                string hashcode = (string)data["hashcode"];
                bool deleted = false;

                lock (usersLock) {
                    foreach (User user in users) {
                        if (user.Hashcode == hashcode) {
                            users.Remove(user);
                            deleted = true;
                            break;
                        }
                    }
                }

                if (!deleted) {
                    dynamic response = new {
                        status = "not found"
                    };
                    writeMessage(response);
                }
                else {
                    dynamic response = new {
                        status = "ok"
                    };
                    writeMessage(response);
                }

            }
            else {
                dynamic response = new {
                    status = "no permission"
                };
                writeMessage(response);
            }
        }

        private void changePassword(JObject data) {
            string hashcode = (string)data["hashcode"];
            string newPassword = (string)data["password"];
            bool found = false;
            lock (usersLock) {
                foreach (User u in users) {
                    if (u.Hashcode == hashcode) {
                        u.SetPassword(newPassword);
                        found = true;
                        break;
                    }
                }
            }
            dynamic response;
            if (found) {
                response = new {
                    status = "ok"
                };
            }
            else {
                response = new {
                    status = "not found"
                };
            }
            writeMessage(response);
        }


        private void changeUsername(JObject data) {
            string newUsername = (string)data["username"];
            string hashcode = (string)data["hashcode"];

            Boolean inUse = false;
            lock (usersLock) {
                foreach (User u in users) {
                    if (u.Username == newUsername) {
                        inUse = true;
                    }
                }
            }

            if (!inUse) {
                bool found = false;
                lock (usersLock) {
                    foreach (User u in users) {
                        if (u.Hashcode == hashcode) {
                            u.SetUsername(newUsername);
                            found = true;
                            break;
                        }
                    }
                }
                dynamic response;
                if (found) {
                    response = new {
                        status = "ok"
                    };
                }
                else {
                    response = new {
                        status = "not found"
                    };
                }
                writeMessage(response);
            }
            else {
                dynamic respsone = new {
                    status = "already in use"
                };
                writeMessage(respsone);
            }
        }

        private JObject readFromStream() {
            int numberOfBytesRead = 0;
            byte[] messageBytes = new byte[4];
            byte[] receiveBuffer;

            while (numberOfBytesRead < messageBytes.Length && client.Connected) {
                try {
                    numberOfBytesRead += stream.Read(messageBytes, numberOfBytesRead, messageBytes.Length - numberOfBytesRead);
                }
                catch (IOException e) {
                    Console.WriteLine(e.StackTrace);
                    Console.WriteLine($"Verbinding verloren met patiënt {patient}");
                    return null;
                }
            }

            numberOfBytesRead = 0;
            try {
                receiveBuffer = new byte[BitConverter.ToInt32(messageBytes, 0)];
            }
            catch (ArgumentException e) {
                Console.WriteLine(e.StackTrace);
                return null;
            }

            while (numberOfBytesRead < receiveBuffer.Length && client.Connected) {
                try {
                    numberOfBytesRead += stream.Read(receiveBuffer, numberOfBytesRead, receiveBuffer.Length - numberOfBytesRead);
                }
                catch (IOException e) {
                    Console.WriteLine(e.StackTrace);
                    return null;
                }
            }

            try {
                return JObject.Parse(Encoding.Default.GetString(receiveBuffer));
            }
            catch (Exception) {
                return null;
            }
        }

        public void writeMessage(dynamic message) {
            string json;
            try {
                json = JsonConvert.SerializeObject(message);
            }
            catch (IOException e) {
                Console.WriteLine(e.StackTrace);
                return;
            }

            byte[] prefixArray = BitConverter.GetBytes(json.Length);
            byte[] requestArray = Encoding.Default.GetBytes(json);

            byte[] buffer = new Byte[prefixArray.Length + json.Length];
            prefixArray.CopyTo(buffer, 0);
            requestArray.CopyTo(buffer, prefixArray.Length);
            try {
                stream.Write(buffer, 0, buffer.Length);
            }
            catch (IOException e) {
                Console.WriteLine(e.StackTrace);
            }
        }

        private void closeStream() {
            stream.Close();
            client.Close();
            stream.Dispose();
            client.Dispose();
        }

        //public void SetPatient(User user) {
        //    foreach (Client patientClient in connectedClients) {
        //        string patientString = Encoding.Default.GetString(new SHA256Managed().ComputeHash(Encoding.Default.GetBytes(patientClient.User.Hashcode)));
        //        string userString = Encoding.Default.GetString(new SHA256Managed().ComputeHash(Encoding.Default.GetBytes(user.Hashcode)));

        //        if (patientString.Equals(userString))
        //            patient = patientClient;
        //    }
        //}

        //private void SetDoctor(string hashcode) {
        //    foreach (Client doctorClient in connectedDoctors) {
        //        string doctorString = Encoding.Default.GetString(new SHA256Managed().ComputeHash(Encoding.Default.GetBytes(doctorClient.User.Hashcode)));
        //        string userString = Encoding.Default.GetString(new SHA256Managed().ComputeHash(Encoding.Default.GetBytes(hashcode)));

        //        if (doctorString.Equals(userString))
        //            doctor = doctorClient;
        //    }
        //}
    }
}