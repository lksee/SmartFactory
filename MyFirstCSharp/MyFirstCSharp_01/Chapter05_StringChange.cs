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

        private void button6_Click(object sender, EventArgs e)
        {
            // 지정된 위치 범위의 문자를 삭제

            // 1. 삭제 시작 위치 지정
            int iStartIndex;
            int.TryParse(textBox7.Text, out iStartIndex);

            // 2. 삭제 종료 위치 지정
            int iCount;
            int.TryParse(textBox6.Text, out iCount);

            // 3. 삭제할 문자열 삭제 후 결과 Text
            textBox8.Text = label1.Text.Remove(iStartIndex, iCount);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Trim() 문자열의 앞과 뒤의 빈 공백을 지움.
            textBox11.Text = label1.Text.Trim();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Trim() 문자열의 가장 앞 빈 공백을 지움.
            textBox9.Text = label1.Text.TrimStart();
            //textBox9.Text = sTitle.TrimStart();
            //textBox9.Text = "   asdlfqwejl".TrimStart();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Trim() 문자열의 가장 뒤 빈 공백을 지움.
            textBox10.Text = label1.Text.TrimEnd();

            string sValue = label1.Text.TrimEnd();
            textBox10.Text = sValue;
        }
    }
}
