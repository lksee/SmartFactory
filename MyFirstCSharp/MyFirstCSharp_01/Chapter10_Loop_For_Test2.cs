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
    public partial class Chapter10_Loop_For_Test2 : Form
    {
        public Chapter10_Loop_For_Test2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 2의 배수 누적 합 찾기
            ShowMessage(2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 5의 배수 누적 합 찾기
            ShowMessage(5);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 10의 배수 누적 합 찾기
            ShowMessage(10);
        }

        private void ShowMessage(int iValue)
        {
            // 2의 배수 누적 합 찾기

            // 변수 지정 (1부터 코딩의 흐름에 따라 그때그때 생성)
            int iResult = 0; // 누적 결과 값(숫자로 변경한 결과 값)
            string sStartValue = textBox1.Text;
            string sEndValue = textBox2.Text;

            // Validation check.
            int iResult1 = 0; // 시작 문자를 숫자로 변경할 int 변수.
            int iResult2 = 0; // 종료 문자를 숫자로 변경할 int 변수.
            bool bValueFlag;  // 숫자 변경 결과를 담을 bool 변수.

            // 숫자 여부 판단
            bValueFlag = int.TryParse(sStartValue, out iResult1);
            if (bValueFlag == true)
            {
                bValueFlag = int.TryParse(sEndValue, out iResult2);
            }
            if (!bValueFlag)
            {
                MessageBox.Show("숫자로 바꿀 수 없는 값을 입력하였습니다.");
            }
            //if (!bValueFlag)
            //{
            //    MessageBox.Show("숫자로 바꿀 수 없는 값을 입력하였습니다.");
            //    return;
            //}

            //bValueFlag = int.TryParse(sEndValue, out iResult2);
            //if (!bValueFlag)
            //{
            //    MessageBox.Show("숫자로 바꿀 수 없는 값을 입력하였습니다.");
            //    return;
            //}

            // 입력받은 값이 양수인지 판단.
            //if (iResult1 >= 0 && iResult2 >= 0)
            //{
            //    //ToDo 😀
            //}
            //else
            //{
            //    MessageBox.Show("입력받는 값은 양수만 가능합니다.");
            //    return;
            //}
            if (iResult1 < 0 || iResult2 < 0)
            {
                MessageBox.Show("입력받는 값은 양수만 가능합니다.");
                return;
            }

            for (int i = iResult1; i <= iResult2; i++)
            {
                if (i % iValue == 0)
                {
                    iResult += i;
                }
            }
        }
    }
}
