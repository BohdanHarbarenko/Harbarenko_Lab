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
    public partial class Form_stdnt_info : Form
    {
        public Form_stdnt_info()
        {
            InitializeComponent();
            this.richTextBox1.LoadFile("C:\\434\\Harbarenko\\Info.rtf");
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
