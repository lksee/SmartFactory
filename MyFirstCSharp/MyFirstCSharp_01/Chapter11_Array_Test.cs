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
    public partial class Chapter11_Array_Test : Form
    {
        public Chapter11_Array_Test()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[,] iaValue1 = new int[2, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 } };
            int[,] iaValue2 = new int[iaValue1.GetLength(0), iaValue1.GetLength(1)];

            // iaValue1 행 순서 반대로 만들기.
            for(int i = 0; i < iaValue1.GetLength(0); i++)
            {
                for(int j = 0 ; j < iaValue1.GetLength(1) ; j++)
                {
                    iaValue2[iaValue1.GetLength(0) - i - 1, j] = iaValue1[i, j];
                }
            }

            
            int iColCount = iaValue2.GetLength(1);
            int iCount = 0;
            string sValue = "";
            foreach(int a in iaValue2)
            {
                // 시작 괄호 추가
                if (iCount == 0)
                {
                    sValue += "{";
                }

                // 배열 값 추가
                sValue += a;
                
                // 개행 문자 추가
                if (++iCount == iColCount)
                {
                    sValue += "}\r\n";
                    iCount = 0;
                }
                // 콤마 추가
                else
                {
                    sValue += ", ";
                }
            }
            textBox1.Text = sValue;
        }
    }
}
