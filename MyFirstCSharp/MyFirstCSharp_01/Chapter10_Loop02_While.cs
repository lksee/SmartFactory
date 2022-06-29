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
    public partial class Chapter10_Loop02_While : Form
    {
        public Chapter10_Loop02_While()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // while 특정 조건을 만족 시킬 때까지 반복
            // 1부터 100까지의 합을 구하는 로직
            int iCount = 0; // 조건변수 1 ~ 100
            int iTotalSum = 0;

            while (iCount <= 100) 
            {
                if (iTotalSum > 1000)
                {
                    break;
                }

                if (iCount % 2 == 0)
                {
                    iCount++;
                    continue;
                }
                iTotalSum += iCount;
                iCount++;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 무한 루프를 사용하는 경우가 있다.

            // 무한 루프를 구현하는 여러가지 방법 중 논리 연산자를 사용하는 방법이 많이 사용된다.
            // 변수 생성
            int iCount  = 0;
            int iResult = 0;

            while (true)
            {
                ++iCount;
                iResult += iCount;
                if (iResult > 1000)
                {
                    return; // method 종료
                    break; // 반복문 종료
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 1부터 100까지 합을 do while로 구하기.
            int iCount  = 0; // 반복 횟수
            int iResult = 0;

            do
            {
                iResult += iCount;
                ++iCount;
            }
            while (iCount < 101);
        }
    }
}
