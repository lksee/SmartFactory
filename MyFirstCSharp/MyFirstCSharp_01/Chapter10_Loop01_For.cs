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
    public partial class Chapter10_Loop01_For : Form
    {
        public Chapter10_Loop01_For()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1부터 100까지 누적 합산 결과를 표현하세요.

            // 누적 계산 결과가 들어갈 변수.
            int iResult = 0;
            for (int i = 1; i <= 100; i++)
            {
                iResult += i;
            }
            MessageBox.Show(iResult.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 배열의 수만큼 for 문 반복 후 배열 값 더하기

            // 1. 임의의 배열 값 등록
            int[] iValue = new int[] { 1, 12, 18, 20, 13 };
            //                 index  [0] [1] [2] [3] [4]

            // 2. 배열 값의 합을 더할 변수 생성
            int iResult = 0;

            // 3. for 문을 시작할 변수 데이터 생성.
            //int NowIndex = 1;

            for (int NowIndex = 0; NowIndex < iValue.Length; NowIndex++)
            {
                // 왜 Length보다 미만인 수만큼 반복해야 하나?
                // 배열의 Length는 5개, Index 는 0~4이므로
                // iValue가 Length보다 작을 동안만 반복되도록 범위 지정.
                iResult += iValue[NowIndex];
            }

            //foreach (int i in iValue)
            //{
            //    iResult += i;
            //}

            MessageBox.Show(Convert.ToString(iResult));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // for in for 구구단 만들기

            // 1. base가 되는 단수 문자열 변수
            string sBase = string.Empty;

            // 2. 곱해지는 구구단 결과 값 문자열 변수
            string sSub = string.Empty;

            // 3. Base 단수 2 ~ 9단 반복
            for (int i = 2; i <= 9; i++)
            {
                // 4. sBase에 현재 i 단수 문자열 대입
                // 첫번째 반복일 때 (2 * )
                sBase = $"{Convert.ToString(i)} * ";

                // 5. rhqgowlsms tn 1~9 반복문.
                for (int j = 1; j <= 9; j++)
                {
                    // 6. sSub 문자변수에 곱해지는 수와 결과 값을 베이스 문자열과 합
                    sSub = $"{Convert.ToString(j)} = {Convert.ToString(i*j)}";
                    textBox1.Text += $"{sBase}{sSub}\r\n";

                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 1부터 100까지 누적 합산 계산 for 문
            // 누적값 변수
            int iSumValue = 0;

            for (int i = 1 ; i <= 100 ; i++)
            {
                if (i >= 50 && i <= 60)
                {
                    continue;
                }
                // iSumValue = iSumValue + i;
                iSumValue += i;

                if (iSumValue > 1000) break;
            }

            MessageBox.Show(Convert.ToString(iSumValue));
        }
    }
}
