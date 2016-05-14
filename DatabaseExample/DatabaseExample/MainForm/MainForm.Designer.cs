namespace DatabaseExample
{
    partial class MainForm
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
            this.LV_Genres = new System.Windows.Forms.ListView();
            this.idHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addictiveHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CMS_ClickedGenreListBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSM_RefreshGenre = new System.Windows.Forms.ToolStripMenuItem();
            this.TSM_AddGenre = new System.Windows.Forms.ToolStripMenuItem();
            this.TSM_EditGenre = new System.Windows.Forms.ToolStripMenuItem();
            this.TSM_DeleteGenre = new System.Windows.Forms.ToolStripMenuItem();
            this.BTN_AddGenre = new System.Windows.Forms.Button();
            this.BTN_EditGenre = new System.Windows.Forms.Button();
            this.BTN_DeleteGenre = new System.Windows.Forms.Button();
            this.NI_Notification = new System.Windows.Forms.NotifyIcon(this.components);
            this.GB_ChangeValues = new System.Windows.Forms.GroupBox();
            this.TC_Tabs = new System.Windows.Forms.TabControl();
            this.TAB_Game = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BTN_DeleteGame = new System.Windows.Forms.Button();
            this.BTN_EditGame = new System.Windows.Forms.Button();
            this.BTN_AddGame = new System.Windows.Forms.Button();
            this.LV_Game = new System.Windows.Forms.ListView();
            this.gameId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gameName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gameGenre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CMS_ClickedGameListBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSM_RefreshGame = new System.Windows.Forms.ToolStripMenuItem();
            this.TSM_AddGame = new System.Windows.Forms.ToolStripMenuItem();
            this.TSM_EditGame = new System.Windows.Forms.ToolStripMenuItem();
            this.TSM_DeleteGame = new System.Windows.Forms.ToolStripMenuItem();
            this.TAB_Genre = new System.Windows.Forms.TabPage();
            this.TSM_MenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSM_File_Refresh_All = new System.Windows.Forms.ToolStripMenuItem();
            this.TSM_File_Refresh_Game = new System.Windows.Forms.ToolStripMenuItem();
            this.TSM_File_Refresh_Genre = new System.Windows.Forms.ToolStripMenuItem();
            this.CMS_ClickedGenreListBox.SuspendLayout();
            this.GB_ChangeValues.SuspendLayout();
            this.TC_Tabs.SuspendLayout();
            this.TAB_Game.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.CMS_ClickedGameListBox.SuspendLayout();
            this.TAB_Genre.SuspendLayout();
            this.TSM_MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // LV_Genres
            // 
            this.LV_Genres.AllowColumnReorder = true;
            this.LV_Genres.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.idHeader,
            this.nameHeader,
            this.addictiveHeader});
            this.LV_Genres.ContextMenuStrip = this.CMS_ClickedGenreListBox;
            this.LV_Genres.FullRowSelect = true;
            this.LV_Genres.GridLines = true;
            this.LV_Genres.Location = new System.Drawing.Point(6, 6);
            this.LV_Genres.MultiSelect = false;
            this.LV_Genres.Name = "LV_Genres";
            this.LV_Genres.Size = new System.Drawing.Size(365, 291);
            this.LV_Genres.TabIndex = 2;
            this.LV_Genres.UseCompatibleStateImageBehavior = false;
            this.LV_Genres.View = System.Windows.Forms.View.Details;
            this.LV_Genres.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LV_Genres_ColumnClick);
            // 
            // idHeader
            // 
            this.idHeader.Text = "ID";
            // 
            // nameHeader
            // 
            this.nameHeader.Text = "Name";
            this.nameHeader.Width = 180;
            // 
            // addictiveHeader
            // 
            this.addictiveHeader.Text = "Addictive";
            this.addictiveHeader.Width = 100;
            // 
            // CMS_ClickedGenreListBox
            // 
            this.CMS_ClickedGenreListBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSM_RefreshGenre,
            this.TSM_AddGenre,
            this.TSM_EditGenre,
            this.TSM_DeleteGenre});
            this.CMS_ClickedGenreListBox.Name = "CMS_ClickedListBox";
            this.CMS_ClickedGenreListBox.Size = new System.Drawing.Size(114, 92);
            // 
            // TSM_RefreshGenre
            // 
            this.TSM_RefreshGenre.Name = "TSM_RefreshGenre";
            this.TSM_RefreshGenre.Size = new System.Drawing.Size(113, 22);
            this.TSM_RefreshGenre.Text = "Refresh";
            this.TSM_RefreshGenre.Click += new System.EventHandler(this.TSM_RefreshGenre_Click);
            // 
            // TSM_AddGenre
            // 
            this.TSM_AddGenre.Name = "TSM_AddGenre";
            this.TSM_AddGenre.Size = new System.Drawing.Size(113, 22);
            this.TSM_AddGenre.Text = "Add";
            this.TSM_AddGenre.Click += new System.EventHandler(this.TSM_AddGenre_Click);
            // 
            // TSM_EditGenre
            // 
            this.TSM_EditGenre.Name = "TSM_EditGenre";
            this.TSM_EditGenre.Size = new System.Drawing.Size(113, 22);
            this.TSM_EditGenre.Text = "Edit";
            this.TSM_EditGenre.Click += new System.EventHandler(this.TSM_EditGenre_Click);
            // 
            // TSM_DeleteGenre
            // 
            this.TSM_DeleteGenre.Name = "TSM_DeleteGenre";
            this.TSM_DeleteGenre.Size = new System.Drawing.Size(113, 22);
            this.TSM_DeleteGenre.Text = "Delete";
            this.TSM_DeleteGenre.Click += new System.EventHandler(this.TSM_Delete_Click);
            // 
            // BTN_AddGenre
            // 
            this.BTN_AddGenre.Location = new System.Drawing.Point(7, 19);
            this.BTN_AddGenre.Name = "BTN_AddGenre";
            this.BTN_AddGenre.Size = new System.Drawing.Size(144, 26);
            this.BTN_AddGenre.TabIndex = 3;
            this.BTN_AddGenre.Text = "Add Genre";
            this.BTN_AddGenre.UseVisualStyleBackColor = true;
            this.BTN_AddGenre.Click += new System.EventHandler(this.BTN_AddGenre_Click);
            // 
            // BTN_EditGenre
            // 
            this.BTN_EditGenre.Location = new System.Drawing.Point(7, 51);
            this.BTN_EditGenre.Name = "BTN_EditGenre";
            this.BTN_EditGenre.Size = new System.Drawing.Size(144, 24);
            this.BTN_EditGenre.TabIndex = 4;
            this.BTN_EditGenre.Text = "Edit Genre";
            this.BTN_EditGenre.UseVisualStyleBackColor = true;
            this.BTN_EditGenre.Click += new System.EventHandler(this.BTN_Edit_Click);
            // 
            // BTN_DeleteGenre
            // 
            this.BTN_DeleteGenre.Location = new System.Drawing.Point(6, 81);
            this.BTN_DeleteGenre.Name = "BTN_DeleteGenre";
            this.BTN_DeleteGenre.Size = new System.Drawing.Size(145, 23);
            this.BTN_DeleteGenre.TabIndex = 5;
            this.BTN_DeleteGenre.Text = "Delete Genre";
            this.BTN_DeleteGenre.UseVisualStyleBackColor = true;
            this.BTN_DeleteGenre.Click += new System.EventHandler(this.BTN_Delete_Click);
            // 
            // NI_Notification
            // 
            this.NI_Notification.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.NI_Notification.BalloonTipText = "sample text";
            this.NI_Notification.BalloonTipTitle = "Database Update";
            this.NI_Notification.Text = "sample text";
            this.NI_Notification.Visible = true;
            // 
            // GB_ChangeValues
            // 
            this.GB_ChangeValues.Controls.Add(this.BTN_DeleteGenre);
            this.GB_ChangeValues.Controls.Add(this.BTN_EditGenre);
            this.GB_ChangeValues.Controls.Add(this.BTN_AddGenre);
            this.GB_ChangeValues.Location = new System.Drawing.Point(381, 6);
            this.GB_ChangeValues.Name = "GB_ChangeValues";
            this.GB_ChangeValues.Size = new System.Drawing.Size(155, 113);
            this.GB_ChangeValues.TabIndex = 6;
            this.GB_ChangeValues.TabStop = false;
            this.GB_ChangeValues.Text = "Change Values";
            // 
            // TC_Tabs
            // 
            this.TC_Tabs.Controls.Add(this.TAB_Game);
            this.TC_Tabs.Controls.Add(this.TAB_Genre);
            this.TC_Tabs.Location = new System.Drawing.Point(8, 27);
            this.TC_Tabs.Name = "TC_Tabs";
            this.TC_Tabs.SelectedIndex = 0;
            this.TC_Tabs.Size = new System.Drawing.Size(550, 329);
            this.TC_Tabs.TabIndex = 2;
            // 
            // TAB_Game
            // 
            this.TAB_Game.Controls.Add(this.groupBox2);
            this.TAB_Game.Controls.Add(this.LV_Game);
            this.TAB_Game.Location = new System.Drawing.Point(4, 22);
            this.TAB_Game.Name = "TAB_Game";
            this.TAB_Game.Padding = new System.Windows.Forms.Padding(3);
            this.TAB_Game.Size = new System.Drawing.Size(542, 303);
            this.TAB_Game.TabIndex = 1;
            this.TAB_Game.Text = "Game";
            this.TAB_Game.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BTN_DeleteGame);
            this.groupBox2.Controls.Add(this.BTN_EditGame);
            this.groupBox2.Controls.Add(this.BTN_AddGame);
            this.groupBox2.Location = new System.Drawing.Point(381, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(155, 113);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Change Values";
            // 
            // BTN_DeleteGame
            // 
            this.BTN_DeleteGame.Location = new System.Drawing.Point(6, 81);
            this.BTN_DeleteGame.Name = "BTN_DeleteGame";
            this.BTN_DeleteGame.Size = new System.Drawing.Size(145, 23);
            this.BTN_DeleteGame.TabIndex = 5;
            this.BTN_DeleteGame.Text = "Delete Game";
            this.BTN_DeleteGame.UseVisualStyleBackColor = true;
            this.BTN_DeleteGame.Click += new System.EventHandler(this.BTN_DeleteGame_Click);
            // 
            // BTN_EditGame
            // 
            this.BTN_EditGame.Location = new System.Drawing.Point(7, 51);
            this.BTN_EditGame.Name = "BTN_EditGame";
            this.BTN_EditGame.Size = new System.Drawing.Size(144, 24);
            this.BTN_EditGame.TabIndex = 4;
            this.BTN_EditGame.Text = "Edit Game";
            this.BTN_EditGame.UseVisualStyleBackColor = true;
            this.BTN_EditGame.Click += new System.EventHandler(this.BTN_EditGame_Click);
            // 
            // BTN_AddGame
            // 
            this.BTN_AddGame.Location = new System.Drawing.Point(7, 19);
            this.BTN_AddGame.Name = "BTN_AddGame";
            this.BTN_AddGame.Size = new System.Drawing.Size(144, 26);
            this.BTN_AddGame.TabIndex = 3;
            this.BTN_AddGame.Text = "Add Game";
            this.BTN_AddGame.UseVisualStyleBackColor = true;
            this.BTN_AddGame.Click += new System.EventHandler(this.BTN_AddGame_Click);
            // 
            // LV_Game
            // 
            this.LV_Game.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.gameId,
            this.gameName,
            this.gameGenre});
            this.LV_Game.ContextMenuStrip = this.CMS_ClickedGameListBox;
            this.LV_Game.Cursor = System.Windows.Forms.Cursors.Default;
            this.LV_Game.FullRowSelect = true;
            this.LV_Game.GridLines = true;
            this.LV_Game.Location = new System.Drawing.Point(6, 6);
            this.LV_Game.MultiSelect = false;
            this.LV_Game.Name = "LV_Game";
            this.LV_Game.Size = new System.Drawing.Size(365, 291);
            this.LV_Game.TabIndex = 0;
            this.LV_Game.UseCompatibleStateImageBehavior = false;
            this.LV_Game.View = System.Windows.Forms.View.Details;
            this.LV_Game.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LV_Game_ColumnClick);
            // 
            // gameId
            // 
            this.gameId.Text = "ID";
            // 
            // gameName
            // 
            this.gameName.Text = "Name";
            this.gameName.Width = 180;
            // 
            // gameGenre
            // 
            this.gameGenre.Text = "Genre";
            this.gameGenre.Width = 100;
            // 
            // CMS_ClickedGameListBox
            // 
            this.CMS_ClickedGameListBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSM_RefreshGame,
            this.TSM_AddGame,
            this.TSM_EditGame,
            this.TSM_DeleteGame});
            this.CMS_ClickedGameListBox.Name = "CMS_ClickedGameListBox";
            this.CMS_ClickedGameListBox.Size = new System.Drawing.Size(114, 92);
            // 
            // TSM_RefreshGame
            // 
            this.TSM_RefreshGame.Name = "TSM_RefreshGame";
            this.TSM_RefreshGame.Size = new System.Drawing.Size(113, 22);
            this.TSM_RefreshGame.Text = "Refresh";
            this.TSM_RefreshGame.Click += new System.EventHandler(this.TSM_RefreshGame_Click);
            // 
            // TSM_AddGame
            // 
            this.TSM_AddGame.Name = "TSM_AddGame";
            this.TSM_AddGame.Size = new System.Drawing.Size(113, 22);
            this.TSM_AddGame.Text = "Add";
            this.TSM_AddGame.Click += new System.EventHandler(this.TSM_AddGame_Click);
            // 
            // TSM_EditGame
            // 
            this.TSM_EditGame.Name = "TSM_EditGame";
            this.TSM_EditGame.Size = new System.Drawing.Size(113, 22);
            this.TSM_EditGame.Text = "Edit";
            this.TSM_EditGame.Click += new System.EventHandler(this.TSM_EditGame_Click);
            // 
            // TSM_DeleteGame
            // 
            this.TSM_DeleteGame.Name = "TSM_DeleteGame";
            this.TSM_DeleteGame.Size = new System.Drawing.Size(113, 22);
            this.TSM_DeleteGame.Text = "Delete";
            this.TSM_DeleteGame.Click += new System.EventHandler(this.TSM_DeleteGame_Click);
            // 
            // TAB_Genre
            // 
            this.TAB_Genre.Controls.Add(this.GB_ChangeValues);
            this.TAB_Genre.Controls.Add(this.LV_Genres);
            this.TAB_Genre.Location = new System.Drawing.Point(4, 22);
            this.TAB_Genre.Name = "TAB_Genre";
            this.TAB_Genre.Padding = new System.Windows.Forms.Padding(3);
            this.TAB_Genre.Size = new System.Drawing.Size(542, 303);
            this.TAB_Genre.TabIndex = 0;
            this.TAB_Genre.Text = "Genre";
            this.TAB_Genre.UseVisualStyleBackColor = true;
            // 
            // TSM_MenuStrip
            // 
            this.TSM_MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.TSM_MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.TSM_MenuStrip.Name = "TSM_MenuStrip";
            this.TSM_MenuStrip.Size = new System.Drawing.Size(570, 24);
            this.TSM_MenuStrip.TabIndex = 3;
            this.TSM_MenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSM_File_Refresh_All,
            this.TSM_File_Refresh_Game,
            this.TSM_File_Refresh_Genre});
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            // 
            // TSM_File_Refresh_All
            // 
            this.TSM_File_Refresh_All.Name = "TSM_File_Refresh_All";
            this.TSM_File_Refresh_All.Size = new System.Drawing.Size(105, 22);
            this.TSM_File_Refresh_All.Text = "All";
            this.TSM_File_Refresh_All.Click += new System.EventHandler(this.TSM_File_Refresh_All_Click);
            // 
            // TSM_File_Refresh_Game
            // 
            this.TSM_File_Refresh_Game.Name = "TSM_File_Refresh_Game";
            this.TSM_File_Refresh_Game.Size = new System.Drawing.Size(105, 22);
            this.TSM_File_Refresh_Game.Text = "Game";
            this.TSM_File_Refresh_Game.Click += new System.EventHandler(this.TSM_File_Refresh_Game_Click);
            // 
            // TSM_File_Refresh_Genre
            // 
            this.TSM_File_Refresh_Genre.Name = "TSM_File_Refresh_Genre";
            this.TSM_File_Refresh_Genre.Size = new System.Drawing.Size(105, 22);
            this.TSM_File_Refresh_Genre.Text = "Genre";
            this.TSM_File_Refresh_Genre.Click += new System.EventHandler(this.TSM_File_Refresh_Genre_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 360);
            this.Controls.Add(this.TSM_MenuStrip);
            this.Controls.Add(this.TC_Tabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.TSM_MenuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Game List 3.0";
            this.CMS_ClickedGenreListBox.ResumeLayout(false);
            this.GB_ChangeValues.ResumeLayout(false);
            this.TC_Tabs.ResumeLayout(false);
            this.TAB_Game.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.CMS_ClickedGameListBox.ResumeLayout(false);
            this.TAB_Genre.ResumeLayout(false);
            this.TSM_MenuStrip.ResumeLayout(false);
            this.TSM_MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView LV_Genres;
        private System.Windows.Forms.ColumnHeader idHeader;
        private System.Windows.Forms.ColumnHeader nameHeader;
        private System.Windows.Forms.ColumnHeader addictiveHeader;
        private System.Windows.Forms.Button BTN_AddGenre;
        private System.Windows.Forms.Button BTN_EditGenre;
        private System.Windows.Forms.Button BTN_DeleteGenre;
        private System.Windows.Forms.NotifyIcon NI_Notification;
        private System.Windows.Forms.GroupBox GB_ChangeValues;
        private System.Windows.Forms.TabControl TC_Tabs;
        private System.Windows.Forms.TabPage TAB_Game;
        private System.Windows.Forms.TabPage TAB_Genre;
        private System.Windows.Forms.ContextMenuStrip CMS_ClickedGenreListBox;
        private System.Windows.Forms.ToolStripMenuItem TSM_RefreshGenre;
        private System.Windows.Forms.ToolStripMenuItem TSM_AddGenre;
        private System.Windows.Forms.ToolStripMenuItem TSM_EditGenre;
        private System.Windows.Forms.ToolStripMenuItem TSM_DeleteGenre;
        private System.Windows.Forms.ListView LV_Game;
        private System.Windows.Forms.ColumnHeader gameId;
        private System.Windows.Forms.ColumnHeader gameName;
        private System.Windows.Forms.ColumnHeader gameGenre;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BTN_DeleteGame;
        private System.Windows.Forms.Button BTN_EditGame;
        private System.Windows.Forms.Button BTN_AddGame;
        private System.Windows.Forms.MenuStrip TSM_MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TSM_File_Refresh_All;
        private System.Windows.Forms.ToolStripMenuItem TSM_File_Refresh_Game;
        private System.Windows.Forms.ToolStripMenuItem TSM_File_Refresh_Genre;
        private System.Windows.Forms.ContextMenuStrip CMS_ClickedGameListBox;
        private System.Windows.Forms.ToolStripMenuItem TSM_RefreshGame;
        private System.Windows.Forms.ToolStripMenuItem TSM_AddGame;
        private System.Windows.Forms.ToolStripMenuItem TSM_EditGame;
        private System.Windows.Forms.ToolStripMenuItem TSM_DeleteGame;
    }
}

