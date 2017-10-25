using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UserData;

namespace Remote_Healtcare_Console
{
    class Bike : Kettler {
        private bool start;
        private SerialCommunicator serialCommunicator;
        private Client client;
        private Thread BikeThread;
        private Thread ChangesThread;
        private string hashcode;
        private bool autoCalculateResistance;
        private bool autoCalculateResistanceNotExactly;
        private List<int> heartrates;
        private User user;
        private double factor;
        private int hartfrequentie;
        private int Resistance = 25;
        private bool startTest = false;
        private bool Busy;

        public Bike(string port, Console console, User user, ref Client client) : base(console) {
            this.client = client;
            this.user = user;
            start = false;
            heartrates = new List<int>();
            serialCommunicator = new SerialCommunicator(port);
            BikeThread = new Thread(InitBike);
            ChangesThread = new Thread(changes);
            CorrectieFactorHartfrequentie();
        }

        private void changes()
        {
            while (serialCommunicator.IsConnected() && start)
            {
                SetChanges();
                Thread.Sleep(500);
            }
        }

        private void SetChanges()
        {
            JObject obj = client.ReadMessage();

            switch ((string)obj["id"])
            {
                case ("setResistance"):
                    int resistance = (int)obj["data"]["resistance"];
                    SetResistance(resistance);
                    break;
                case ("chat"):
                    string message = (string)obj["data"]["message"];
                    new Thread(() => console.AddMessage(message)).Start();
                    break;
                case "setdoctor":
                    client.SendMessage(obj);
                    break;
                case ("start"):
                    BikeThread.Start();
                    break;
                case ("stop"):
                    BikeThread.Abort();
                    break;
            }

        }

        public override void Start() {
            start = true;
            serialCommunicator.OpenConnection();
            ChangesThread.Start();
        }

        private void AstradHandler()
        {
            if (Busy)
            {
                BikeData latestData = RecordedData.Last();
                int minutes = latestData.Time.Minutes;
                if(latestData.Pulse > hartfrequentie)
                    SetResistance(Resistance -= 15);
                if (minutes < 2)
                {
                    if (Resistance == 60)
                        RpmCheck(latestData.Rpm);
                    else
                    {
                        Resistance = 60;
                        SetResistance(Resistance);
                    }

                }
                else if (minutes < 6)
                {
                    if (latestData.Pulse > hartfrequentie)
                        Busy = false;
                    int seconds = latestData.Time.Seconds;
                    if (minutes < 4)
                    {
                        if (seconds % 10 == 0 && latestData.Pulse > 130 && Resistance < 180)
                            SetResistance(Resistance += 15);
                    }
                    else
                    {
                        if (seconds % 15 == 0)
                        {
                            heartrates.Add(latestData.Pulse);
                        }
                    }
                    RpmCheck(latestData.Rpm);
                }
                else if (minutes < 7)
                {
                    AverageHeartBeatRate();
                    CalculateVO2MAX();
                    SetResistance(25);
                    // cool down
                    Busy = false;
                }
                else
                {
                    //klaar
                    Busy = false;
                }
            }
        }

        private void RpmCheck(int rpm) {
            if (rpm <= 50)
            {
                //go faster
            }
            else if (rpm >= 60)
            {
                //go slower
            }
            else
            {
                //ga zo door
            }
        }
        public override void Stop() {
            start = false;
            serialCommunicator.CloseConnection();
        }

        private void InitBike() {
            Thread.Sleep(500);
            Reset();
            Thread.Sleep(500);
            SetManual();
            Thread.Sleep(500);
            Run();
        }

        private void Run() {
            while (serialCommunicator.IsConnected() && start) {
                Update();
                //SetResistance((int)console.connectForm.connector.CalculateIncline("bike"));
                Thread.Sleep(500);
            }
        }

        public override void Reset() {
            serialCommunicator.SendMessage("RS");
            RecordedData.Clear();
        }

        public override void SetManual() {
            serialCommunicator.SendMessage("CM");
            if (serialCommunicator.ReadInput() != "RUN") {
                Thread.Sleep(500);
                serialCommunicator.ReadInput();
            }
        }

        public override void SetResistance(int resistance) {
            int trueResistance;
            if (resistance > 400) {
                trueResistance = 400;
            }
            else if (resistance < 25) {
                trueResistance = 25;
            }
            else {
                trueResistance = resistance;
            }
            serialCommunicator.SendMessage("PW " + trueResistance);
        }

        public override void SetTime(int mm, int ss) {
            string time = (mm.ToString() + ss.ToString());
            serialCommunicator.SendMessage("PT " + time);
            serialCommunicator.ReadInput();
        }

        public override void SetDistance(int distance) {
            int trueDistance;
            if (distance > 999) {
                trueDistance = 999;
            }
            else if (distance < 0) {
                trueDistance = 0;
            }
            else {
                trueDistance = distance;
            }
            serialCommunicator.SendMessage("PD " + trueDistance);
            serialCommunicator.ReadInput();
        }

        public override void Update() {
            serialCommunicator.SendMessage("ST");
            string data = serialCommunicator.ReadInput();
            data = data.Replace("\r", "");
            string[] dataSplitted = data.Split('\t');

            BikeData bikeData = new BikeData(
                int.Parse(dataSplitted[0]), int.Parse(dataSplitted[1]),
                dataSplitted[2],
                int.Parse(dataSplitted[3]), int.Parse(dataSplitted[4]), int.Parse(dataSplitted[5]),
                dataSplitted[6],
                int.Parse(dataSplitted[7]));

            if (RecordedData.Count == 0) {
                RecordedData.Add(bikeData);
            }
            else if (RecordedData.Last().Time != bikeData.Time) {
                RecordedData.Add(bikeData);
            }
            if (startTest)
                AstradHandler();
            
            client.SendMessage(new
            {
                id = "update",
                data = new
                {
                    bikeData = bikeData
                }
            });

            SetDataToGUI();
        }

        public void AvansAstrand()
        {
            
        }

        public int AverageHeartBeatRate()
        {
            return (int)heartrates.Average();
        }

        public void CalculateVO2MAX()
        {
            double VO2MAX = 0;
            if(user.isMan)
            {
                VO2MAX = (174.2 * Resistance + 4020) / (103.2 * AverageHeartBeatRate() - 6299);
                VO2MAX *= factor;
            }
            else
            {
                VO2MAX = (163.8 * Resistance + 3780) / (104.4 * AverageHeartBeatRate() - 7514);
                VO2MAX *= factor;
            }
        }

        public double CorrectieFactorLeeftijd(int leeftijd)
        {
            double factor;

            if (leeftijd <= 15)
                factor = 1.10;
            else if (leeftijd <= 25)
                factor = 1;
            else if (leeftijd <= 35)
                factor = 0.87;
            else if (leeftijd <= 40)
                factor = 0.83;
            else if (leeftijd <= 45)
                factor = 0.87;
            else if (leeftijd <= 50)
                factor = 0.75;
            else if (leeftijd <= 55)
                factor = 0.71;
            else if (leeftijd <= 60)
                factor = 0.68;
            else if (leeftijd <= 65)
                factor = 0.65;
            else
                factor = 0.65;

            return factor;
        }

        public double CorrectieFactorHartfrequentie()
        {
            double factor;

            if (hartfrequentie >= 210)
                factor = 1.12;
            else if (hartfrequentie >= 200)
                factor = 1;
            else if (hartfrequentie >= 190)
                factor = 0.93;
            else if (hartfrequentie >= 180)
                factor = 0.83;
            else if (hartfrequentie >= 170)
                factor = 0.75;
            else if (hartfrequentie >= 160)
                factor = 0.69;
            else if (hartfrequentie >= 150)
                factor = 0.64;
            else
                factor = 0.64;

            return factor;
        }
    }
}
