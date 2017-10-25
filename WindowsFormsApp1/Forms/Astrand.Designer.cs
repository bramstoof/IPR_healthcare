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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_faseDesc = new System.Windows.Forms.Label();
            this.lbl_currentFase = new System.Windows.Forms.Label();
            this.lbl_timeLeftDesc = new System.Windows.Forms.Label();
            this.lbl_TimeLeft = new System.Windows.Forms.Label();
            this.timerTimeLeft = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Remote_Healtcare_Console.Properties.Resources.beach_wallpaper_090612883_305;
            this.pictureBox1.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1081, 554);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_faseDesc
            // 
            this.lbl_faseDesc.AutoSize = true;
            this.lbl_faseDesc.BackColor = System.Drawing.Color.Transparent;
            this.lbl_faseDesc.Font = new System.Drawing.Font("Impact", 24.20168F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_faseDesc.Location = new System.Drawing.Point(94, 192);
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
            this.lbl_currentFase.Location = new System.Drawing.Point(194, 192);
            this.lbl_currentFase.Name = "lbl_currentFase";
            this.lbl_currentFase.Size = new System.Drawing.Size(115, 48);
            this.lbl_currentFase.TabIndex = 2;
            this.lbl_currentFase.Text = "[FASE]";
            this.lbl_currentFase.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbl_timeLeftDesc
            // 
            this.lbl_timeLeftDesc.AutoSize = true;
            this.lbl_timeLeftDesc.BackColor = System.Drawing.Color.Transparent;
            this.lbl_timeLeftDesc.Font = new System.Drawing.Font("Impact", 24.20168F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_timeLeftDesc.Location = new System.Drawing.Point(94, 252);
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
            this.lbl_TimeLeft.Location = new System.Drawing.Point(341, 252);
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
            // Astrand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 552);
            this.Controls.Add(this.lbl_TimeLeft);
            this.Controls.Add(this.lbl_timeLeftDesc);
            this.Controls.Add(this.lbl_currentFase);
            this.Controls.Add(this.lbl_faseDesc);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Astrand";
            this.Text = "Astrand";
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
    }
}