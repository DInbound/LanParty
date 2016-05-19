using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DatabaseExample.Database;
using DatabaseExample.Models;

namespace DatabaseExample
{
    public partial class EditStudentForm : Form
    {
        public Student StudentToEdit { get; private set; }

        private StudentController studentController;
        private GameController gameController;

        List<Game> games;
        List<Student> studenten;

        private bool adding;

        public EditStudentForm(bool addingItem)
        {
            InitializeComponent();

            adding = addingItem;

            StudentToEdit = new Student();

            this.studentController = new StudentController();
            this.gameController = new GameController();

            games = gameController.GetAllGames();
            studenten = studentController.GetAllStudenten();

            // Fill the drop down box
            foreach (Game game in games)
            {
                CB_Student_Game.Items.Add(game.Name);
            }
        }

        public void FillForm(Student student)
        {
            StudentToEdit = student;
            TB_Student_ID.Text = StudentToEdit.ID.ToString();
            TB_Student_Name.Text = StudentToEdit.StudentNaam;
            TB_Student_Studiepunten.Text = StudentToEdit.StudiePunten.ToString();
            CB_Student_Game.SelectedItem = StudentToEdit.Game.Name;
            DTP_Student_Geboortedatum.Value = StudentToEdit.GeboorteDatum;
        }


        /// <summary>
        /// Save the student to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_Student_Save_Click(object sender, EventArgs e)
        {
            // Return when something goes wrong

            // Student's name is not of the required length (at least 1 letter)
            if(TB_Student_Name == null || TB_Student_Name.Text.Length < 1)
            {
                MessageBox.Show("Please fill in the name of the student.\nThe name needs to be at least one letter long.", "Not all boxes were filled in correctly", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            else
            {
                // Set the name to the temp object
                StudentToEdit.StudentNaam = TB_Student_Name.Text;
            }

            // Check if there is no game filled in (at least 3 letters)
            if (CB_Student_Game.Text.Length < 3 || CB_Student_Game.Text == null)
            {
                MessageBox.Show("Please fill in a correct game or choose one from the list.", "Not all boxes were filled in correctly", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            else
            {
                // Refresh the list of games, maybe someone removed something?
                games = gameController.GetAllGames();

                // Make a boolean to track wheter a game has been found.

                bool foundGame = false;
                // Something is filled in, so now we check if it is an actual existing game.
                foreach (Game g in games)
                {
                    if (CB_Student_Game.Text.Equals(g.Name))
                    {
                        // Set the game to the temp object
                        StudentToEdit.Game = g;
                        foundGame = true;
                        break;
                    }
                }
                // Only execute this when no game has been found.
                if (!foundGame)
                {
                    MessageBox.Show("No game with the name could be found, please select a valid game from the list.", "Not all boxes were filled in correctly", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
            }

            // Check if geboortedatum is not empty
            if(DTP_Student_Geboortedatum == null)
            {
                MessageBox.Show("No valid date given. Please enter a valid date.", "Not all boxes were filled in correctly", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            else
            {
                // Set the geboortedatum
                StudentToEdit.GeboorteDatum = DTP_Student_Geboortedatum.Value;
            }

            // Check if studiepunten is not empty or null
            if(TB_Student_Studiepunten.Text.Length <= 0 || TB_Student_Studiepunten.Text == null)
            {
                StudentToEdit.StudiePunten = null;
            }
            else
            {
                int result;
                if (Int32.TryParse(TB_Student_Studiepunten.Text, out result) && result > 0)
                {
                    StudentToEdit.StudiePunten = result;
                }
                else
                {
                    MessageBox.Show("Please fill in a correct value for 'Studiepunten'.", "No can't do!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
            }

            // Check if the screen is in add mode, then it needs to replace the student id with an existing one.
            if (adding)
            {
                // A boolean to keep track if a student has been found
                bool foundStudent = false;
                
                // Not edit mode, need some more checks
                // Check if there is a student present with the same name
                foreach (Student s in studenten)
                {
                    if (s.StudentNaam.Equals(TB_Student_Name.Text))
                    {
                        // A student with the same name!
                        // Throw some text at the user
                        DialogResult replaceResult = MessageBox.Show("The student '" + s.StudentNaam + "'already exists, do you wish to replace it?\nExtra information: \nGeboorte Datum: " + s.GeboorteDatum.ToString() + "\nStudiepunten: " + s.StudiePunten.ToString() + "\nGame: " + s.Game.Name, "Entry already exists", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button3);

                        // User wants to replace the existing student with the new student. (DialogResult = YES)
                        if (replaceResult == DialogResult.Yes)
                        {
                            StudentToEdit.ID = s.ID;
                            this.DialogResult = DialogResult.Yes;
                            foundStudent = true;
                            break;
                        }
                        // User wants to make a new student (DialogResult = NO)
                        else if (replaceResult == DialogResult.No)
                        {
                            this.DialogResult = DialogResult.No;
                            foundStudent = true;
                            break;
                        }
                        
                        // User pressed X or Cancel. Return to Edit student form.
                        return;
                    }
                }

                // No student had the same name (DialogResult = NO)
                if (!foundStudent)
                {
                    // Say NO so the uploader will handle this as a new entry.
                    this.DialogResult = DialogResult.No;
                }
            }
            else
            {
                // Set the dialog result to yes, so the form wil recognise an edit.
                this.DialogResult = DialogResult.Yes;
            }

            // End of all the checks
            this.Close();
            return;
        }

        private void BTN_Student_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
