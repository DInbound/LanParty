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

        private bool editMode;

        public EditStudentForm(bool editingMode)
        {
            InitializeComponent();

            editMode = editingMode;

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

            editMode = false;
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
            // DIS SHIT NEEDS RESTRUCTURING


            // Check if name is filled in
            if(TB_Student_Name != null && TB_Student_Name.Text.Length > 1)
            {
                // Check if game is filled in
                if (CB_Student_Game.Text.Length > 0 && CB_Student_Game.Text != null)
                {
                    // Fill in student name
                    StudentToEdit.StudentNaam = TB_Student_Name.Text;
                    // Fill in student geboorte datum
                    StudentToEdit.GeboorteDatum = DTP_Student_Geboortedatum.Value;
                    // Fill in student studiepunten
                    if (TB_Student_Studiepunten.Text.Length > 0)
                    {
                        int result;
                        if(Int32.TryParse(TB_Student_Studiepunten.Text, out result))
                        {
                            StudentToEdit.StudiePunten = result;
                        }
                        else
                        {
                            MessageBox.Show("Please fill in a correct value for 'Studiepunten'.", "No can't do!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            return;
                        }
                    }
                    else
                    {
                        StudentToEdit.StudiePunten = null;
                    }

                    if (!editMode)
                    {
                        // Check if a student is present with the same name
                        foreach (Student s in studenten)
                        {
                            if (s.StudentNaam.Equals(TB_Student_Name.Text))
                            {

                                DialogResult replaceResult = MessageBox.Show("The student '" + s.StudentNaam + "'already exists, do you wish to replace it?\nExtra information: \nGeboorte Datum: " + s.GeboorteDatum.ToString() + "\nStudiepunten: " + s.StudiePunten.ToString() + "\nGame: " + s.Game.Name, "Entry already exists", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button3);

                                // A student with the same name!

                                if (replaceResult == DialogResult.Yes)
                                {
                                    StudentToEdit.ID = s.ID;
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
                            else
                            {

                            }
                        }

                        // No student had the same name
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        return;
                    }
                    else
                    {

                    }

                    // Fill in student game
                    // If no game is present that is typed in, give a error message.
                    foreach (Game g in games)
                    {
                        if (CB_Student_Game.Text.Equals(g.Name))
                        {
                            StudentToEdit.Game = g;
                        }
                    }
                    MessageBox.Show("No game with the name could be found, please select a valid game from the list.", "Not all boxes were filled in correctly", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                else
                {
                    MessageBox.Show("Please fill in a correct game or choose one from the list.", "Not all boxes were filled in correctly", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please fill in the name of the student." , "Not all boxes were filled in correctly", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void BTN_Student_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
