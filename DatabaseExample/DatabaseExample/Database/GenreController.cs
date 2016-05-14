using System;
using System.Collections.Generic;
using DatabaseExample.Models;
using MySql.Data.MySqlClient;

namespace DatabaseExample.Database
{
    public class GenreController : DatabaseController
    {
        /// <summary>
        /// Insert a genre into the database
        /// </summary>
        /// <param name="genre">The genre to insert</param>
        /// <returns>Returns TRUE when the genre has been successfully inserted</returns>
        public bool InsertGenre(Genre genre)
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
            string insertQuery = @"INSERT INTO genre (genrenaam, verslavend) VALUES (@genrenaam, @verslavend)";

            MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
            MySqlParameter genreParam = new MySqlParameter("@genrenaam", MySqlDbType.VarChar);
            MySqlParameter verslavendParam = new MySqlParameter("@verslavend", MySqlDbType.Bit);

            genreParam.Value = genre.Name;
            verslavendParam.Value = genre.Verslavend;

            cmd.Parameters.Add(genreParam);
            cmd.Parameters.Add(verslavendParam);

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
                conn.Close();
                System.Windows.Forms.MessageBox.Show("Could not commit changes.\n" + ex, "Database Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }

            conn.Close();
            return true;
        }

        /// <summary>
        /// Updates a given genre
        /// </summary>
        /// <returns></returns>
        public bool GenreUpdate(Genre genre)
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
            string updateQuery = @"UPDATE genre SET genrenaam = @genrenaam, verslavend = @verslavend WHERE genre_id = @ID";

            MySqlCommand cmd = new MySqlCommand(updateQuery, conn);
            MySqlParameter idParam = new MySqlParameter("@ID", MySqlDbType.Int32);
            MySqlParameter genreParam = new MySqlParameter("@genrenaam", MySqlDbType.VarChar);
            MySqlParameter verslavendParam = new MySqlParameter("@verslavend", MySqlDbType.Bit);

            idParam.Value = genre.ID;
            genreParam.Value = genre.Name;
            verslavendParam.Value = genre.Verslavend;

            cmd.Parameters.Add(idParam);
            cmd.Parameters.Add(genreParam);
            cmd.Parameters.Add(verslavendParam);

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
                conn.Close();
                return false;
            }

            conn.Close();
            return true;
        }

        /// <summary>
        /// Get all the genres from the database
        /// </summary>
        /// <returns>A List containing all the genres from the database</returns>
        public List<Genre> GetAllGenres()
        {
            List<Genre> genres = new List<Genre>();

            try
            {
                conn.Open();

                string selectQuery = @"SELECT * FROM genre";
                MySqlCommand cmd = new MySqlCommand(selectQuery, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    int genreId = dataReader.GetInt32("genre_id");
                    string genreNaam = dataReader.GetString("genrenaam");
                    bool verslavend = dataReader.GetBoolean("verslavend");
                    Genre genre = new Genre { ID = genreId, Name = genreNaam, Verslavend = verslavend};

                    genres.Add(genre);
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

            return genres;
        }

        /// <summary>
        /// Returns a single genre when given the id of the genre.
        /// </summary>
        /// <param name="id">ID of the genre</param>
        /// <returns></returns>
        public Genre GetGenreWithID(int id)
        {
            Genre genre = null;

            try
            {
                conn.Open();

                string selectQuery = @"SELECT * FROM genre WHERE genre_id = @genre_id";

                MySqlCommand cmd = new MySqlCommand(selectQuery, conn);

                MySqlParameter idParam = new MySqlParameter("@genre_id", MySqlDbType.Int32);

                idParam.Value = id;

                cmd.Parameters.Add(idParam);

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    string genreNaam = dataReader.GetString("genrenaam");
                    int genreId = dataReader.GetInt32("genre_id");
                    bool verslavend = dataReader.GetBoolean("verslavend");
                    genre = new Genre { ID = genreId, Name = genreNaam, Verslavend = verslavend };
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

            return genre;
        }

        /// <summary>
        /// Deletes a genre
        /// Returns TRUE when the genre has been successfully deleted.
        /// </summary>
        /// <param name="genre">Specify the genre to delete.</param>
        /// <returns>Returns TRUE when deleting has succeded.</returns>
        public bool DeleteGenre(Genre genre)
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
                string deleteQuery = @"DELETE FROM genre WHERE genre_id = @genre_id";
                
                MySqlCommand cmd = new MySqlCommand(deleteQuery, conn);
                MySqlParameter genre_idParam = new MySqlParameter("@genre_id", MySqlDbType.Int32);

                genre_idParam.Value = genre.ID;

                cmd.Parameters.Add(genre_idParam);

                cmd.Prepare();

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                trans.Rollback();

                if(ex.Message.Contains("foreign key constraint fails"))
                {
                    System.Windows.Forms.MessageBox.Show("Could not delete because '" + genre.Name + "' is being used by a game.", "Could not delete", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation, System.Windows.Forms.MessageBoxDefaultButton.Button1);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Failed to execute query.\n" + ex, "Database Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
                conn.Close();
                return false;
            }

            try
            {
                trans.Commit();
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Failed to commit changes.\n" + ex, "Database Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }
    }
}
