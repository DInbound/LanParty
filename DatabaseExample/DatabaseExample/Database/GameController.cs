using System;
using System.Collections.Generic;
using DatabaseExample.Models;
using MySql.Data.MySqlClient;

namespace DatabaseExample.Database
{
    public class GameController : DatabaseController
    {
        //CRUD functions for the Game
        // C = Create
        // R = Rename
        // U = Update
        // D = Delete

        /// <summary>
        /// Inserts a game into the database.
        /// </summary>
        /// <param name="game">The game to insert.</param>
        public void InsertGame(Game game)
        {
            MySqlTransaction trans = null;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                conn.Close();
                System.Windows.Forms.MessageBox.Show("Could not connect to server.\n" + ex, "Database Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return;
            }

            // Start a transaction
            trans = conn.BeginTransaction();

            // Make Query
            string insertQuery = @"INSERT INTO lanparty.game (gamenaam, genre_id) VALUES (@gamenaam, @genre)";

            // Create command
            MySqlCommand cmd = new MySqlCommand(insertQuery, conn);

            // Create Parameters
            MySqlParameter naamParam = new MySqlParameter("@gamenaam", MySqlDbType.VarChar);
            MySqlParameter genreParam = new MySqlParameter("@genre", MySqlDbType.Int32);

            // Add values to parameters
            naamParam.Value = game.Name;
            genreParam.Value = game.Genre.ID;

            // Add parameters to command
            cmd.Parameters.Add(naamParam);
            cmd.Parameters.Add(genreParam);

            // Prepare command
            try
            {
                cmd.Prepare();
            }
            catch (Exception ex)
            {
                conn.Close();
                System.Windows.Forms.MessageBox.Show("Could not prepare command.\n" + ex, "Database Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return;
            }

            // Execute command
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                conn.Close();
                System.Windows.Forms.MessageBox.Show("Could not execute query.\n" + ex, "Database Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return;
            }

            // Commit changes
            try
            {
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                System.Windows.Forms.MessageBox.Show("Could not commit changes.\n" + ex, "Database Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            return;
        }

        /// <summary>
        /// Updates a given genre
        /// </summary>
        /// <returns>Returns true when update is successfully applied.</returns>
        public bool GameUpdate(Game game)
        {
            MySqlTransaction trans = null;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                conn.Close();
                System.Windows.Forms.MessageBox.Show("Could not connect to server.\n" + ex, "Database Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }

            trans = conn.BeginTransaction();

            // Query
            string updateQuery = @"UPDATE game SET gamenaam = @gamenaam, genre_id = @genre WHERE game_id = @ID";

            // Create new command
            MySqlCommand cmd = new MySqlCommand(updateQuery, conn);

            // Create parameters
            MySqlParameter idParam = new MySqlParameter("@ID", MySqlDbType.Int32);
            MySqlParameter gameParam = new MySqlParameter("@gamenaam", MySqlDbType.VarChar);
            MySqlParameter genreParam = new MySqlParameter("@genre", MySqlDbType.Bit);

            idParam.Value = game.ID;
            gameParam.Value = game.Name;
            genreParam.Value = game.Genre.ID;

            cmd.Parameters.Add(idParam);
            cmd.Parameters.Add(gameParam);
            cmd.Parameters.Add(genreParam);

            try
            {
                cmd.Prepare();
            }
            catch (Exception ex)
            {
                conn.Close();
                System.Windows.Forms.MessageBox.Show("Could not prepare command.\n" + ex, "Database Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                conn.Close();
                System.Windows.Forms.MessageBox.Show("Could not execute query.\n" + ex, "Database Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }

            try
            {
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                System.Windows.Forms.MessageBox.Show("Could not commit changes.\n" + ex, "Database Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }

        /// <summary>
        /// Get all the games from the database
        /// </summary>
        /// <returns>A List containing all the games from the database</returns>
        public List<Game> GetAllGames()
        {
            List<Game> games = new List<Game>();

            try
            {
                conn.Open();

                string selectQuery = @"SELECT * FROM game";
                MySqlCommand cmd = new MySqlCommand(selectQuery, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    int gameId = dataReader.GetInt32("game_id");
                    string gameNaam = dataReader.GetString("gameNaam");
                    int genreId = dataReader.GetInt32("genre_id");

                    // Get the genre for the game
                    GenreController gc = new GenreController();
                    Genre genre = gc.GetGenreWithID(genreId);

                    Game game = new Game { ID = gameId, Name = gameNaam, Genre = genre };

                    games.Add(game);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Ophalen van games mislukt.\n" + ex, "Database Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                conn.Close();
            }

            return games;
        }

        /// <summary>
        /// Returns a single genre when given the id of the game.
        /// </summary>
        /// <param name="id">ID of the game</param>
        /// <returns></returns>
        public Game GetGameWithID(int id)
        {
            Game game = null;

            try
            {
                conn.Open();

                string selectQuery = @"SELECT * FROM game WHERE game_id = @game_id";

                MySqlCommand cmd = new MySqlCommand(selectQuery, conn);

                MySqlParameter idParam = new MySqlParameter("@game_id", MySqlDbType.Int32);

                idParam.Value = game.Name;

                cmd.Parameters.Add(idParam);

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    int gameId = dataReader.GetInt32("game_id");
                    string gameNaam = dataReader.GetString("gamenaam");
                    int genreId = dataReader.GetInt32("genre_id");

                    // Get the genre for the game
                    GenreController gc = new GenreController();
                    Genre genre = gc.GetGenreWithID(genreId);

                    game = new Game { ID = gameId, Name = gameNaam, Genre = genre };
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Ophalen van genres mislukt.\n" + ex, "Database Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                conn.Close();
            }

            return game;
        }

        /// <summary>
        /// Deletes a game
        /// Returns TRUE when the game has been successfully deleted.
        /// </summary>
        /// <param name="game">Specify the game to delete.</param>
        /// <returns>Returns TRUE when deleting has succeded.</returns>
        public bool DeleteGame(Game game)
        {
            MySqlTransaction trans = null;

            // Try to connect to a database
            try
            {
                conn.Open();
            }
            catch (Exception up)
            {
                System.Windows.Forms.MessageBox.Show("Failed to connect to server.\n" + up, "Database Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }

            try
            {
                trans = conn.BeginTransaction();
                string deleteQuery = @"DELETE FROM game WHERE gamenaam = @gamenaam";

                MySqlCommand cmd = new MySqlCommand(deleteQuery, conn);
                MySqlParameter naamParam = new MySqlParameter("@gamenaam", MySqlDbType.VarChar);

                naamParam.Value = game.Name;

                cmd.Parameters.Add(naamParam);

                cmd.Prepare();

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                System.Windows.Forms.MessageBox.Show("Failed to execute query.\n" + ex, "Database Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }

            try
            {
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                System.Windows.Forms.MessageBox.Show("Failed to commit changes.\n" + ex, "Database Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                conn.Close();
                return false;
            }

            conn.Close();
            return true;
        }
    }
}
