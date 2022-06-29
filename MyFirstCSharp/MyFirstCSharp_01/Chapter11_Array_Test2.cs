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
    public partial class Chapter11_Array_Test2 : Form
    {
        public Chapter11_Array_Test2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 배열 생성
            int[,] iArray = new int[2, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 } };

            // 행의 수 구하기
            int iArrayRowCount = iArray.GetLength(0);

            // 열의 수 구하기
            int iArrayColumnCount = iArray.GetLength(1);

            //  1. 자리가 바뀐 데이터가 담길 배열 변수 생성
            int[,] iResultArray = new int[iArrayRowCount, iArrayColumnCount];

            // 2. 원본 데이터 행 역행하여 복사 배열에 담기.
            int iArrayx = 0;
            for (int x = iArrayRowCount - 1; x >= 0; x--)
            {
                for (int y = 0; y < iArrayColumnCount; y++)
                {
                    // 행을 바꾸어 새로운 배열에 담기.
                    iResultArray[iArrayx, y] = iArray[x, y];
                }
                iArrayx++;
            }

            //텍스트 박스에 담기
            string aArrayList = string.Empty;
            textBox1.Text = "------------ 2차원 배열 행 바꾸기 ------------\r\n";
            int iColumnCount = 0;
            foreach(int iResult in iResultArray)
            {
                aArrayList += $"{iResult}, ";
                if (++iColumnCount == iArrayColumnCount)
                {
                    aArrayList = $"{{ {aArrayList} }} \r\n";
                    textBox1.Text += aArrayList;
                    aArrayList = string.Empty;
                    iColumnCount = 0;
                }
            }
        }
    }
}
