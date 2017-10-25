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



        public Astrand()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            timeLeftInSeconds = timeLeft * 60;

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

            timerTimeLeft.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timerTimeLeft_Tick(object sender, EventArgs e)
        {
            if (timeLeftInSeconds > 0)
            {
                if(timeLeftInSeconds % 60 == 0)
                {
                    displaySeconds = 60;
                    timeLeft -= 1;
                    timeLeftInSeconds -= 1;
                    displaySeconds -= 1;
                    lbl_TimeLeft.Text = timeLeft + " minuten en " + displaySeconds + " seconden";
                }
                else
                {
                    timeLeftInSeconds -= 1;
                    displaySeconds -= 1;
                    lbl_TimeLeft.Text = timeLeft + " minuten en " + displaySeconds + " seconden";
                }
            }
            else
            {
                // If the user ran out of time, stop the timer, show
                // a MessageBox, and fill in the answers.
                timerTimeLeft.Stop();
                lbl_TimeLeft.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
            }
        }
    }
}
