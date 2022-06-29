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
    public partial class Chapter11_Middle_Exam_TestCode : Form
    {
        public Chapter11_Middle_Exam_TestCode()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // int 배열 등록
            int[] iaValue = new int[7] { 1, 4, 6, 9, 10, 12, 16 };

            // 찾은 값 등록할 변수
            string sFindValue = string.Empty;

            // 결과의 Index
            int iResult = 0;

            // 배열 오름차순 정렬
            Array.Sort(iaValue);

            for (int i = 0; i < iaValue.Length; i++)
            {
                // 찾을 수?
                int iFindValue = 16 - iaValue[i];

                // 찾을 배열의 숫자가 있는 위치(Index)를 찾기
                iResult = Array.IndexOf(iaValue, iFindValue, i + 1);

                // 결과가 없으면 -1을 반환
                if (iResult == -1) continue;

                sFindValue += $"{iaValue[i]}, {iaValue[iResult]}\r\n";
            }
            MessageBox.Show(sFindValue);
        }
    }
}
