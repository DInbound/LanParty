using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DatabaseExample.Database;
using DatabaseExample.Models;

namespace DatabaseExample
{
    public partial class EditGameForm : Form
    {
        public Game GameToEdit { get; private set; }

        private GameController gameController;
        private GenreController genreController;

        List<Genre> genres;

        public EditGameForm()
        {
            InitializeComponent();

            GameToEdit = new Game();

            this.gameController = new GameController();
            this.genreController = new GenreController();

            genres = genreController.GetAllGenres();

            // Fill the drop down box
            foreach (Genre genre in genres)
            {
                CB_Game_Genre.Items.Add(genre.Name);
            }
        }

        public void FillForm(Game game)
        {
            GameToEdit = game;
            TB_Game_Id.Text = GameToEdit.ID.ToString();
            TB_Game_Name.Text = GameToEdit.Name;
            CB_Game_Genre.SelectedItem = GameToEdit.Genre.Name;
        }

        private void BTN_Game_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTN_Game_Save_Click(object sender, EventArgs e)
        {
            if (TB_Game_Name.Text.Length >= 0 && TB_Game_Name.Text != null)
            {
                if (CB_Game_Genre.Text != null && CB_Game_Genre.Text.Length >= 3)
                {
                    GameToEdit.Name = TB_Game_Name.Text;

                    // Get the genre object from the list of genres
                    foreach (Genre gen in genres)
                    {
                        if (CB_Game_Genre.Text.Equals(gen.Name))
                        {
                            GameToEdit.Genre = gen;
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                            return;
                        }
                    }
                }

                MessageBox.Show("Please fill in a correct genre, or select it from the list.");
                return;
            }
            else
            {
                MessageBox.Show("Please name the game.");
            }
        }
    }
}
