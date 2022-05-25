using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstCSharp_01
{
    public partial class Chapter03_Class_Test : Form
    {
        Chapter02_DataType CHP_02 = new Chapter02_DataType();

        public Chapter03_Class_Test()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = CHP_02.sMessage1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = CHP_02.sMessage2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = CHP_02.sMessage3;
        }
    }
}
