﻿namespace Remote_Healtcare_Console.Forms
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
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            this.lbl_faseDesc.Location = new System.Drawing.Point(94, 41);
            this.lbl_faseDesc.Name = "lbl_faseDesc";
            this.lbl_faseDesc.Size = new System.Drawing.Size(110, 48);
            this.lbl_faseDesc.TabIndex = 1;
            this.lbl_faseDesc.Text = "Fase: ";
            // 
            // lbl_currentFase
            // 
            this.lbl_currentFase.AutoSize = true;
            this.lbl_currentFase.BackColor = System.Drawing.Color.Transparent;
            this.lbl_currentFase.Font = new System.Drawing.Font("Impact", 24.20168F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_currentFase.Location = new System.Drawing.Point(196, 41);
            this.lbl_currentFase.Name = "lbl_currentFase";
            this.lbl_currentFase.Size = new System.Drawing.Size(115, 48);
            this.lbl_currentFase.TabIndex = 2;
            this.lbl_currentFase.Text = "[FASE]";
            // 
            // lbl_timeLeftDesc
            // 
            this.lbl_timeLeftDesc.AutoSize = true;
            this.lbl_timeLeftDesc.BackColor = System.Drawing.Color.Transparent;
            this.lbl_timeLeftDesc.Font = new System.Drawing.Font("Impact", 24.20168F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_timeLeftDesc.Location = new System.Drawing.Point(94, 103);
            this.lbl_timeLeftDesc.Name = "lbl_timeLeftDesc";
            this.lbl_timeLeftDesc.Size = new System.Drawing.Size(257, 48);
            this.lbl_timeLeftDesc.TabIndex = 3;
            this.lbl_timeLeftDesc.Text = "Tijd resterend:";
            // 
            // lbl_TimeLeft
            // 
            this.lbl_TimeLeft.AutoSize = true;
            this.lbl_TimeLeft.BackColor = System.Drawing.Color.Transparent;
            this.lbl_TimeLeft.Font = new System.Drawing.Font("Impact", 24.20168F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TimeLeft.Location = new System.Drawing.Point(342, 103);
            this.lbl_TimeLeft.Name = "lbl_TimeLeft";
            this.lbl_TimeLeft.Size = new System.Drawing.Size(184, 48);
            this.lbl_TimeLeft.TabIndex = 4;
            this.lbl_TimeLeft.Text = "[00:00:00]";
            // 
            // timerTimeLeft
            // 
            this.timerTimeLeft.Interval = 1000;
            this.timerTimeLeft.Tick += new System.EventHandler(this.timerTimeLeft_Tick);
            // 
            // pic_CheckMark
            // 
            this.pic_CheckMark.BackColor = System.Drawing.Color.Transparent;
            this.pic_CheckMark.Image = global::Remote_Healtcare_Console.Properties.Resources.checkmark_green;
            this.pic_CheckMark.Location = new System.Drawing.Point(938, 192);
            this.pic_CheckMark.Name = "pic_CheckMark";
            this.pic_CheckMark.Size = new System.Drawing.Size(128, 123);
            this.pic_CheckMark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_CheckMark.TabIndex = 7;
            this.pic_CheckMark.TabStop = false;
            // 
            // pic_ArrowDown
            // 
            this.pic_ArrowDown.BackColor = System.Drawing.Color.Transparent;
            this.pic_ArrowDown.Image = global::Remote_Healtcare_Console.Properties.Resources.Arrow_Down;
            this.pic_ArrowDown.Location = new System.Drawing.Point(801, 41);
            this.pic_ArrowDown.Name = "pic_ArrowDown";
            this.pic_ArrowDown.Size = new System.Drawing.Size(128, 124);
            this.pic_ArrowDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_ArrowDown.TabIndex = 6;
            this.pic_ArrowDown.TabStop = false;
            // 
            // pic_ArrowUp
            // 
            this.pic_ArrowUp.BackColor = System.Drawing.Color.Transparent;
            this.pic_ArrowUp.Image = global::Remote_Healtcare_Console.Properties.Resources.Arrow_Up;
            this.pic_ArrowUp.Location = new System.Drawing.Point(801, 343);
            this.pic_ArrowUp.Name = "pic_ArrowUp";
            this.pic_ArrowUp.Size = new System.Drawing.Size(128, 123);
            this.pic_ArrowUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_ArrowUp.TabIndex = 5;
            this.pic_ArrowUp.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Remote_Healtcare_Console.Properties.Resources.beach_wallpaper_090612883_305;
            this.pictureBox1.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1081, 554);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_RPMActual
            // 
            this.lbl_RPMActual.AutoSize = true;
            this.lbl_RPMActual.BackColor = System.Drawing.Color.Transparent;
            this.lbl_RPMActual.Font = new System.Drawing.Font("Impact", 24.20168F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_RPMActual.Location = new System.Drawing.Point(793, 230);
            this.lbl_RPMActual.Name = "lbl_RPMActual";
            this.lbl_RPMActual.Size = new System.Drawing.Size(113, 48);
            this.lbl_RPMActual.TabIndex = 8;
            this.lbl_RPMActual.Text = "[RPM]";
            // 
            // lbl_RPMDesc
            // 
            this.lbl_RPMDesc.AutoSize = true;
            this.lbl_RPMDesc.BackColor = System.Drawing.Color.Transparent;
            this.lbl_RPMDesc.Font = new System.Drawing.Font("Impact", 24.20168F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_RPMDesc.Location = new System.Drawing.Point(699, 230);
            this.lbl_RPMDesc.Name = "lbl_RPMDesc";
            this.lbl_RPMDesc.Size = new System.Drawing.Size(99, 48);
            this.lbl_RPMDesc.TabIndex = 9;
            this.lbl_RPMDesc.Text = "RPM:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(93, 167);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 10;
            // 
            // Astrand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 552);
            this.Controls.Add(this.textBox1);
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
        private System.Windows.Forms.TextBox textBox1;
    }
}