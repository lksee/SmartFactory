using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class _02_static_const : Form
    {
        public _02_static_const()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Class_Static.sValue);
            Class_Static.sValue = "요~ 브로";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Class_Static.sValue);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Class_Static_2 CS2 = new Class_Static_2();
            MessageBox.Show(CS2.sValue2);

            MessageBox.Show(Class_Static_2.sValue1);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }

    class Class_Static
    {
        public static string sValue = "하이요~";
    }

    class Class_Static_2
    {
        public static string sValue1 = "하이용~!";
        public string sValue2 = "헬로우~~"
    }

    static class Class_Static_3
    {
        public static string sValue1 = "헤이요!";
        public static string sValue2 = "왓썹가이즈!";
    }

    class Class_Const
    {
        public const string sValue = "에이요~";
    }
}
