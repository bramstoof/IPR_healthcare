﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace UserData
{
    public enum UserType { Client, Doctor, None }
    public class User
    {
        private string username;
        private string password;
        private string hashcode;
        public string FullName { get; set; }
        public DateTime BirthDay;
        public bool Man;
        public int gewicht;
        public UserType Type { get; set; }

        [Newtonsoft.Json.JsonConstructor]
        public User(string username, string password, string fullName, string hashcode, string BirthDay, bool man, int gewicht, UserType type)
        {
            this.username = username;
            this.password = password;
            this.FullName = fullName;
            this.hashcode = hashcode;
            this.Man = man;
            this.gewicht = gewicht;
            //this.BirthDay = DateTime.Parse(BirthDay);
            this.Type = type;
        }

        public User(string username, string password, string fullName, string date, bool man, int gewicht)
        {
            this.username = username;
            this.password = password;
            this.FullName = fullName;
            this.BirthDay = DateTime.Parse(date);
            this.Man = man;
            this.gewicht = gewicht;
            this.Type = UserType.Client;
            makeHashcodeValid(Encoding.Default.GetString(new SHA256Managed().ComputeHash(Encoding.Default.GetBytes(DateTime.UtcNow.Ticks.ToString() + username))));
        }

        public User(string username, string password, string fullName, string date, bool man, int gewicht, UserType type)
        {
            this.username = username;
            this.password = password;
            this.FullName = fullName;
            this.BirthDay = DateTime.Parse(date);
            this.Type = type;
            this.Man = man;
            this.gewicht = gewicht;
            string test = Encoding.Default.GetString(new SHA256Managed().ComputeHash(Encoding.Default.GetBytes(DateTime.UtcNow.Ticks.ToString() + username)));
            makeHashcodeValid(test);
        }

        public int getAge()
        {
            DateTime timeNow = new DateTime();
            int age = (int)timeNow.Year - ((int)BirthDay.Year - 1);
            

            if((BirthDay.Month >= timeNow.Month) && (BirthDay.Day >= timeNow.Day))
               age++;


            return age;
        }

        public string Password
        {
            get { return password; }
        }

        public string Username
        {
            get { return username; }
        }

        public string Hashcode
        {
            get { return hashcode; }
        }

        public void SetUsername(string newUsername)
        {
            username = newUsername;
        }

        public void SetPassword(string newPassword)
        {
            password = newPassword;
        }

        public void CheckLogin(string username, string password, out bool valid, out string hashcode)
        {
            if (this.username == username && this.password == password)
            {
                valid = true;
                hashcode = this.hashcode;
            }
            else
            {
                valid = false;
                hashcode = null;
            }
        }

        private void makeHashcodeValid(string hash)
        {
            List<char> forbiddenChars = new List<char>(Path.GetInvalidPathChars());
            forbiddenChars.Add((char)92);
            forbiddenChars.Add((char)47);
            forbiddenChars.Add((char)63);
            forbiddenChars.Add((char)42);
            forbiddenChars.Add((char)58);
            string validHashcode = string.Empty;
            foreach (char c in hash)
            {
                if (forbiddenChars.Contains(c))
                {
                    validHashcode += "{";
                }
                else
                {
                    validHashcode += c;
                }
            }
            hashcode = validHashcode;
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\data\" + validHashcode);
        }
    }
}

