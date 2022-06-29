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
    public partial class Chapter09_If_BranchingStatement : Form
    {
        // 분기문은 프로그램의 흐름의 조건에 따라 여러 갈래로 나누는 흐름 제어.
        // 비교 연산자는 ==, !=, <=, >=, <, >, &&, || 등을 사용.
        public Chapter09_If_BranchingStatement()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 텍스트박스에 값이 없을 경우 "아무 것도 없습니다."
            // 값이 있을 경우 해당 값을 메시지 박스로 표현

            if (textBox1.Text == "")
            {
                MessageBox.Show("아무 것도 없습니다.");
            }
            else
            {
                MessageBox.Show(textBox1.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // TextBox에 입력한 값이
            // 1 일 때는 분기문 1 실행 메시지
            // 2 일 때는 분기문 2 실행 메시지
            // 3 일 때는 분기문 3 실행 메시지
            // 값이 없을 경우는 "아무 값도 없습니다." 메시지
            // 1, 2, 3이 아닌 다른 문자일 경우 "적절한 분기문이 없습니다." 메시지

            // 2 분기문 안의 분기문
            if (textBox1.Text != "")
            {
                if (textBox1.Text == "1")
                {
                    MessageBox.Show("분기문 1 실행");
                }
                if (textBox1.Text == "2")
                {
                    MessageBox.Show("분기문 2 실행");
                }
                if (textBox1.Text == "3")
                {
                    MessageBox.Show("분기문 3 실행");
                }
                else
                {
                    MessageBox.Show("적잘한 분기문이 없습니다.");
                }
                // 마지막의 else는 바로 3번 분기문의 예외일 경우 결과를 반환한다.
                // 1을 입력하면 1번 분기문의 결과가 true이므로 분기문 1실행 메시지 출력.

                // 3이 아니기 때문에 3번 분기문에서 메시지가 적절한 분기문이 없습니다. 메시지가 동시에 출력.
            }
            else
            {
                MessageBox.Show("아무 값도 없습니다.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // else if 
            // if 문과 다음 if문을 하나의 흐름으로 만들어 준다.
            // TextBox에 입력한 값이 
            // 1 일 때는 분기문 1 실행 메시지
            // 2 일 때는 분기문 2 실행 메시지
            // 3 일 때는 분기문 3 실행 메시지
            // 값이 없을 경우 "아무 것도 없습니다." 메시지
            // 1, 2, 3이 아닌 다른 문자일 경우 "적절한 분기문이 없습니다." 메시지

            // 분기문 if 와 else if, else

            if (textBox1.Text == "")
            {
                MessageBox.Show("아무 값도 없습니다.");
            }
            else if (textBox1.Text == "1")
            {
                MessageBox.Show("분기문 1 실행");
            }
            else if (textBox1.Text == "2")
            {
                MessageBox.Show("분기문 2 실행");
            }
            else if (textBox1.Text == "3")
            {
                MessageBox.Show("분기문 3 실행");
            }
            else
            {
                MessageBox.Show("적절한 분기문이 없습니다.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // and if 문 --> &&
            // or if 문 --> ||
            if (textBox1.Text == "1" || textBox1.Text == "2" || textBox1.Text == "3")
            {
                MessageBox.Show(textBox1.Text = $"{textBox1.Text}번 분기문 실행");
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("아무 값도 없습니다.");
            }
            else
            {
                MessageBox.Show("적절한 분기문이 없습니다.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // bool 로 비교 (bool : true/false를 나타내는 타입)

            // 판단 결과를 바당올 bool 변수 생성
            bool bT_F = false;

            if (textBox1.Text == "1" || textBox1.Text == "2" || textBox1.Text == "3")
            {
                bT_F = true;
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("아무 값도 없습니다.");
            }

            // 새로운 if 시작
            if (bT_F)
            {
                MessageBox.Show(textBox1.Text + " 번 분기문 실행");
            }
            else if (bT_F && textBox1.Text != "")
            {
                MessageBox.Show("적절한 분기문이 없습니다.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // 음수와 양수.
            int iValue = Convert.ToInt32(textBox1.Text);
            if (iValue < 0)
            {
                MessageBox.Show("음수입니다.");
            }
            else if (iValue > 0)
            {
                MessageBox.Show("양수입니다.");
            }
            else
            {
                MessageBox.Show("0입니다.");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int iValue;
            int.TryParse(textBox1.Text, out iValue);

            if (iValue % 2 == 0)
            {
                MessageBox.Show("짝수입니다.");
            }
            else
            {
                MessageBox.Show("홀수입니다.");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // 삼항 연산자
            // 피연산자의 개수가 3개인 조건부 연산자.
            // if else 구문을 한 줄로 간단하게 표현할 수 있기 때문에 inline if 라고도 한다.
            int iNumber = 100;
            string sResult = string.Empty;  // string.Empty = "";

            sResult = (iNumber % 2 == 0) ? "짝수" : "홀수";
            MessageBox.Show(sResult);

        }
    }
}
