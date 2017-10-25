﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Remote_Healtcare_Console.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserData;

namespace Remote_Healtcare_Console
{
    public partial class Login : Form
    {
        Client client;

        public Login()
        {
            InitializeComponent();
            this.Text = "Inloggen GUI";
        }

        private void BLog_in_Click(object sender, EventArgs e)
        {
            client = new Client();
            login();
        }

        private void KeyPressed(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
                BLog_in_Click(null, null);
        }

        private void login() {
            if (txtUsername.Text.Length > 0 && txtPassword.Text.Length > 0) {
                dynamic user = new
                {
                    username = Encoding.Default.GetString(new SHA256Managed().ComputeHash(Encoding.Default.GetBytes(txtUsername.Text))),
                    password = Encoding.Default.GetString(new SHA256Managed().ComputeHash(Encoding.Default.GetBytes(txtPassword.Text)))
                };
                client.SendMessage(user);

                JObject jObject = client.ReadMessage();
                string result = (string)jObject.GetValue("access");
                if (result.Equals("True")) {
                    this.Hide();
                    Form Form1 = new Console(client);
                    Form1.Closed += (s, args) => this.Close();
                    Form1.Show();
                }
                else
                {
                    MessageBox.Show("Ingevulde gegevens zijn onjuist", "Error Tijdens het inloggen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vul de velden in", "Error Tijdens het inloggen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
