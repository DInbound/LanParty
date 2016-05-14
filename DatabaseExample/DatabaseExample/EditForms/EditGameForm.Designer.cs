namespace DatabaseExample
{
    partial class EditGameForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.TB_Game_Id = new System.Windows.Forms.TextBox();
            this.TB_Game_Name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CB_Game_Genre = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BTN_Game_Save = new System.Windows.Forms.Button();
            this.BTN_Game_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // TB_Game_Id
            // 
            this.TB_Game_Id.Location = new System.Drawing.Point(54, 6);
            this.TB_Game_Id.Name = "TB_Game_Id";
            this.TB_Game_Id.ReadOnly = true;
            this.TB_Game_Id.Size = new System.Drawing.Size(185, 20);
            this.TB_Game_Id.TabIndex = 4;
            // 
            // TB_Game_Name
            // 
            this.TB_Game_Name.Location = new System.Drawing.Point(54, 32);
            this.TB_Game_Name.Name = "TB_Game_Name";
            this.TB_Game_Name.Size = new System.Drawing.Size(185, 20);
            this.TB_Game_Name.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Game";
            // 
            // CB_Game_Genre
            // 
            this.CB_Game_Genre.FormattingEnabled = true;
            this.CB_Game_Genre.Location = new System.Drawing.Point(54, 58);
            this.CB_Game_Genre.Name = "CB_Game_Genre";
            this.CB_Game_Genre.Size = new System.Drawing.Size(185, 21);
            this.CB_Game_Genre.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Genre";
            // 
            // BTN_Game_Save
            // 
            this.BTN_Game_Save.Location = new System.Drawing.Point(28, 85);
            this.BTN_Game_Save.Name = "BTN_Game_Save";
            this.BTN_Game_Save.Size = new System.Drawing.Size(103, 23);
            this.BTN_Game_Save.TabIndex = 3;
            this.BTN_Game_Save.Text = "Save";
            this.BTN_Game_Save.UseVisualStyleBackColor = true;
            this.BTN_Game_Save.Click += new System.EventHandler(this.BTN_Game_Save_Click);
            // 
            // BTN_Game_Cancel
            // 
            this.BTN_Game_Cancel.Location = new System.Drawing.Point(137, 85);
            this.BTN_Game_Cancel.Name = "BTN_Game_Cancel";
            this.BTN_Game_Cancel.Size = new System.Drawing.Size(102, 23);
            this.BTN_Game_Cancel.TabIndex = 2;
            this.BTN_Game_Cancel.Text = "Cancel";
            this.BTN_Game_Cancel.UseVisualStyleBackColor = true;
            this.BTN_Game_Cancel.Click += new System.EventHandler(this.BTN_Game_Cancel_Click);
            // 
            // EditGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 124);
            this.Controls.Add(this.BTN_Game_Cancel);
            this.Controls.Add(this.BTN_Game_Save);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CB_Game_Genre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TB_Game_Name);
            this.Controls.Add(this.TB_Game_Id);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "EditGameForm";
            this.Text = "Edit A Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_Game_Id;
        private System.Windows.Forms.TextBox TB_Game_Name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CB_Game_Genre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BTN_Game_Save;
        private System.Windows.Forms.Button BTN_Game_Cancel;
    }
}