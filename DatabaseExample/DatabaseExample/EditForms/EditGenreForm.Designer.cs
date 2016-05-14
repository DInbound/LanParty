namespace DatabaseExample
{
    partial class EditGenreForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.CB_Genre_Addictive = new System.Windows.Forms.CheckBox();
            this.TB_Genre_Name = new System.Windows.Forms.TextBox();
            this.BTN_Genre_Save = new System.Windows.Forms.Button();
            this.BTN_Genre_Cancel = new System.Windows.Forms.Button();
            this.TB_Genre_ID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // CB_Genre_Addictive
            // 
            this.CB_Genre_Addictive.AutoSize = true;
            this.CB_Genre_Addictive.Location = new System.Drawing.Point(61, 74);
            this.CB_Genre_Addictive.Name = "CB_Genre_Addictive";
            this.CB_Genre_Addictive.Size = new System.Drawing.Size(70, 17);
            this.CB_Genre_Addictive.TabIndex = 1;
            this.CB_Genre_Addictive.Text = "Addictive";
            this.CB_Genre_Addictive.UseVisualStyleBackColor = true;
            // 
            // TB_Genre_Name
            // 
            this.TB_Genre_Name.Location = new System.Drawing.Point(50, 48);
            this.TB_Genre_Name.Name = "TB_Genre_Name";
            this.TB_Genre_Name.Size = new System.Drawing.Size(188, 20);
            this.TB_Genre_Name.TabIndex = 0;
            // 
            // BTN_Genre_Save
            // 
            this.BTN_Genre_Save.Location = new System.Drawing.Point(50, 98);
            this.BTN_Genre_Save.Name = "BTN_Genre_Save";
            this.BTN_Genre_Save.Size = new System.Drawing.Size(89, 20);
            this.BTN_Genre_Save.TabIndex = 3;
            this.BTN_Genre_Save.Text = "Save";
            this.BTN_Genre_Save.UseVisualStyleBackColor = true;
            this.BTN_Genre_Save.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // BTN_Genre_Cancel
            // 
            this.BTN_Genre_Cancel.Location = new System.Drawing.Point(145, 98);
            this.BTN_Genre_Cancel.Name = "BTN_Genre_Cancel";
            this.BTN_Genre_Cancel.Size = new System.Drawing.Size(93, 20);
            this.BTN_Genre_Cancel.TabIndex = 2;
            this.BTN_Genre_Cancel.Text = "Cancel";
            this.BTN_Genre_Cancel.UseVisualStyleBackColor = true;
            this.BTN_Genre_Cancel.Click += new System.EventHandler(this.BTN_Cancel_Click);
            // 
            // TB_Genre_ID
            // 
            this.TB_Genre_ID.Location = new System.Drawing.Point(50, 15);
            this.TB_Genre_ID.Name = "TB_Genre_ID";
            this.TB_Genre_ID.ReadOnly = true;
            this.TB_Genre_ID.Size = new System.Drawing.Size(188, 20);
            this.TB_Genre_ID.TabIndex = 4;
            // 
            // EditGenreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 130);
            this.Controls.Add(this.TB_Genre_ID);
            this.Controls.Add(this.BTN_Genre_Cancel);
            this.Controls.Add(this.BTN_Genre_Save);
            this.Controls.Add(this.TB_Genre_Name);
            this.Controls.Add(this.CB_Genre_Addictive);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "EditGenreForm";
            this.Text = "Edit A Genre";
            this.ResumeLayout(false);
            this.PerformLayout();
            this.AcceptButton = BTN_Genre_Save;
            this.CancelButton = BTN_Genre_Cancel;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox CB_Genre_Addictive;
        private System.Windows.Forms.TextBox TB_Genre_Name;
        private System.Windows.Forms.Button BTN_Genre_Save;
        private System.Windows.Forms.Button BTN_Genre_Cancel;
        private System.Windows.Forms.TextBox TB_Genre_ID;
    }
}