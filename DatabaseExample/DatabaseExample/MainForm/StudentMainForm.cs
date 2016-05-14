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
        public void RefreshStudentListView()
        {
            studenten = studentController.GetAllStudenten();
            if(studenten != null)
            {
                LV_Student.Items.Clear();

                foreach (Student s in studenten)
                {
                    string[] subitems = { s.StudentNaam.ToString(), s.GeboorteDatum.ToString(), s.StudiePunten.ToString(), s.Game.Name };
                    LV_Student.Items.Add(s.ID.ToString()).SubItems.AddRange(subitems);
                }
            }
        }

        /// <summary>
        /// Creates a dialog to add a student to the database.
        /// </summary>
        public void AddStudent()
        {
            using (EditStudentForm form = new EditStudentForm())
            {
                DialogResult result = form.ShowDialog();

                if (result == DialogResult.OK || result == DialogResult.No)
                {
                    studentController.InsertStudent(form.StudentToEdit);
                    DatabaseNotification("Student successfully added.");
                    RefreshStudentListView();
                }
                else if (result == DialogResult.Yes)
                {
                    studentController.StudentUpdate(form.StudentToEdit);
                    DatabaseNotification("Student successfully updated");
                    RefreshStudentListView();
                }
            }
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshStudentListView();
        }

        private void BTN_Student_Add_Click(object sender, EventArgs e)
        {
            AddStudent();
        }
    }
}
