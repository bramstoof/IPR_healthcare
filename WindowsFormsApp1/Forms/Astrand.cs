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
        public Astrand()
        {
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
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
