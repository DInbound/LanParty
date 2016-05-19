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
            using (EditStudentForm form = new EditStudentForm(false))
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

        /// <summary>
        /// Gets a student from the listview.
        /// </summary>
        /// <returns>Returns the object of the item.</returns>
        private Student GetStudentFromListView()
        {
            if(LV_Student.SelectedItems.Count > 0)
            {
                ListViewItem lvitem = LV_Student.SelectedItems[0];

                foreach (Student s in studenten)
                {
                    if (s.ID.ToString().Equals(lvitem.Text))
                    {
                        return s;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Edit a student
        /// </summary>
        public void EditStudent()
        {
            using (EditStudentForm form = new EditStudentForm(true))
            {
                Student editThis = GetStudentFromListView();

                if(editThis != null)
                {
                    form.FillForm(editThis);

                    DialogResult result = form.ShowDialog();

                    if(result == DialogResult.OK || result == DialogResult.Yes)
                    {
                        studentController.StudentUpdate(form.StudentToEdit);
                        DatabaseNotification("Student successfully updated.");
                        RefreshStudentListView();
                    }
                }
            }
        }

        /// <summary>
        /// Delete a student from the database
        /// </summary>
        public void DeleteStudent()
        {
            Student deleteThis = GetStudentFromListView();

            DialogResult result = MessageBox.Show("Are you sure you want to delete '" + deleteThis.StudentNaam + "' from the database?", "Deleting item", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            if (deleteThis != null && result == DialogResult.OK)
            {
                studentController.DeleteStudent(deleteThis);
                DatabaseNotification("Stdudent successfully deleted.");
                RefreshStudentListView();
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

        private void BTN_Student_Edit_Click(object sender, EventArgs e)
        {
            EditStudent();
        }

        private void BTN_Student_Delete_Click(object sender, EventArgs e)
        {
            DeleteStudent();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteStudent();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditStudent();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudent();
        }

        private void refreshToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RefreshStudentListView();
        }
    }
}
