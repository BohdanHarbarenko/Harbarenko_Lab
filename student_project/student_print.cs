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
    public partial class student_print : Form
    {
        public student_print()
        {
            InitializeComponent();
        }

        private void student_print_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'harbarenko_student_DBDataSet.DataTable1' table. You can move, or remove it, as needed.
            this.dataTable1TableAdapter.Fill(this.harbarenko_student_DBDataSet.DataTable1);
            this.reportViewer1.RefreshReport();
            reportViewer1.ShowPrintButton = false;
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
