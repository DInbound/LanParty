using System;
using System.Windows.Forms;
using DatabaseExample.Models;

namespace DatabaseExample
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Refreshes the listview
        /// </summary>
        public void RefreshGameListView()
        {
            games = gameController.GetAllGames();
            if (games != null)
            {
                LV_Game.Items.Clear();

                foreach (Game game in games)
                {
                    string[] subitems = { game.Name.ToString(), game.Genre.Name };
                    LV_Game.Items.Add(game.ID.ToString()).SubItems.AddRange(subitems);
                }
            }
        }

        /// <summary>
        /// Creates a dialog to add a game to the database.
        /// </summary>
        public void AddGame()
        {
            using (EditGameForm form = new EditGameForm())
            {
                DialogResult result = form.ShowDialog();

                if (result == DialogResult.OK || result == DialogResult.No)
                {
                    gameController.InsertGame(form.GameToEdit);
                    DatabaseNotification("Game successfully added.");
                    RefreshGameListView();
                }
                else if(result == DialogResult.Yes)
                {
                    gameController.GameUpdate(form.GameToEdit);
                    DatabaseNotification("Game successfully updated.");
                    RefreshGameListView();
                }
            }
        }

        /// <summary>
        /// Gets a game from the listview, returns Game object when an item is selected.
        /// </summary>
        /// <returns></returns>
        private Game GetGameFromListView()
        {
            if(LV_Game.SelectedItems.Count > 0)
            {
                ListViewItem lvitem = LV_Game.SelectedItems[0];

                foreach (Game g in games)
                {
                    if (g.ID.ToString().Equals(lvitem.Text))
                    {
                        return g;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Edit a game
        /// </summary>
        public void EditGame()
        {
            using (EditGameForm form = new EditGameForm())
            {
                Game editThis = GetGameFromListView();

                if(editThis != null)
                {
                    form.FillForm(editThis);

                    DialogResult result = form.ShowDialog();

                    if(result == DialogResult.OK)
                    {
                        gameController.GameUpdate(form.GameToEdit);
                        DatabaseNotification("Game successfully updated.");
                        RefreshGameListView();
                    }
                }
            }
        }

        /// <summary>
        /// Deletes a game from the database.)
        /// </summary>
        public void DeleteGame()
        {
            Game deleteThis = GetGameFromListView();
            
            DialogResult result = MessageBox.Show("Are you sure you want to delete '" + deleteThis.Name + "' from the database?", "Deleting item", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            if (deleteThis != null && result == DialogResult.OK)
            {
                gameController.DeleteGame(deleteThis);
                DatabaseNotification("Game successfully deleted.");
                RefreshGameListView();
            }
        }

        private void BTN_AddGame_Click(object sender, EventArgs e)
        {
            AddGame();
        }

        private void TSM_File_Refresh_Game_Click(object sender, EventArgs e)
        {
            RefreshGameListView();
        }

        private void BTN_EditGame_Click(object sender, EventArgs e)
        {
            EditGame();
        }

        private void BTN_DeleteGame_Click(object sender, EventArgs e)
        {
            DeleteGame();
        }

        private void TSM_RefreshGame_Click(object sender, EventArgs e)
        {
            RefreshGameListView();
        }

        private void TSM_AddGame_Click(object sender, EventArgs e)
        {
            AddGame();
        }

        private void TSM_EditGame_Click(object sender, EventArgs e)
        {
            EditGame();
        }

        private void TSM_DeleteGame_Click(object sender, EventArgs e)
        {
            DeleteGame();
        }
    }
}
