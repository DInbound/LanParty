namespace DatabaseExample
{
    partial class EditStudentForm
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
            this.TB_Student_ID = new System.Windows.Forms.TextBox();
            this.TB_Student_Name = new System.Windows.Forms.TextBox();
            this.DTP_Student_Geboortedatum = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_Student_Studiepunten = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CB_Student_Game = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BTN_Student_Save = new System.Windows.Forms.Button();
            this.BTN_Student_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TB_Student_ID
            // 
            this.TB_Student_ID.Location = new System.Drawing.Point(81, 12);
            this.TB_Student_ID.Name = "TB_Student_ID";
            this.TB_Student_ID.ReadOnly = true;
            this.TB_Student_ID.Size = new System.Drawing.Size(200, 20);
            this.TB_Student_ID.TabIndex = 0;
            // 
            // TB_Student_Name
            // 
            this.TB_Student_Name.Location = new System.Drawing.Point(81, 39);
            this.TB_Student_Name.Name = "TB_Student_Name";
            this.TB_Student_Name.Size = new System.Drawing.Size(200, 20);
            this.TB_Student_Name.TabIndex = 1;
            // 
            // DTP_Student_Geboortedatum
            // 
            this.DTP_Student_Geboortedatum.Location = new System.Drawing.Point(81, 65);
            this.DTP_Student_Geboortedatum.Name = "DTP_Student_Geboortedatum";
            this.DTP_Student_Geboortedatum.Size = new System.Drawing.Size(200, 20);
            this.DTP_Student_Geboortedatum.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Naam";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Geboorte";
            // 
            // TB_Student_Studiepunten
            // 
            this.TB_Student_Studiepunten.Location = new System.Drawing.Point(81, 92);
            this.TB_Student_Studiepunten.Name = "TB_Student_Studiepunten";
            this.TB_Student_Studiepunten.Size = new System.Drawing.Size(200, 20);
            this.TB_Student_Studiepunten.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Studiepunten";
            // 
            // CB_Student_Game
            // 
            this.CB_Student_Game.FormattingEnabled = true;
            this.CB_Student_Game.Location = new System.Drawing.Point(81, 119);
            this.CB_Student_Game.Name = "CB_Student_Game";
            this.CB_Student_Game.Size = new System.Drawing.Size(200, 21);
            this.CB_Student_Game.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Game";
            // 
            // BTN_Student_Save
            // 
            this.BTN_Student_Save.Location = new System.Drawing.Point(43, 150);
            this.BTN_Student_Save.Name = "BTN_Student_Save";
            this.BTN_Student_Save.Size = new System.Drawing.Size(94, 23);
            this.BTN_Student_Save.TabIndex = 10;
            this.BTN_Student_Save.Text = "Save";
            this.BTN_Student_Save.UseVisualStyleBackColor = true;
            this.BTN_Student_Save.Click += new System.EventHandler(this.BTN_Student_Save_Click);
            // 
            // BTN_Student_Cancel
            // 
            this.BTN_Student_Cancel.Location = new System.Drawing.Point(143, 150);
            this.BTN_Student_Cancel.Name = "BTN_Student_Cancel";
            this.BTN_Student_Cancel.Size = new System.Drawing.Size(95, 23);
            this.BTN_Student_Cancel.TabIndex = 11;
            this.BTN_Student_Cancel.Text = "Cancel";
            this.BTN_Student_Cancel.UseVisualStyleBackColor = true;
            this.BTN_Student_Cancel.Click += new System.EventHandler(this.BTN_Student_Cancel_Click);
            // 
            // EditStudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 185);
            this.Controls.Add(this.BTN_Student_Cancel);
            this.Controls.Add(this.BTN_Student_Save);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CB_Student_Game);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TB_Student_Studiepunten);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DTP_Student_Geboortedatum);
            this.Controls.Add(this.TB_Student_Name);
            this.Controls.Add(this.TB_Student_ID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "EditStudentForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit A Student";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_Student_ID;
        private System.Windows.Forms.TextBox TB_Student_Name;
        private System.Windows.Forms.DateTimePicker DTP_Student_Geboortedatum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_Student_Studiepunten;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CB_Student_Game;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BTN_Student_Save;
        private System.Windows.Forms.Button BTN_Student_Cancel;
    }
}