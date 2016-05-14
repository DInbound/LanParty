using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DatabaseExample.Database;
using DatabaseExample.Models;

namespace DatabaseExample
{
    public partial class EditGenreForm : Form
    {
        public Genre GenreToEdit { get; private set; }

        private GenreController genreController;

        List<Genre> genres;

        public EditGenreForm()
        {
            InitializeComponent();

            GenreToEdit = new Genre();
            this.genreController = new GenreController();
            genres = genreController.GetAllGenres();
        }

        public void FillForm(Genre gen)
        {
            GenreToEdit = gen;
            TB_Genre_ID.Text = GenreToEdit.ID.ToString();
            TB_Genre_Name.Text = GenreToEdit.Name;
            CB_Genre_Addictive.Checked = GenreToEdit.Verslavend;
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            // Check if a name is filled in for the genre
            if(TB_Genre_Name.Text.Length >= 3 && TB_Genre_Name.Text != null)
            {
                // Set name and if the genre is verslavend for the output
                GenreToEdit.Name = TB_Genre_Name.Text;
                GenreToEdit.Verslavend = CB_Genre_Addictive.Checked;

                // Check if a genre had the same name
                foreach (Genre g in genres)
                {
                    if (g.Name.Equals(TB_Genre_Name.Text))
                    {
                        // A genre is present with the same name!
                        DialogResult replaceResult = MessageBox.Show("The genre '" + g.Name + "'already exists, do you wish to replace it?", "Entry already exists", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button3);

                        if (replaceResult == DialogResult.Yes)
                        {
                            GenreToEdit.ID = g.ID;
                            this.DialogResult = DialogResult.Yes;
                            this.Close();
                            return;
                        }
                        else if (replaceResult == DialogResult.No)
                        {
                            this.DialogResult = DialogResult.No;
                            this.Close();
                            return;
                        }
                        else
                        {
                            return;
                        }
                    }
                }

                // No genre that had the same name
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }
            else
            {
                MessageBox.Show("Name of the genre should be at least three (3) letters long", "Not all boxes were filled in correctly", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        //Close the form
        private void BTN_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
