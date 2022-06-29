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
    public partial class Chapter10_Loop03_foreach : Form
    {
        // foreach
        // 끝을 지정해서 false 값으로 종료하는 다른 반복문과는 달리
        // 인자로 들어온 Object의 내부 인덱스의 끝까지 자동으로 순환을 해주는 반복문.
        // 인자가 포함하는 내용의 수에 따라 반복하므로 종료 조건이 없어도 반드시 종료가 되는 반복문.

        // iterator로 된 객체를 하나씩 가지고 반복문 내용을 마지막 내용까지 진행.

        public Chapter10_Loop03_foreach()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 문자열에서 한글자씩 추출된 변수의 데이터 표현하기.

            // 문자 1개만 입력받도록.
            if (textBox1.Text.Length > 1)
            {
                MessageBox.Show("");
                return;
            }

            // 문자열 데이터 변수에 담기
            string sTitle = label1.Text;

            // 추출 시작
            bool sCheck = false;
            foreach(char cValue in sTitle)
            {
                if( cValue == Convert.ToChar(textBox1.Text))
                {
                    MessageBox.Show($"{cValue} 문자가 있습니다.");
                    sCheck = true;
                    break;
                }
            }
            if (!sCheck) MessageBox.Show("문자가 없습니다.");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if(tb.Text.Length > 1)
            {
                MessageBox.Show("한 글자만 입력 가능합니다.");
                tb.Text = tb.Text.Substring(0, 1);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 배열에서 데이터를 추출하는 foreach
            int[] Array = new int[] { 11, 12, 13, 14, 15, 16, 17 };

            // 현재 배열의 index를 담을 변수
            int iIndex = 0;

            //
            foreach (int elem in Array)
            {
                MessageBox.Show($"배열 Array [{iIndex}] : {elem}");
                iIndex++;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 컬렉션에 Add된 순서 확인하기.
            int iIndex = 0;
            
            // 그룹 박스에 있는 컨트롤의 모든 속성을 변경하는 foreach문
            foreach (Control myControl in groupBox1.Controls)
            {
                if (myControl is TextBox)
                {
                    myControl.Text = $"[{iIndex}] Hey guy!";
                }
                iIndex++;
            }
            // 나중에 넣은 게 나중에 나온다.
            //this.groupBox1.Controls.Add(this.label2);
            //this.groupBox1.Controls.Add(this.textBox7);
            //this.groupBox1.Controls.Add(this.textBox6);
            //this.groupBox1.Controls.Add(this.textBox5);
            //this.groupBox1.Controls.Add(this.textBox4);
            //this.groupBox1.Controls.Add(this.textBox3);
            //this.groupBox1.Controls.Add(this.textBox2);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 그룹 박스에 있는 컨트롤의 모든 속성을 변경하는 foreach문
            foreach (Control myControl in groupBox1.Controls)
            {
                // is 연산자는 식 결과가 지정된 형식과 호환되는지 확인(https://docs.microsoft.com/ko-kr/dotnet/csharp/language-reference/operators/is)
                if (myControl is TextBox)
                {
                    myControl.Text = "";
                }
            }
        }
    }
}
