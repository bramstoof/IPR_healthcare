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

        public Astrand()
        {
            startTest = false;
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            

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


        }

        private void makeThingTransparant(Control control)
        {
            string posVar = "pos"+control.ToString();
            var pos = this.PointToScreen(pic_CheckMark.Location);
            posCheckMark = pictureBox1.PointToClient(posCheckMark);
            pic_CheckMark.Parent = pictureBox1;
            pic_CheckMark.Location = posCheckMark;
            pic_CheckMark.BackColor = Color.Transparent;
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

        private void btn_startTest_Click(object sender, EventArgs e)
        {
            startTest = true;
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

        public void setRPM(int rpm)
        {
            if (this.lbl_RPMActual.InvokeRequired)
            {
                this.lbl_RPMActual.BeginInvoke((MethodInvoker)delegate () { this.lbl_RPMActual.Text = rpm.ToString();});
            }
            else
            {
                this.lbl_RPMActual.Text = rpm.ToString();
            }
        }

        public void setTimer(string seconds)
        {
            if (lbl_TimeLeft.InvokeRequired)
            {
                lbl_TimeLeft.BeginInvoke((MethodInvoker)delegate () { lbl_TimeLeft.Text = seconds; });
            }
            else
            {
                lbl_TimeLeft.Text = seconds;
            }
        }
    }
}
