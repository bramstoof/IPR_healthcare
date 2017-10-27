using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UserData;
using System.Threading;
using Remote_Healtcare_Console.Forms;

namespace Remote_Healtcare_Console
{
    partial class Console : Form
    {
        private Kettler bike;
        private ComboBox combo;
        public string path;
        public ISet<BikeData> data;
        private Client client;
        int timeLeft;

        public Console(Client client)
        {
            InitializeComponent();
            this.Text = "Console";
            this.client = client;
            combo = comPorts;
            combo.Items.Clear();
            combo.Items.Add("Simulator");
            combo.Items.AddRange(SerialPort.GetPortNames());
        }

        private void BStart_Click(object sender, EventArgs e)
        {
            maskedTextBox_gewicht.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            if (checkedListBox_geslacht.CheckedItems.Count == 1)
            {
                combo.Focus();
                if (combo.SelectedItem == null)
                {
                    string message = "Kies een simulator of COM poort";
                    string caption = "Error Detected in Input";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBoxIcon icon = MessageBoxIcon.Error;
                    MessageBox.Show(message, caption, buttons, icon);
                }
                else if (combo.SelectedItem.Equals("Simulator"))
                {

                    OpenFileDialog browseFileDialog = new OpenFileDialog();
                    browseFileDialog.Filter = "JSON (.json)|*.json;";
                    browseFileDialog.InitialDirectory = Directory.GetCurrentDirectory();

                    if (browseFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        path = Path.GetFullPath(browseFileDialog.FileName);
                        string json = File.ReadAllText(path);
                        JArray openedData = (JArray)JsonConvert.DeserializeObject(json);

                        data = (ISet<BikeData>)openedData.ToObject(typeof(ISet<BikeData>));
                    }

                    bike = new BikeSimulator(this);
                    bike.Start();
                    Hide();
                }
                else
                {
                    //new Thread(() => test()).Start();
                    bike = new Bike(combo.SelectedItem.ToString(), new User("bram", "bram", "bram", true, "1997-9-25"), this, ref client);
                    bike.Start();
                    Hide();
                }
                
            }
            else if (checkedListBox_geslacht.CheckedItems.Count != 1)
            {

                MessageBox.Show("Kies 1 geslacht", "Er ging iets mis", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
                MessageBox.Show("Kies uw leeftijd, Geslacht en gewicht.", "Er ging iets mis", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        
        protected override void OnFormClosed(FormClosedEventArgs e) {
            Environment.Exit(0);
            base.OnFormClosed(e);
        }

        public void AddMessage(String value)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(AddMessage), new object[] { value });
                return;
            }
            Chat_Box.Text = Chat_Box.Text + value + "\r\n";
        }

        private void Closing(object sender, FormClosingEventArgs e)
        {
            client.SendMessage("bye");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < checkedListBox_geslacht.Items.Count; ++ix)
                if (ix != e.Index) checkedListBox_geslacht.SetItemChecked(ix, false);
        }
    }
}
