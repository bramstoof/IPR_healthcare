namespace Remote_Healtcare_Console.Forms
{
    partial class Astrand
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbl_faseDesc = new System.Windows.Forms.Label();
            this.lbl_currentFase = new System.Windows.Forms.Label();
            this.lbl_timeLeftDesc = new System.Windows.Forms.Label();
            this.lbl_TimeLeft = new System.Windows.Forms.Label();
            this.timerTimeLeft = new System.Windows.Forms.Timer(this.components);
            this.pic_CheckMark = new System.Windows.Forms.PictureBox();
            this.pic_ArrowDown = new System.Windows.Forms.PictureBox();
            this.pic_ArrowUp = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_RPMActual = new System.Windows.Forms.Label();
            this.lbl_RPMDesc = new System.Windows.Forms.Label();
            this.txtBx_pulse = new System.Windows.Forms.TextBox();
            this.lbl_speedDesc = new System.Windows.Forms.Label();
            this.lbl_weerstandDesc = new System.Windows.Forms.Label();
            this.lbl_energieDesc = new System.Windows.Forms.Label();
            this.lbl_WattDesc = new System.Windows.Forms.Label();
            this.lbl_BPMDesc = new System.Windows.Forms.Label();
            this.lbl_speed = new System.Windows.Forms.Label();
            this.lbl_weerstand = new System.Windows.Forms.Label();
            this.lbl_energie = new System.Windows.Forms.Label();
            this.lbl_Watt = new System.Windows.Forms.Label();
            this.lbl_BPM = new System.Windows.Forms.Label();
            this.btn_sentBPM = new System.Windows.Forms.Button();
            this.TussentijdPuls = new System.Windows.Forms.Label();
            this.lblTussentijdPuls = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic_CheckMark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ArrowDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ArrowUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_faseDesc
            // 
            this.lbl_faseDesc.AutoSize = true;
            this.lbl_faseDesc.BackColor = System.Drawing.Color.Transparent;
            this.lbl_faseDesc.Font = new System.Drawing.Font("Impact", 24.20168F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_faseDesc.Location = new System.Drawing.Point(70, 33);
            this.lbl_faseDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_faseDesc.Name = "lbl_faseDesc";
            this.lbl_faseDesc.Size = new System.Drawing.Size(88, 41);
            this.lbl_faseDesc.TabIndex = 1;
            this.lbl_faseDesc.Text = "Fase:";
            // 
            // lbl_currentFase
            // 
            this.lbl_currentFase.AutoSize = true;
            this.lbl_currentFase.BackColor = System.Drawing.Color.Transparent;
            this.lbl_currentFase.Font = new System.Drawing.Font("Impact", 24.20168F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_currentFase.Location = new System.Drawing.Point(149, 33);
            this.lbl_currentFase.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_currentFase.Name = "lbl_currentFase";
            this.lbl_currentFase.Size = new System.Drawing.Size(95, 41);
            this.lbl_currentFase.TabIndex = 2;
            this.lbl_currentFase.Text = "[FASE]";
            // 
            // lbl_timeLeftDesc
            // 
            this.lbl_timeLeftDesc.AutoSize = true;
            this.lbl_timeLeftDesc.BackColor = System.Drawing.Color.Transparent;
            this.lbl_timeLeftDesc.Font = new System.Drawing.Font("Impact", 24.20168F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_timeLeftDesc.Location = new System.Drawing.Point(70, 84);
            this.lbl_timeLeftDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_timeLeftDesc.Name = "lbl_timeLeftDesc";
            this.lbl_timeLeftDesc.Size = new System.Drawing.Size(75, 41);
            this.lbl_timeLeftDesc.TabIndex = 3;
            this.lbl_timeLeftDesc.Text = "Tijd:";
            // 
            // lbl_TimeLeft
            // 
            this.lbl_TimeLeft.AutoSize = true;
            this.lbl_TimeLeft.BackColor = System.Drawing.Color.Transparent;
            this.lbl_TimeLeft.Font = new System.Drawing.Font("Impact", 24.20168F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TimeLeft.Location = new System.Drawing.Point(132, 84);
            this.lbl_TimeLeft.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_TimeLeft.Name = "lbl_TimeLeft";
            this.lbl_TimeLeft.Size = new System.Drawing.Size(158, 41);
            this.lbl_TimeLeft.TabIndex = 4;
            this.lbl_TimeLeft.Text = "[00:00:00]";
            // 
            // pic_CheckMark
            // 
            this.pic_CheckMark.BackColor = System.Drawing.Color.Transparent;
            this.pic_CheckMark.Image = global::Remote_Healtcare_Console.Properties.Resources.checkmark_green;
            this.pic_CheckMark.Location = new System.Drawing.Point(704, 156);
            this.pic_CheckMark.Margin = new System.Windows.Forms.Padding(2);
            this.pic_CheckMark.Name = "pic_CheckMark";
            this.pic_CheckMark.Size = new System.Drawing.Size(96, 100);
            this.pic_CheckMark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_CheckMark.TabIndex = 7;
            this.pic_CheckMark.TabStop = false;
            // 
            // pic_ArrowDown
            // 
            this.pic_ArrowDown.BackColor = System.Drawing.Color.Transparent;
            this.pic_ArrowDown.Image = global::Remote_Healtcare_Console.Properties.Resources.Arrow_Down;
            this.pic_ArrowDown.Location = new System.Drawing.Point(601, 33);
            this.pic_ArrowDown.Margin = new System.Windows.Forms.Padding(2);
            this.pic_ArrowDown.Name = "pic_ArrowDown";
            this.pic_ArrowDown.Size = new System.Drawing.Size(96, 101);
            this.pic_ArrowDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_ArrowDown.TabIndex = 6;
            this.pic_ArrowDown.TabStop = false;
            // 
            // pic_ArrowUp
            // 
            this.pic_ArrowUp.BackColor = System.Drawing.Color.Transparent;
            this.pic_ArrowUp.Image = global::Remote_Healtcare_Console.Properties.Resources.Arrow_Up;
            this.pic_ArrowUp.Location = new System.Drawing.Point(601, 279);
            this.pic_ArrowUp.Margin = new System.Windows.Forms.Padding(2);
            this.pic_ArrowUp.Name = "pic_ArrowUp";
            this.pic_ArrowUp.Size = new System.Drawing.Size(96, 100);
            this.pic_ArrowUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_ArrowUp.TabIndex = 5;
            this.pic_ArrowUp.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Remote_Healtcare_Console.Properties.Resources.beach_wallpaper_090612883_305;
            this.pictureBox1.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(811, 450);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_RPMActual
            // 
            this.lbl_RPMActual.AutoSize = true;
            this.lbl_RPMActual.BackColor = System.Drawing.Color.Transparent;
            this.lbl_RPMActual.Font = new System.Drawing.Font("Impact", 24.20168F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_RPMActual.Location = new System.Drawing.Point(602, 187);
            this.lbl_RPMActual.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_RPMActual.Name = "lbl_RPMActual";
            this.lbl_RPMActual.Size = new System.Drawing.Size(95, 41);
            this.lbl_RPMActual.TabIndex = 8;
            this.lbl_RPMActual.Text = "[RPM]";
            // 
            // lbl_RPMDesc
            // 
            this.lbl_RPMDesc.AutoSize = true;
            this.lbl_RPMDesc.BackColor = System.Drawing.Color.Transparent;
            this.lbl_RPMDesc.Font = new System.Drawing.Font("Impact", 24.20168F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_RPMDesc.Location = new System.Drawing.Point(524, 187);
            this.lbl_RPMDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_RPMDesc.Name = "lbl_RPMDesc";
            this.lbl_RPMDesc.Size = new System.Drawing.Size(84, 41);
            this.lbl_RPMDesc.TabIndex = 9;
            this.lbl_RPMDesc.Text = "RPM:";
            // 
            // txtBx_pulse
            // 
            this.txtBx_pulse.Location = new System.Drawing.Point(69, 417);
            this.txtBx_pulse.Margin = new System.Windows.Forms.Padding(2);
            this.txtBx_pulse.Name = "txtBx_pulse";
            this.txtBx_pulse.Size = new System.Drawing.Size(76, 20);
            this.txtBx_pulse.TabIndex = 10;
            this.txtBx_pulse.Text = "130";
            // 
            // lbl_speedDesc
            // 
            this.lbl_speedDesc.AutoSize = true;
            this.lbl_speedDesc.BackColor = System.Drawing.Color.Transparent;
            this.lbl_speedDesc.Font = new System.Drawing.Font("Impact", 24.20168F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_speedDesc.Location = new System.Drawing.Point(70, 133);
            this.lbl_speedDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_speedDesc.Name = "lbl_speedDesc";
            this.lbl_speedDesc.Size = new System.Drawing.Size(145, 41);
            this.lbl_speedDesc.TabIndex = 11;
            this.lbl_speedDesc.Text = "Snelheid:";
            // 
            // lbl_weerstandDesc
            // 
            this.lbl_weerstandDesc.AutoSize = true;
            this.lbl_weerstandDesc.BackColor = System.Drawing.Color.Transparent;
            this.lbl_weerstandDesc.Font = new System.Drawing.Font("Impact", 24.20168F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_weerstandDesc.Location = new System.Drawing.Point(70, 180);
            this.lbl_weerstandDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_weerstandDesc.Name = "lbl_weerstandDesc";
            this.lbl_weerstandDesc.Size = new System.Drawing.Size(174, 41);
            this.lbl_weerstandDesc.TabIndex = 12;
            this.lbl_weerstandDesc.Text = "Weerstand:";
            // 
            // lbl_energieDesc
            // 
            this.lbl_energieDesc.AutoSize = true;
            this.lbl_energieDesc.BackColor = System.Drawing.Color.Transparent;
            this.lbl_energieDesc.Font = new System.Drawing.Font("Impact", 24.20168F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_energieDesc.Location = new System.Drawing.Point(70, 229);
            this.lbl_energieDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_energieDesc.Name = "lbl_energieDesc";
            this.lbl_energieDesc.Size = new System.Drawing.Size(128, 41);
            this.lbl_energieDesc.TabIndex = 13;
            this.lbl_energieDesc.Text = "Energie:";
            // 
            // lbl_WattDesc
            // 
            this.lbl_WattDesc.AutoSize = true;
            this.lbl_WattDesc.BackColor = System.Drawing.Color.Transparent;
            this.lbl_WattDesc.Font = new System.Drawing.Font("Impact", 24.20168F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_WattDesc.Location = new System.Drawing.Point(70, 279);
            this.lbl_WattDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_WattDesc.Name = "lbl_WattDesc";
            this.lbl_WattDesc.Size = new System.Drawing.Size(88, 41);
            this.lbl_WattDesc.TabIndex = 14;
            this.lbl_WattDesc.Text = "Watt:";
            // 
            // lbl_BPMDesc
            // 
            this.lbl_BPMDesc.AutoSize = true;
            this.lbl_BPMDesc.BackColor = System.Drawing.Color.Transparent;
            this.lbl_BPMDesc.Font = new System.Drawing.Font("Impact", 24.20168F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_BPMDesc.Location = new System.Drawing.Point(70, 328);
            this.lbl_BPMDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_BPMDesc.Name = "lbl_BPMDesc";
            this.lbl_BPMDesc.Size = new System.Drawing.Size(142, 41);
            this.lbl_BPMDesc.TabIndex = 15;
            this.lbl_BPMDesc.Text = "Hartslag:";
            // 
            // lbl_speed
            // 
            this.lbl_speed.AutoSize = true;
            this.lbl_speed.BackColor = System.Drawing.Color.Transparent;
            this.lbl_speed.Font = new System.Drawing.Font("Impact", 24.20168F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_speed.Location = new System.Drawing.Point(204, 133);
            this.lbl_speed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_speed.Name = "lbl_speed";
            this.lbl_speed.Size = new System.Drawing.Size(133, 41);
            this.lbl_speed.TabIndex = 16;
            this.lbl_speed.Text = "[0 KM/H]";
            // 
            // lbl_weerstand
            // 
            this.lbl_weerstand.AutoSize = true;
            this.lbl_weerstand.BackColor = System.Drawing.Color.Transparent;
            this.lbl_weerstand.Font = new System.Drawing.Font("Impact", 24.20168F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_weerstand.Location = new System.Drawing.Point(233, 180);
            this.lbl_weerstand.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_weerstand.Name = "lbl_weerstand";
            this.lbl_weerstand.Size = new System.Drawing.Size(67, 41);
            this.lbl_weerstand.TabIndex = 17;
            this.lbl_weerstand.Text = "[75]";
            // 
            // lbl_energie
            // 
            this.lbl_energie.AutoSize = true;
            this.lbl_energie.BackColor = System.Drawing.Color.Transparent;
            this.lbl_energie.Font = new System.Drawing.Font("Impact", 24.20168F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_energie.Location = new System.Drawing.Point(196, 229);
            this.lbl_energie.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_energie.Name = "lbl_energie";
            this.lbl_energie.Size = new System.Drawing.Size(178, 41);
            this.lbl_energie.TabIndex = 18;
            this.lbl_energie.Text = "[100 kJoule]";
            // 
            // lbl_Watt
            // 
            this.lbl_Watt.AutoSize = true;
            this.lbl_Watt.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Watt.Font = new System.Drawing.Font("Impact", 24.20168F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Watt.Location = new System.Drawing.Point(149, 279);
            this.lbl_Watt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Watt.Name = "lbl_Watt";
            this.lbl_Watt.Size = new System.Drawing.Size(86, 41);
            this.lbl_Watt.TabIndex = 19;
            this.lbl_Watt.Text = "[0 W]";
            // 
            // lbl_BPM
            // 
            this.lbl_BPM.AutoSize = true;
            this.lbl_BPM.BackColor = System.Drawing.Color.Transparent;
            this.lbl_BPM.Font = new System.Drawing.Font("Impact", 24.20168F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_BPM.Location = new System.Drawing.Point(204, 328);
            this.lbl_BPM.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_BPM.Name = "lbl_BPM";
            this.lbl_BPM.Size = new System.Drawing.Size(155, 41);
            this.lbl_BPM.TabIndex = 20;
            this.lbl_BPM.Text = "[666 BPM]";
            // 
            // btn_sentBPM
            // 
            this.btn_sentBPM.Location = new System.Drawing.Point(149, 417);
            this.btn_sentBPM.Margin = new System.Windows.Forms.Padding(2);
            this.btn_sentBPM.Name = "btn_sentBPM";
            this.btn_sentBPM.Size = new System.Drawing.Size(56, 19);
            this.btn_sentBPM.TabIndex = 21;
            this.btn_sentBPM.Text = "Verstuur!";
            this.btn_sentBPM.UseVisualStyleBackColor = true;
            this.btn_sentBPM.Click += new System.EventHandler(this.btn_sentBPM_Click);
            // 
            // TussentijdPuls
            // 
            this.TussentijdPuls.AutoSize = true;
            this.TussentijdPuls.BackColor = System.Drawing.Color.Transparent;
            this.TussentijdPuls.Font = new System.Drawing.Font("Impact", 24.20168F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TussentijdPuls.Location = new System.Drawing.Point(387, 374);
            this.TussentijdPuls.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TussentijdPuls.Name = "TussentijdPuls";
            this.TussentijdPuls.Size = new System.Drawing.Size(28, 41);
            this.TussentijdPuls.TabIndex = 23;
            this.TussentijdPuls.Text = "-";
            // 
            // lblTussentijdPuls
            // 
            this.lblTussentijdPuls.AutoSize = true;
            this.lblTussentijdPuls.BackColor = System.Drawing.Color.Transparent;
            this.lblTussentijdPuls.Font = new System.Drawing.Font("Impact", 24.20168F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTussentijdPuls.Location = new System.Drawing.Point(70, 374);
            this.lblTussentijdPuls.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTussentijdPuls.Name = "lblTussentijdPuls";
            this.lblTussentijdPuls.Size = new System.Drawing.Size(324, 41);
            this.lblTussentijdPuls.TabIndex = 22;
            this.lblTussentijdPuls.Text = "Tussentijdse Hartslag:";
            // 
            // Astrand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 448);
            this.Controls.Add(this.TussentijdPuls);
            this.Controls.Add(this.lblTussentijdPuls);
            this.Controls.Add(this.btn_sentBPM);
            this.Controls.Add(this.lbl_BPM);
            this.Controls.Add(this.lbl_Watt);
            this.Controls.Add(this.lbl_energie);
            this.Controls.Add(this.lbl_weerstand);
            this.Controls.Add(this.lbl_speed);
            this.Controls.Add(this.lbl_BPMDesc);
            this.Controls.Add(this.lbl_WattDesc);
            this.Controls.Add(this.lbl_energieDesc);
            this.Controls.Add(this.lbl_weerstandDesc);
            this.Controls.Add(this.lbl_speedDesc);
            this.Controls.Add(this.txtBx_pulse);
            this.Controls.Add(this.lbl_RPMDesc);
            this.Controls.Add(this.lbl_RPMActual);
            this.Controls.Add(this.pic_CheckMark);
            this.Controls.Add(this.pic_ArrowDown);
            this.Controls.Add(this.pic_ArrowUp);
            this.Controls.Add(this.lbl_TimeLeft);
            this.Controls.Add(this.lbl_timeLeftDesc);
            this.Controls.Add(this.lbl_currentFase);
            this.Controls.Add(this.lbl_faseDesc);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Astrand";
            this.Text = "Astrand";
            ((System.ComponentModel.ISupportInitialize)(this.pic_CheckMark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ArrowDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ArrowUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_faseDesc;
        private System.Windows.Forms.Label lbl_currentFase;
        private System.Windows.Forms.Label lbl_timeLeftDesc;
        private System.Windows.Forms.Label lbl_TimeLeft;
        private System.Windows.Forms.Timer timerTimeLeft;
        private System.Windows.Forms.PictureBox pic_ArrowUp;
        private System.Windows.Forms.PictureBox pic_ArrowDown;
        private System.Windows.Forms.PictureBox pic_CheckMark;
        private System.Windows.Forms.Label lbl_RPMActual;
        private System.Windows.Forms.Label lbl_RPMDesc;
        private System.Windows.Forms.TextBox txtBx_pulse;
        private System.Windows.Forms.Label lbl_speedDesc;
        private System.Windows.Forms.Label lbl_weerstandDesc;
        private System.Windows.Forms.Label lbl_energieDesc;
        private System.Windows.Forms.Label lbl_WattDesc;
        private System.Windows.Forms.Label lbl_BPMDesc;
        private System.Windows.Forms.Label lbl_speed;
        private System.Windows.Forms.Label lbl_weerstand;
        private System.Windows.Forms.Label lbl_energie;
        private System.Windows.Forms.Label lbl_Watt;
        private System.Windows.Forms.Label lbl_BPM;
        private System.Windows.Forms.Button btn_sentBPM;
        private System.Windows.Forms.Label TussentijdPuls;
        private System.Windows.Forms.Label lblTussentijdPuls;
    }
}