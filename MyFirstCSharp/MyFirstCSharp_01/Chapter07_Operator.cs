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
    public partial class Chapter07_Operator : Form
    {
        public Chapter07_Operator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 대입 연산자 : 오른쪽의 리터럴 값을 왼쪽 변수에 대입하거나, 왼쪽 변수에 오른쪽 객체의 경우 주소를 할당한다.
            int iValue = 10;
            MessageBox.Show(Convert.ToString(iValue));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // += 오른쪽에 있느느 수를 왼쪽의 수와 합하여 변수에 저장
            int iValue = 10;
            iValue += 20;
            MessageBox.Show(Convert.ToString(iValue));

            string sValue = "10";
            sValue += "20";
            MessageBox.Show(sValue);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // += 오른쪽 수에 왼쪽 수를 뺀 결과를 왼쪽 변수에 저장
            int iValue = 100;
            iValue -= 11; // iValue = iValue - 11;
            MessageBox.Show(Convert.ToString(iValue));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // *= 왼쪽 수와 오른쪽 수를 곱하여 왼쪽 변수에 저장
            int iValue = 10;
            iValue *= 10;
            MessageBox.Show(Convert.ToString(iValue));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // /= 왼쪽 수와 오른쪽 수를 나누어 몫을 왼쪽 변수에 저장
            int iValue = 10;
            iValue /= 3; // iValue = iValue / 3;
            MessageBox.Show(Convert.ToString(iValue));

            double dValue = 10;
            dValue /= 3;
            MessageBox.Show(Convert.ToString(dValue));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // %= 왼쪽 수와 오른쪽 수를 나눠 나머지를 왼쪽 변수에 저장한다.
            int iValue = 10;
            iValue %= 3; // iValue = iValue % 3;
            MessageBox.Show(Convert.ToString(iValue));

            double dValue = 10;
            dValue %= 3.3;
            MessageBox.Show(Convert.ToString(dValue));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // 전위 증가 연산자와 후위 증가 연산자
            // ++ 변수에 1을 더한다.
            int iValue = 10;

            // 전위 증가 연산자
            ++iValue;
            MessageBox.Show("[2] " + Convert.ToString(iValue));

            // 후위 증가 연산자
            iValue++;
            MessageBox.Show("[1] " + Convert.ToString(iValue));

            // 전위 증가 연산자와 후위 증가 연산자의 결과가 다르게 나오는 예
            MessageBox.Show("[3] " + Convert.ToString(iValue++));
            MessageBox.Show("[4] " + Convert.ToString(++iValue));

            // 전위 증가 연산자는 코드가 실행(메시지박스)되기 전에 증가 연산 실행
            // 후위 증가 연산자는 코드가 실행(메시지박스)되고 난 후에 증가 연산 실행

            // 일반적으로 연산에 대한 결과를 실시간으로 판단하고 싶을 때는 후위 증가 연산자를 많이 사용
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // 전위 감소 연산자와 후위 감소 연산자

            int iValue = 10;
            iValue--; // 후위 감소 연산자는 코드가 실행되고 난 후 1을 차감
            MessageBox.Show(Convert.ToString(iValue));


            --iValue; // 전위 감소 연산자는 코드가 실행되기 전에 1을 차감
            MessageBox.Show(Convert.ToString(iValue));

            MessageBox.Show(Convert.ToString(iValue--));
            MessageBox.Show(Convert.ToString(--iValue));
        }
    }
}
