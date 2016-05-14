using System;
using System.Windows.Forms;
using DatabaseExample.Models;

namespace DatabaseExample
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Refreshes the listvieuwbox to match the database's contents.
        /// </summary>
        public void RefreshGenreListView()
        {
            genres = genreController.GetAllGenres();
            if (genres != null)
            {
                LV_Genre.Items.Clear();

                foreach (Genre gen in genres)
                {
                    string[] subitems = { gen.Name.ToString(), gen.Verslavend.ToString() };
                    LV_Genre.Items.Add(gen.ID.ToString()).SubItems.AddRange(subitems);
                }
            }
        }

        /// <summary>
        /// Creates a dialog to add a genre to the database.
        /// </summary>
        public void AddGenre()
        {
            using (EditGenreForm form = new EditGenreForm())
            {
                DialogResult result = form.ShowDialog();

                if (result == DialogResult.OK || result == DialogResult.No)
                {
                    genreController.InsertGenre(form.GenreToEdit);
                    //MessageBox.Show("Genre successfully added.", "Database Update", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    DatabaseNotification("Genre successfully added.");
                    RefreshGenreListView();
                }
                else if (result == DialogResult.Yes)
                {
                    genreController.GenreUpdate(form.GenreToEdit);
                    DatabaseNotification("Genre successfully updated.");
                    RefreshGenreListView();
                }
            }
        }

        /// <summary>
        /// Gets a genre from the listview
        /// </summary>
        /// <returns>Returns genre with the same id as the listview.</returns>
        private Genre GetGenreFromListView()
        {
            if (LV_Genre.SelectedItems.Count > 0)
            {
                ListViewItem lvitem = LV_Genre.SelectedItems[0];

                foreach (Genre gen in genres)
                {
                    if (gen.ID.ToString().Equals(lvitem.Text))
                    {
                        return gen;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Creates a dialog to edit the currently  selected genre in the listview and upload changes to the database.
        /// </summary>
        public void EditGenre()
        {
            using (EditGenreForm form = new EditGenreForm())
            {
                Genre editThis = GetGenreFromListView();

                if (editThis != null)
                {
                    form.FillForm(editThis);

                    var result = form.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        genreController.GenreUpdate(form.GenreToEdit);
                        //MessageBox.Show("Genre successfully updated.", "Database Update", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        DatabaseNotification("Genre successfully updated.");
                        RefreshGenreListView();
                    }
                }
            }
        }

        /// <summary>
        /// Deletes the currently selected genre from the database, gives a warning message first.
        /// </summary>
        public void DeleteGenre()
        {
            Genre deleteThis = GetGenreFromListView();

            if (deleteThis != null)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete '" + deleteThis.Name + "' from the database?", "Deleting item", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.OK)
                {
                    genreController.DeleteGenre(deleteThis);
                    //MessageBox.Show("Genre successfully deleted.", "Database Update", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    DatabaseNotification("Genre successfully deleted");
                    RefreshGenreListView();
                }
            }
        }

        private void BTN_AddGenre_Click(object sender, EventArgs e)
        {
            AddGenre();
        }

        private void TSM_AddGenre_Click(object sender, EventArgs e)
        {
            AddGenre();
        }

        private void TSM_RefreshGenre_Click(object sender, EventArgs e)
        {
            RefreshGenreListView();
        }

        private void TSM_File_Refresh_Genre_Click(object sender, EventArgs e)
        {
            RefreshGenreListView();
        }

        private void BTN_Edit_Click(object sender, EventArgs e)
        {
            EditGenre();
        }

        private void TSM_EditGenre_Click(object sender, EventArgs e)
        {
            EditGenre();
        }

        private void BTN_Delete_Click(object sender, EventArgs e)
        {
            DeleteGenre();
        }

        private void TSM_Delete_Click(object sender, EventArgs e)
        {
            DeleteGenre();
        }
    }
}
