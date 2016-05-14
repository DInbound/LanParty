using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DatabaseExample.Database;
using DatabaseExample.Models;

namespace DatabaseExample
{
    public partial class MainForm : Form
    {
        private GenreController genreController;
        private GameController gameController;
        private StudentController studentController;

        private List<Genre> genres;
        private List<Game> games;
        private List<Student> studenten;

        private ListViewColumnSorter lvColumnSorter;

        public MainForm()
        {
            InitializeComponent();

            // Initialize Game Tab
            gameController = new GameController();
            games = gameController.GetAllGames();

            // Initialize Genre Tab
            genreController = new GenreController();
            genres = genreController.GetAllGenres();

            // Initialize Student Tab
            studentController = new StudentController();
            studenten = studentController.GetAllStudenten();

            // Create Sorter
            //lvColumnSorter = new ListViewColumnSorter();

            // Set Sorter
            LV_Genre.ListViewItemSorter = lvColumnSorter;
            LV_Game.ListViewItemSorter = lvColumnSorter;

            // Fill Lists
            RefreshGameListView();
            RefreshGenreListView();
            RefreshStudentListView();
        }

        // This code is for sorting columns
        #region Sorting
        private void LV_Genres_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lvColumnSorter != null)
            {
                if (e.Column == lvColumnSorter.SortColumn)
                {
                    // Reverse the current sort direction for this column.
                    if (lvColumnSorter.Order == SortOrder.Ascending)
                    {
                        lvColumnSorter.Order = SortOrder.Descending;
                    }
                    else
                    {
                        lvColumnSorter.Order = SortOrder.Ascending;
                    }
                }
                else
                {
                    // Set the column number that is to be sorted; default to ascending.
                    lvColumnSorter.SortColumn = e.Column;
                    lvColumnSorter.Order = SortOrder.Ascending;
                }

                LV_Genre.Sort();
            }
        }

        private void LV_Game_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lvColumnSorter != null)
            {
                if (e.Column == lvColumnSorter.SortColumn)
                {
                    // Reverse the current sort direction for this column.
                    if (lvColumnSorter.Order == SortOrder.Ascending)
                    {
                        lvColumnSorter.Order = SortOrder.Descending;
                    }
                    else
                    {
                        lvColumnSorter.Order = SortOrder.Ascending;
                    }
                }
                else
                {
                    // Set the column number that is to be sorted; default to ascending.
                    lvColumnSorter.SortColumn = e.Column;
                    lvColumnSorter.Order = SortOrder.Ascending;
                }

                LV_Game.Sort();
            }
        }
        #endregion

        public void DatabaseNotification(string text)
        {
            NI_Notification.ShowBalloonTip(1000, "Database Updated", text, ToolTipIcon.None);
        }

        private void TSM_File_Refresh_All_Click(object sender, EventArgs e)
        {
            RefreshGameListView();
            RefreshGenreListView();
            RefreshStudentListView();
        }
    }
}
