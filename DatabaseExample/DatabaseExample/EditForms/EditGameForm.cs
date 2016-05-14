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
        List<Game> games;

        public EditGameForm()
        {
            InitializeComponent();

            GameToEdit = new Game();

            this.gameController = new GameController();
            this.genreController = new GenreController();

            genres = genreController.GetAllGenres();
            games = gameController.GetAllGames();

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

        /// <summary>
        /// Save game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_Game_Save_Click(object sender, EventArgs e)
        {
            // Check if a name is filled in for the game
            if (TB_Game_Name.Text.Length > 0 && TB_Game_Name.Text != null)
            { 
                // Check if the genre is not empty or a valid value;
                if (CB_Game_Genre.Text != null && CB_Game_Genre.Text.Length >= 3)
                {
                    GameToEdit.Name = TB_Game_Name.Text;

                    // Get the genre object from the list of genres
                    foreach (Genre gen in genres)
                    {
                        if (CB_Game_Genre.Text.Equals(gen.Name))
                        {
                            GameToEdit.Genre = gen;
                            break;
                        }
                    }

                    // Check if a game is present with the same name
                    foreach (Game g in games)
                    {
                        if (g.Name.Equals(TB_Game_Name.Text))
                        {
                            // A game is present with the same name!
                            DialogResult replaceResult = MessageBox.Show("The game '" + g.Name + "'already exists, do you wish to replace it?", "Entry already exists", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button3);

                            if(replaceResult == DialogResult.Yes)
                            {
                                GameToEdit.ID = g.ID;
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


                    // No game had the same name
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
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
