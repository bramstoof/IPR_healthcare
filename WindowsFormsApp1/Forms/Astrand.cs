using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Remote_Healtcare_Console.Forms
{
    public partial class Astrand : Form
    {
        int timeLeft = 2;
        int timeLeftInSeconds;
        int displaySeconds = 60;
        private Boolean testTimerRunning;
        public bool startTest{ get; set; }
        public int pulse { get; set; }

        public Astrand()
        {
            startTest = false;
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            pulse = 0;
            
            //making lbl_faseDesc transparent
            var poslblFase = this.PointToScreen(lbl_faseDesc.Location);
            poslblFase = pictureBox1.PointToClient(poslblFase);
            lbl_faseDesc.Parent = pictureBox1;
            lbl_faseDesc.Location = poslblFase;
            lbl_faseDesc.BackColor = Color.Transparent;

            //making lbl_currentFase label transparent
            var poslblCurrentFase = this.PointToScreen(lbl_currentFase.Location);
            poslblCurrentFase = pictureBox1.PointToClient(poslblCurrentFase);
            lbl_currentFase.Parent = pictureBox1;
            lbl_currentFase.Location = poslblCurrentFase;
            lbl_currentFase.BackColor = Color.Transparent;

            //making lbl_timeLeftDesc label transparent
            var poslbltimeLeftDesc = this.PointToScreen(lbl_timeLeftDesc.Location);
            poslbltimeLeftDesc = pictureBox1.PointToClient(poslbltimeLeftDesc);
            lbl_timeLeftDesc.Parent = pictureBox1;
            lbl_timeLeftDesc.Location = poslbltimeLeftDesc;
            lbl_timeLeftDesc.BackColor = Color.Transparent;

            //making lbl_TimeLeft label transparent
            var poslblTimeLeft = this.PointToScreen(lbl_TimeLeft.Location);
            poslblTimeLeft = pictureBox1.PointToClient(poslblTimeLeft);
            lbl_TimeLeft.Parent = pictureBox1;
            lbl_TimeLeft.Location = poslblTimeLeft;
            lbl_TimeLeft.BackColor = Color.Transparent;

            //making lbl_RPMDesc transparant
            var poslblRPMDesc = this.PointToScreen(lbl_RPMDesc.Location);
            poslblRPMDesc = pictureBox1.PointToClient(poslblRPMDesc);
            lbl_RPMDesc.Parent = pictureBox1;
            lbl_RPMDesc.Location = poslblRPMDesc;
            lbl_RPMDesc.BackColor = Color.Transparent;

            //making lbl_RPMActual transparent
            var poslblRPMActual = this.PointToScreen(lbl_RPMActual.Location);
            poslblRPMActual = pictureBox1.PointToClient(poslblRPMActual);
            lbl_RPMActual.Parent = pictureBox1;
            lbl_RPMActual.Location = poslblRPMActual;
            lbl_RPMActual.BackColor = Color.Transparent;

            //making pic_ArrowUp transparent
            var posArrowUp = this.PointToScreen(pic_ArrowUp.Location);
            posArrowUp = pictureBox1.PointToClient(posArrowUp);
            pic_ArrowUp.Parent = pictureBox1;
            pic_ArrowUp.Location = posArrowUp;
            pic_ArrowUp.BackColor = Color.Transparent;

            //making pic_ArrowDown transparent
            var posArrowDown = this.PointToScreen(pic_ArrowDown.Location);
            posArrowDown = pictureBox1.PointToClient(posArrowDown);
            pic_ArrowDown.Parent = pictureBox1;
            pic_ArrowDown.Location = posArrowDown;
            pic_ArrowDown.BackColor = Color.Transparent;

            //making pic_CheckMark transparent
            var posCheckMark = this.PointToScreen(pic_CheckMark.Location);
            posCheckMark = pictureBox1.PointToClient(posCheckMark);
            pic_CheckMark.Parent = pictureBox1;
            pic_CheckMark.Location = posCheckMark;
            pic_CheckMark.BackColor = Color.Transparent;

            //making lbl_speedDesc transparent
            var posSpeedDesc = this.PointToScreen(lbl_speedDesc.Location);
            posSpeedDesc = pictureBox1.PointToClient(posSpeedDesc);
            lbl_speedDesc.Parent = pictureBox1;
            lbl_speedDesc.Location = posSpeedDesc;
            lbl_speedDesc.BackColor = Color.Transparent;

            //making lbl_speed transparent
            var posSpeed = this.PointToScreen(lbl_speed.Location);
            posSpeed = pictureBox1.PointToClient(posSpeed);
            lbl_speed.Parent = pictureBox1;
            lbl_speed.Location = posSpeed;
            lbl_speed.BackColor = Color.Transparent;

            //making lbl_energieDesc transparent
            var posEnergyDesc = this.PointToScreen(lbl_energieDesc.Location);
            posEnergyDesc = pictureBox1.PointToClient(posEnergyDesc);
            lbl_energieDesc.Parent = pictureBox1;
            lbl_energieDesc.Location = posEnergyDesc;
            lbl_energieDesc.BackColor = Color.Transparent;

            //making lbl_energie transparent
            var posEnergy = this.PointToScreen(lbl_energie.Location);
            posEnergy = pictureBox1.PointToClient(posEnergy);
            lbl_energie.Parent = pictureBox1;
            lbl_energie.Location = posEnergy;
            lbl_energie.BackColor = Color.Transparent;

            //making lbl_WattDesc transparent
            var posWattDesc = this.PointToScreen(lbl_WattDesc.Location);
            posWattDesc = pictureBox1.PointToClient(posWattDesc);
            lbl_WattDesc.Parent = pictureBox1;
            lbl_WattDesc.Location = posWattDesc;
            lbl_WattDesc.BackColor = Color.Transparent;

            //making lbl_Watt transparent
            var posWatt = this.PointToScreen(lbl_Watt.Location);
            posWatt = pictureBox1.PointToClient(posWatt);
            lbl_Watt.Parent = pictureBox1;
            lbl_Watt.Location = posWatt;
            lbl_Watt.BackColor = Color.Transparent;

            //making lbl_weerstandDesc transparent
            var posWeerstandDesc = this.PointToScreen(lbl_weerstandDesc.Location);
            posWeerstandDesc = pictureBox1.PointToClient(posWeerstandDesc);
            lbl_weerstandDesc.Parent = pictureBox1;
            lbl_weerstandDesc.Location = posWeerstandDesc;
            lbl_weerstandDesc.BackColor = Color.Transparent;

            //making lbl_weerstand transparent
            var posWeerstand = this.PointToScreen(lbl_weerstand.Location);
            posWeerstand = pictureBox1.PointToClient(posWeerstand);
            lbl_weerstand.Parent = pictureBox1;
            lbl_weerstand.Location = posWeerstand;
            lbl_weerstand.BackColor = Color.Transparent;

            //making lbl_BPMDesc transparent
            var posBPMDesc = this.PointToScreen(lbl_BPMDesc.Location);
            posBPMDesc = pictureBox1.PointToClient(posBPMDesc);
            lbl_BPMDesc.Parent = pictureBox1;
            lbl_BPMDesc.Location = posBPMDesc;
            lbl_BPMDesc.BackColor = Color.Transparent;

            //making lbl_BPM transparent
            var posBPM = this.PointToScreen(lbl_BPM.Location);
            posBPM = pictureBox1.PointToClient(posBPM);
            lbl_BPM.Parent = pictureBox1;
            lbl_BPM.Location = posBPM;
            lbl_BPM.BackColor = Color.Transparent;

            //making lblTussentijdPuls transparent
            var posTTPDesc = this.PointToScreen(lblTussentijdPuls.Location);
            posTTPDesc = pictureBox1.PointToClient(posTTPDesc);
            lblTussentijdPuls.Parent = pictureBox1;
            lblTussentijdPuls.Location = posTTPDesc;
            lblTussentijdPuls.BackColor = Color.Transparent;

            //making TussentijdPuls transparent
            var posTTP = this.PointToScreen(TussentijdPuls.Location);
            posTTP = pictureBox1.PointToClient(posTTP);
            TussentijdPuls.Parent = pictureBox1;
            TussentijdPuls.Location = posTTP;
            TussentijdPuls.BackColor = Color.Transparent;
        }

        private void btn_startTest_Click(object sender, EventArgs e)
        {
            startTest = true;
        }
        
        public void SetFaseText(String text)
        {
            if (this.lbl_currentFase.InvokeRequired)
            {
                this.lbl_currentFase.BeginInvoke((MethodInvoker)delegate () { this.lbl_currentFase.Text = text; ; });
            }
            else
            {
                this.lbl_currentFase.Text = text; ;
            }
        }

        public void resistanceUp()
        {
            if (pic_CheckMark.InvokeRequired || pic_ArrowUp.InvokeRequired || pic_ArrowDown.InvokeRequired)
            {
                pic_CheckMark.BeginInvoke((MethodInvoker)delegate () { pic_CheckMark.Hide(); ; });
                pic_ArrowDown.BeginInvoke((MethodInvoker)delegate () { pic_ArrowDown.Hide(); ; });
                pic_ArrowUp.BeginInvoke((MethodInvoker)delegate () { pic_ArrowUp.Show(); ; });

            }
            else
            {
                pic_CheckMark.Hide();
                pic_ArrowDown.Hide();
                pic_ArrowUp.Show();
            }
        }

        public void resistanceDown()
        {
            if (pic_CheckMark.InvokeRequired || pic_ArrowUp.InvokeRequired || pic_ArrowDown.InvokeRequired)
            {
                pic_CheckMark.BeginInvoke((MethodInvoker)delegate () { pic_CheckMark.Hide(); ; });
                pic_ArrowUp.BeginInvoke((MethodInvoker)delegate () { pic_ArrowUp.Hide(); ; });
                pic_ArrowDown.BeginInvoke((MethodInvoker)delegate () { pic_ArrowDown.Show(); ; });
            }
            else
            {
                pic_CheckMark.Hide();
                pic_ArrowUp.Hide();
                pic_ArrowDown.Show();
            }
        }

        public void resistenceGood()
        {
            if (pic_CheckMark.InvokeRequired || pic_ArrowUp.InvokeRequired || pic_ArrowDown.InvokeRequired)
            {
                pic_ArrowUp.BeginInvoke((MethodInvoker)delegate () { pic_ArrowUp.Hide();});
                pic_ArrowDown.BeginInvoke((MethodInvoker)delegate () { pic_ArrowDown.Hide();});
                pic_CheckMark.BeginInvoke((MethodInvoker)delegate () { pic_CheckMark.Show();});
            }
            else
            {
                pic_ArrowUp.Hide();
                pic_ArrowDown.Hide();
                pic_CheckMark.Show();
            }
        }

        public void setAll(string tijd, double snelheid, int weerstand, int energie, int watt, int BPM, int RPM)
        {
            if(lbl_currentFase.InvokeRequired || lbl_TimeLeft.InvokeRequired || lbl_speed.InvokeRequired || lbl_weerstand.InvokeRequired || lbl_energie.InvokeRequired || lbl_Watt.InvokeRequired || lbl_BPM.InvokeRequired || lbl_RPMActual.InvokeRequired)
            {
                //lbl_currentFase.BeginInvoke((MethodInvoker)delegate () { lbl_currentFase.Text = fase; ; });
                lbl_TimeLeft.BeginInvoke((MethodInvoker)delegate () { lbl_TimeLeft.Text = tijd; ; });
                lbl_speed.BeginInvoke((MethodInvoker)delegate () { lbl_speed.Text = snelheid.ToString() + " km/h"; ; });
                lbl_weerstand.BeginInvoke((MethodInvoker)delegate () { lbl_weerstand.Text = weerstand.ToString()+ " W"; ; });
                lbl_energie.BeginInvoke((MethodInvoker)delegate () { lbl_energie.Text = energie.ToString() + " kJoule"; ; });
                lbl_Watt.BeginInvoke((MethodInvoker)delegate () { lbl_Watt.Text = watt.ToString() + " W"; ; });
                lbl_BPM.BeginInvoke((MethodInvoker)delegate () { lbl_BPM.Text = BPM.ToString() + " BPM"; ; });
                lbl_RPMActual.BeginInvoke((MethodInvoker)delegate () { lbl_RPMActual.Text = RPM.ToString(); ; });
            }
            else
            {
                //lbl_currentFase.Text = fase; ;
                lbl_TimeLeft.Text = tijd; ;
                lbl_speed.Text = snelheid.ToString() + " km/h"; ;
                lbl_weerstand.Text = weerstand.ToString() + " W"; ;
                lbl_energie.Text = energie.ToString() + " kJoule"; ;
                lbl_Watt.Text = watt.ToString() + " W"; ;
                lbl_BPM.Text = BPM.ToString() + " BPM"; ;
                lbl_RPMActual.Text = RPM.ToString(); ;
            }
        }

        public void setTussenTijdseHartslag(int hartslagTussenTijds)
        {
            if(TussentijdPuls.InvokeRequired)
            {
                TussentijdPuls.BeginInvoke((MethodInvoker)delegate () { TussentijdPuls.Text = hartslagTussenTijds.ToString() + " BPM"; ; });
            }
            else
            {
                TussentijdPuls.Text = hartslagTussenTijds.ToString() + " BPM";
            }
        }

        private void btn_sentBPM_Click(object sender, EventArgs e)
        {
            lbl_BPM.Text = txtBx_pulse.Text;
            int j;
            if (Int32.TryParse(txtBx_pulse.Text, out j))
                pulse = j;
            else
                MessageBox.Show("Geen geldige waarde", "Er ging iets fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void succesfullAstrandTest(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
