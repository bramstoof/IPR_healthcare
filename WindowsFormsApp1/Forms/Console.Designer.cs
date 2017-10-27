namespace Remote_Healtcare_Console
{
    partial class Console
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
            this.BStart = new System.Windows.Forms.Button();
            this.lbl_leeftijd = new System.Windows.Forms.Label();
            this.lbl_geslacht = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comPorts = new System.Windows.Forms.ComboBox();
            this.Chat_Box = new System.Windows.Forms.TextBox();
            this.dateTimePickerLeeftijd = new System.Windows.Forms.DateTimePicker();
            this.lbl_gewicht = new System.Windows.Forms.Label();
            this.maskedTextBox_gewicht = new System.Windows.Forms.MaskedTextBox();
            this.checkedListBox_geslacht = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // BStart
            // 
            this.BStart.BackColor = System.Drawing.Color.DarkGray;
            this.BStart.Location = new System.Drawing.Point(35, 15);
            this.BStart.Margin = new System.Windows.Forms.Padding(4);
            this.BStart.Name = "BStart";
            this.BStart.Size = new System.Drawing.Size(100, 28);
            this.BStart.TabIndex = 0;
            this.BStart.Text = "Start";
            this.BStart.UseVisualStyleBackColor = false;
            this.BStart.Click += new System.EventHandler(this.BStart_Click);
            // 
            // lbl_leeftijd
            // 
            this.lbl_leeftijd.AutoSize = true;
            this.lbl_leeftijd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_leeftijd.Location = new System.Drawing.Point(13, 86);
            this.lbl_leeftijd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_leeftijd.Name = "lbl_leeftijd";
            this.lbl_leeftijd.Size = new System.Drawing.Size(67, 17);
            this.lbl_leeftijd.TabIndex = 2;
            this.lbl_leeftijd.Text = "Leeftijd:";
            // 
            // lbl_geslacht
            // 
            this.lbl_geslacht.AutoSize = true;
            this.lbl_geslacht.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_geslacht.Location = new System.Drawing.Point(13, 124);
            this.lbl_geslacht.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_geslacht.Name = "lbl_geslacht";
            this.lbl_geslacht.Size = new System.Drawing.Size(77, 17);
            this.lbl_geslacht.TabIndex = 3;
            this.lbl_geslacht.Text = "Geslacht:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 160);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 17);
            this.label3.TabIndex = 4;
            // 
            // comPorts
            // 
            this.comPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comPorts.FormattingEnabled = true;
            this.comPorts.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comPorts.Items.AddRange(new object[] {
            "Simulation",
            "COM1",
            "COM2",
            "COM3"});
            this.comPorts.Location = new System.Drawing.Point(159, 15);
            this.comPorts.Margin = new System.Windows.Forms.Padding(4);
            this.comPorts.Name = "comPorts";
            this.comPorts.Size = new System.Drawing.Size(99, 24);
            this.comPorts.TabIndex = 26;
            // 
            // Chat_Box
            // 
            this.Chat_Box.Location = new System.Drawing.Point(344, 15);
            this.Chat_Box.Margin = new System.Windows.Forms.Padding(4);
            this.Chat_Box.Multiline = true;
            this.Chat_Box.Name = "Chat_Box";
            this.Chat_Box.Size = new System.Drawing.Size(331, 366);
            this.Chat_Box.TabIndex = 27;
            // 
            // dateTimePickerLeeftijd
            // 
            this.dateTimePickerLeeftijd.Location = new System.Drawing.Point(87, 82);
            this.dateTimePickerLeeftijd.Name = "dateTimePickerLeeftijd";
            this.dateTimePickerLeeftijd.Size = new System.Drawing.Size(250, 22);
            this.dateTimePickerLeeftijd.TabIndex = 28;
            this.dateTimePickerLeeftijd.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // lbl_gewicht
            // 
            this.lbl_gewicht.AutoSize = true;
            this.lbl_gewicht.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_gewicht.Location = new System.Drawing.Point(13, 177);
            this.lbl_gewicht.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_gewicht.Name = "lbl_gewicht";
            this.lbl_gewicht.Size = new System.Drawing.Size(70, 17);
            this.lbl_gewicht.TabIndex = 30;
            this.lbl_gewicht.Text = "Gewicht:";
            // 
            // maskedTextBox_gewicht
            // 
            this.maskedTextBox_gewicht.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert;
            this.maskedTextBox_gewicht.Location = new System.Drawing.Point(87, 172);
            this.maskedTextBox_gewicht.Mask = "000kg";
            this.maskedTextBox_gewicht.Name = "maskedTextBox_gewicht";
            this.maskedTextBox_gewicht.Size = new System.Drawing.Size(100, 22);
            this.maskedTextBox_gewicht.TabIndex = 31;
            // 
            // checkedListBox_geslacht
            // 
            this.checkedListBox_geslacht.FormattingEnabled = true;
            this.checkedListBox_geslacht.Items.AddRange(new object[] {
            "man",
            "vrouw"});
            this.checkedListBox_geslacht.Location = new System.Drawing.Point(87, 124);
            this.checkedListBox_geslacht.Name = "checkedListBox_geslacht";
            this.checkedListBox_geslacht.Size = new System.Drawing.Size(73, 38);
            this.checkedListBox_geslacht.TabIndex = 32;
            // 
            // Console
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(692, 396);
            this.Controls.Add(this.checkedListBox_geslacht);
            this.Controls.Add(this.maskedTextBox_gewicht);
            this.Controls.Add(this.lbl_gewicht);
            this.Controls.Add(this.dateTimePickerLeeftijd);
            this.Controls.Add(this.Chat_Box);
            this.Controls.Add(this.comPorts);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_geslacht);
            this.Controls.Add(this.lbl_leeftijd);
            this.Controls.Add(this.BStart);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Console";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BStart;
        private System.Windows.Forms.Label lbl_leeftijd;
        private System.Windows.Forms.Label lbl_geslacht;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comPorts;
        private System.Windows.Forms.TextBox Chat_Box;
        private System.Windows.Forms.DateTimePicker dateTimePickerLeeftijd;
        private System.Windows.Forms.Label lbl_gewicht;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_gewicht;
        private System.Windows.Forms.CheckedListBox checkedListBox_geslacht;
    }
}

