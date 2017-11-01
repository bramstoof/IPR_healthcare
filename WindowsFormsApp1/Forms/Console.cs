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
        bool isMannelijk;
        DateTime geboorteDatum;

        public Console(Client client)
        {
            InitializeComponent();
            this.Text = "Console";
            this.client = client;
            combo = comPorts;
            combo.Items.Clear();
            combo.Items.Add("Simulator");
            combo.Items.AddRange(SerialPort.GetPortNames());
            checkedListBox_geslacht.SetItemChecked(0, true);
        }

        private void BStart_Click(object sender, EventArgs e)
        {
            maskedTextBox_gewicht.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            System.Console.WriteLine("text:"+maskedTextBox_gewicht.Text+"einde Text");
            if (checkedListBox_geslacht.CheckedItems.Count == 1 && maskedTextBox_gewicht.Text != "")
            {
                //System.Console.WriteLine(maskedTextBox_gewicht.Text);
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

                    if (checkedListBox_geslacht.GetItemChecked(0) == true)
                        isMannelijk = true;
                    else
                        isMannelijk = false;

                    string theDate = dateTimePickerLeeftijd.Value.ToString("yyyy-MM-dd");

                    int gewicht = Int32.Parse(maskedTextBox_gewicht.Text);

                    bike = new Bike(combo.SelectedItem.ToString(), new User("bram", "bram", "bram", theDate, isMannelijk, gewicht), this, ref client);
                    bike.Start();
                    Hide();
                }
                
            }
            else if (checkedListBox_geslacht.CheckedItems.Count != 1)
                MessageBox.Show("Kies 1 geslacht", "Er ging iets mis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (maskedTextBox_gewicht.Text != "")
                MessageBox.Show("Vul uw gewicht in", "Er ging iets mis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Kies uw leeftijd, Geslacht en gewicht.", "Er ging iets mis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        

        private void checkedListBox_geslacht_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("You are in the CheckBox.CheckedChanged event.");

            if (checkedListBox_geslacht.GetItemCheckState(0) == CheckState.Checked)
                checkedListBox_geslacht.SetItemChecked(1, false);

            else if(checkedListBox_geslacht.GetItemCheckState(1) == CheckState.Checked)
                checkedListBox_geslacht.SetItemChecked(0, false);
        }
    }
}
