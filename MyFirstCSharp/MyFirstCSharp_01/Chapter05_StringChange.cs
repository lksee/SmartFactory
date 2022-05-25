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
    public partial class Chapter05_StringChange : Form
    {
        string sTitle = "     ABCDE fghij KLMNO pqrstu     ";
        public Chapter05_StringChange()
        {
            InitializeComponent();
            label1.Text = sTitle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = sTitle;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "    ";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 문자열의 모든 대문자를 소문자로 변형하기
            // ToLower()
            textBox1.Text = label1.Text.ToLower();

        }


        private void button4_Click(object sender, EventArgs e)
        {
            // 문자열의 모든 소문자를 대문자로 변형하기
            // ToUpper()
            textBox2.Text = label1.Text.ToUpper();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // 지정된 위치에 문자열 삽입하기

            // 1. 위치값 받아오기
            //int iLocation = Convert.ToInt32(textBox4.Text);
            int iStartIndex;
            int.TryParse(textBox4.Text, out iStartIndex);

            // 2. 삽입할 문자열 받아오기
            string sValue = textBox5.Text;

            textBox3.Text = label1.Text.Insert(iStartIndex, sValue);
        }
    }
}
