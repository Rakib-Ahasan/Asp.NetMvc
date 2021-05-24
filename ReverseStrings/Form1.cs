using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReverseStrings
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           Student student=new Student();
           student.firstName = "Rakib";
           student.lastName = "Ahasan";

           string fullName = student.GetFullName();
           MessageBox.Show(student.GetReverseName());
        }
    }
}
