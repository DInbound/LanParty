using System;
using System.Collections.Generic;
using DatabaseExample.Models;
using MySql.Data.MySqlClient;

namespace DatabaseExample.Database
{
    class StudentController : DatabaseController
    {
        /*
            CRUD
            - Create
            - Rename
            - Update
            - Delete
        */

        public bool InsertStudent(Student student)
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
            string insertQuery = @"INSERT INTO student (studentnaam, geboortedatum, studiepunten, game_id) VALUES (@studentnaam, @geboortedatum, @studiepunten, @game_id)";

            MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
            MySqlParameter studentnaamParam = new MySqlParameter("@studentnaam", MySqlDbType.VarChar);
            MySqlParameter geboortedatumParam = new MySqlParameter("@geboortedatum", MySqlDbType.DateTime);
            MySqlParameter studiepuntenParam = new MySqlParameter("@studiepunten", MySqlDbType.Int32);
            MySqlParameter game_idParam = new MySqlParameter("@game_id", MySqlDbType.Int32);

            studentnaamParam.Value = student.StudentNaam;
            geboortedatumParam.Value = student.GeboorteDatum;
            studiepuntenParam.Value = student.StudiePunten;
            game_idParam.Value = student.Game.ID;

            cmd.Parameters.Add(studentnaamParam);
            cmd.Parameters.Add(geboortedatumParam);
            cmd.Parameters.Add(studiepuntenParam);
            cmd.Parameters.Add(game_idParam);

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
        /// Updates a given student
        /// </summary>
        /// <returns>Returns TRUE when the update has succeeded.</returns>
        public bool StudentUpdate(Student student)
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
            string updateQuery = @"UPDATE student SET studentnaam = @studentnaam, geboortedatum = @geboortedatum, studiepunten = @studiepunten, game_id = @game_id WHERE student_id = @student_id";

            // Create new command
            MySqlCommand cmd = new MySqlCommand(updateQuery, conn);

            // Create parameters
            MySqlParameter studentID = new MySqlParameter("@student_id", MySqlDbType.Int32);
            MySqlParameter studentnaamParam = new MySqlParameter("@studentnaam", MySqlDbType.VarChar);
            MySqlParameter geboortedatumParam = new MySqlParameter("@geboortedatum", MySqlDbType.DateTime);
            MySqlParameter studiepuntenParam = new MySqlParameter("@studiepunten", MySqlDbType.Int32);
            MySqlParameter game_idParam = new MySqlParameter("@game_id", MySqlDbType.Int32);

            // Set Values
            studentID.Value = student.ID;
            studentnaamParam.Value = student.StudentNaam;
            geboortedatumParam.Value = student.GeboorteDatum;
            studiepuntenParam.Value = student.StudiePunten;
            game_idParam.Value = student.Game.ID;

            // Add Parameters
            cmd.Parameters.Add(studentID);
            cmd.Parameters.Add(studentnaamParam);
            cmd.Parameters.Add(geboortedatumParam);
            cmd.Parameters.Add(studiepuntenParam);
            cmd.Parameters.Add(game_idParam);

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
        /// Get all the Studenten from the database
        /// </summary>
        /// <returns>A List containing all studenten from the database or null when failed</returns>
        public List<Student> GetAllStudenten()
        {
            List<Student> studenten = new List<Student>();

            try
            {
                conn.Open();

                string selectQuery = @"SELECT * FROM student";
                MySqlCommand cmd = new MySqlCommand(selectQuery, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    int studentId = dataReader.GetInt32("student_id");
                    string studentNaam = dataReader.GetString("studentnaam");
                    DateTime geboorteDatum = dataReader.GetDateTime("geboortedatum");
                    int gameId = dataReader.GetInt32("game_id");

                    // Get the game for the student
                    GameController gc = new GameController();
                    Game g = gc.GetGameWithID(gameId);

                    Student stud = new Student { ID = studentId, StudentNaam = studentNaam, GeboorteDatum = geboorteDatum, Game = g };
                    
                    // Studiepunten can be NULL
                    if (dataReader.IsDBNull(dataReader.GetOrdinal("studiepunten")))
                        stud.StudiePunten = null;
                    else
                        stud.StudiePunten = dataReader.GetInt32("studiepunten");

                    // Dis shite be broke yo.
                    //stud.StudiePunten = dataReader.IsDBNull(dataReader.GetOrdinal("studiepunten")) ? (int?)null : dataReader.GetInt32("studiepunten");

                    studenten.Add(stud);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Ophalen van studenten mislukt.\n" + ex, "Database Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                conn.Close();
            }

            return studenten;
        }

        /// <summary>
        /// Returns a single student with the given ID.
        /// </summary>
        /// <param name="id">ID of the student</param>
        /// <returns>Returns a student or NULL when something has broken</returns>
        public Student GetStudentWithID(int id)
        {
            Student student = null;

            try
            {
                conn.Open();

                string selectQuery = @"SELECT * FROM student WHERE student_id = @student_id";

                MySqlCommand cmd = new MySqlCommand(selectQuery, conn);

                MySqlParameter idParam = new MySqlParameter("@game_id", MySqlDbType.Int32);

                idParam.Value = id;

                cmd.Parameters.Add(idParam);

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    int studentId = dataReader.GetInt32("student_id");
                    string studentNaam = dataReader.GetString("studentnaam");
                    DateTime geboorteDatum = dataReader.GetDateTime("geboortedatum");
                    int studiepunten = dataReader.GetInt32("studiepunten");
                    int gameId = dataReader.GetInt32("game_id");

                    // Get the game for the student
                    GameController gc = new GameController();
                    Game g = gc.GetGameWithID(gameId);

                    student = new Student { ID = studentId, StudentNaam = studentNaam, GeboorteDatum = geboorteDatum, StudiePunten = studiepunten, Game = g };
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Ophalen van student mislukt.\n" + ex, "Database Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                conn.Close();
            }

            return student;
        }

        /// <summary>
        /// Deletes a student
        /// </summary>
        /// <param name="student">Specify the student to delete.</param>
        /// <returns>Returns TRUE when he student has been successfully deleted.</returns>
        public bool DeleteStudent(Student student)
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
                string deleteQuery = @"DELETE FROM student WHERE student_id = @student_id";

                MySqlCommand cmd = new MySqlCommand(deleteQuery, conn);
                MySqlParameter student_idParam = new MySqlParameter("@student_id", MySqlDbType.Int32);

                student_idParam.Value = student.ID;

                cmd.Parameters.Add(student_idParam);

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