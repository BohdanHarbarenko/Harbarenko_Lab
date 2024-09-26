using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace student_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripMenuItemHelp_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripMenuItemInfo_Click(object sender, EventArgs e)
        {
            Form_stdnt_info secondForm = new Form_stdnt_info();
            secondForm.StartPosition = FormStartPosition.CenterScreen;
            secondForm.Show();
        }

        private void toolStripMenuItemAboutAuthor_Click(object sender, EventArgs e)
        {
            Form_stdnt_AbAuth FormObAvt = new Form_stdnt_AbAuth();
            FormObAvt.StartPosition = FormStartPosition.CenterScreen;
            FormObAvt.Show();
        }

        private void studentBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.studentBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.harbarenko_student_DBDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'harbarenko_student_DBDataSet.student_marks' table. You can move, or remove it, as needed.
            this.student_marksTableAdapter.Fill(this.harbarenko_student_DBDataSet.student_marks);
            // TODO: This line of code loads data into the 'harbarenko_student_DBDataSet.student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.harbarenko_student_DBDataSet.student);
            student_marksBindingNavigator.Visible = false;
            studentBindingNavigator.Visible = false;
            studentDataGridView.Visible = false;
            student_marksDataGridView.Visible = false;
        }

        private void toolStripMenuItemStudents_Click(object sender, EventArgs e)
        {
            student_marksDataGridView.Visible = false;
            studentDataGridView.Visible = true;
            studentBindingNavigator.Visible = true;
            student_marksBindingNavigator.Visible = false;
            labelInf.Text = "Студенти";
            this.Validate();
            this.studentBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.harbarenko_student_DBDataSet);
            textBoxKilZap.Text = studentBindingSource.Count.ToString();
        }

        private void studentDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            studentTableAdapter.Update(harbarenko_student_DBDataSet);
            textBoxKilZap.Text = studentBindingSource.Count.ToString();

        }

        private void studentDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            studentTableAdapter.Update(harbarenko_student_DBDataSet);
            textBoxKilZap.Text = studentBindingSource.Count.ToString();
        }


        private void toolStripMenuItemMarks_Click(object sender, EventArgs e)
        {
            student_marksBindingNavigator.BindingSource = student_marksBindingSource;
            studentDataGridView.Visible = false;
            studentBindingNavigator.Visible = false;
            student_marksDataGridView.Visible = true;
            student_marksBindingNavigator.Visible = true;
            labelInf.Text = "Оцінки";
            this.Validate();
            this.student_marksBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.harbarenko_student_DBDataSet);
            textBoxKilZap.Text = student_marksBindingSource.Count.ToString();
        }

        private void student_marksDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            student_marksTableAdapter.Update(harbarenko_student_DBDataSet);
            textBoxKilZap.Text = studentBindingSource.Count.ToString();
        }

        private void student_marksDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            student_marksTableAdapter.Update(harbarenko_student_DBDataSet);
            textBoxKilZap.Text = studentBindingSource.Count.ToString();
        }

        private void studentByStudentCodeToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.studentTableAdapter.StudentByStudentCode(this.harbarenko_student_DBDataSet.student, ((int)(System.Convert.ChangeType(enterStudentCodeToolStripTextBox.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void marksByStudentCodeToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.student_marksTableAdapter.MarksByStudentCode(this.harbarenko_student_DBDataSet.student_marks, ((int)(System.Convert.ChangeType(enterStudentCodeToolStripTextBox1.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void toolStripMenuItemStudentCodeStdnt_Click(object sender, EventArgs e)
        {
            studentByStudentCodeToolStrip:studentByStudentCodeToolStrip.Visible = true;
        }

        private void toolStripMenuItemMarksCodeStdnt_Click(object sender, EventArgs e)
        {
            marksByStudentCodeToolStrip: marksByStudentCodeToolStrip.Visible = true;
        }

        private void toolStripButtonSNo_Click(object sender, EventArgs e)
        {
            studentByStudentCodeToolStrip: studentByStudentCodeToolStrip.Visible = false;
            studentBindingNavigator.Visible = false;
            student_marksBindingNavigator.Visible = false;
        }

        private void toolStripButtonMNo_Click(object sender, EventArgs e)
        {
            marksByStudentCodeToolStrip: marksByStudentCodeToolStrip.Visible = false;
            student_marksBindingNavigator.Visible = false;
            studentBindingNavigator.Visible = false;
        }

        private void toolStripButtonSYes_Click(object sender, EventArgs e)
        {
            student_marksDataGridView.Visible = false;
            studentDataGridView.Visible = true;
            studentBindingNavigator.BindingSource = studentBindingSource;
            studentBindingNavigator.Visible = true;

            labelInf.Text = "Дані студента за кодом студента";

            try
            {
                int studentCode = Convert.ToInt32(enterStudentCodeToolStripTextBox.Text);
                this.studentTableAdapter.StudentByStudentCode(this.harbarenko_student_DBDataSet.student, studentCode);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            textBoxKilZap.Text = studentBindingSource.Count.ToString();
        }

        private void toolStripButtonMYes_Click(object sender, EventArgs e)
        {
            student_marksDataGridView.Visible = true;
            studentDataGridView.Visible = false;
            student_marksBindingNavigator.BindingSource = student_marksBindingSource;
            student_marksBindingNavigator.Visible = true;

            labelInf.Text = "Оцінки студента за кодом студента";

            try
            {
                int studentCode = Convert.ToInt32(enterStudentCodeToolStripTextBox1.Text);
                this.student_marksTableAdapter.MarksByStudentCode(this.harbarenko_student_DBDataSet.student_marks, studentCode);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            textBoxKilZap.Text = student_marksBindingSource.Count.ToString();
        }

        private void toolStripMenuItemPrint_Click(object sender, EventArgs e)
        {
            student_print student_print = new student_print();
            student_print.ShowDialog();
        }
    }
}
