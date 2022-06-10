using System;
using System.Windows.Forms;

namespace MyFirstCSharp_01
{
    public partial class Test_Sum_Odd_Even : Form
    {
        public Test_Sum_Odd_Even()
        {
            InitializeComponent();
        }

        private void buttonSumOddEven_Click(object sender, EventArgs e)
        {
            // 홀수의 합을 구할 변수.
            int iSumOdd = 0;
            // 짝수의 합을 구할 변수.
            int iSumEven = 0;
            
            // 1부터 100까지의 수.
            for (int i = 1; i <= 100; i++)
            {
                // 짝수일 때.
                if (i % 2 == 0)
                {
                    iSumEven += i;
                }
                // 홀수일 때.
                else
                {
                    iSumOdd += i;
                }
            }

            // 결과를 메시지박스로 출력.
            MessageBox.Show($"짝수의 합은 {iSumEven}, 홀수의 합은 {iSumOdd}입니다.");
        }
    }
}
