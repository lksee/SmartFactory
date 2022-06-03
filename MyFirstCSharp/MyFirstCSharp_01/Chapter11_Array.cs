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
    public partial class Chapter11_Array : Form
    {
        // 배열 : 같은 데이터 타입의 여러 데이터가 있을 경우
        //        하나의 배열 변수 이름으로 정의하는 데이터 형식
        public Chapter11_Array()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. 배열을 초기화: 크기가 맞아야 하고, 크기가 가변적이지 않다.
            int[] iaValue = new int[10];
            int[] iaValue1 = new int[6] { 40, 10, 2, 30, 3, 1 };
            int[] iaValue2 = new int[] { 10, 20, 30, 40 };
            int[] iaValue3 = { 10, 20 };

            string[] saValue1 = "ABCD/EFG".Split('/');
            int[] iValue4 = new int[iaValue.Length];

            // 2. 배열에서 사용할 수 있는 주요 기능.
            // 배열 정렬
            Array.Sort(iaValue1);
            foreach(int ivalue in iaValue1)
            {
                MessageBox.Show(Convert.ToString(ivalue));
            }

            // 특정 데이터의 index를 반환하는 기능
            int iIndex = Array.IndexOf(iaValue1, 30);
            //MessageBox.Show($"30의 Index는 : {iIndex}");

            // 배열을 복사 : 배열의 참조 주소를 복사한다.
            int[] iaValue4 = iaValue3;
            MessageBox.Show($"iaValue4의 첫번째 값은 : {iaValue4[0]}입니다.");
            iaValue3[0] = 3;
            MessageBox.Show($"iaValue4의 첫번째 값은 : {iaValue4[0]}입니다.");


            // 배열의 크기를 조정한다.
            Array.Resize<int>(ref iaValue1, 3);
            foreach (int ivalue in iaValue1)
            {
                MessageBox.Show(Convert.ToString(ivalue));
            }

            // 배열을 전체적으로 초기화
            Array.Clear(iaValue1, 0, iaValue1.Length);
            foreach (int ivalue in iaValue1)
            {
                MessageBox.Show(Convert.ToString(ivalue));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 2차원 배열의 초기화하는 방법.
            int[,] iaArray = new int[2, 3];
            iaArray[0, 0] = 1;
            iaArray[0, 1] = 2;
            iaArray[0, 2] = 3;
            iaArray[1, 0] = 4;
            iaArray[1, 1] = 5;
            iaArray[1, 2] = 6;


            int[,] iaArray2 = new int[2, 3] { { 1, 2, 3, }, 
                                              { 4, 5, 6, } };

            // 행의 수를 구하는 기능
            int iArrayRowCount = iaArray2.GetLength(0);

            // 열의 수 구하는 기능
            int iArrayRowCount2 = iaArray2.GetLength(1);

            // 1. 위의 배열을 텍스트 박스에 표현하세요.
            textBox1.Text = "===================For===================\r\n";
            string sArrayList = string.Empty;
            for (int x = 0; x < iArrayRowCount; x++)
            {
                for (int y = 0; y < iArrayRowCount2; y++)
                {
                    sArrayList += $"iaArray2의 [{x}, {y}]의 값은 : {iaArray2[x, y]} \r\n";
                }
                textBox1.Text += sArrayList + "\r\n";
                sArrayList = string.Empty;
            }

            // 2. foreach
            textBox1.Text += "=================Foreach=================\r\n";
            //textBox1.Text = textBox1.Text + "=================Foreach=================\r\n";
            int iDem = 0;
            foreach(int iResult in iaArray2)
            {
                sArrayList += $"{iResult}, ";
                if (++iDem == iaArray2.GetLength(1))
                {
                    sArrayList += "\r\n";
                    iDem = 0;
                }
            }
            textBox1.Text += sArrayList;

            int[,,,] iaArray10 = new int[2, 3, 4, 5];
            int n_ = 0;

            for (int a = 0; a < 2; a++)
            {
                for(int b = 0; b < 3; b++)
                {
                    for(int c = 0; c < 4; c++)
                    {
                        for(int d = 0; d < 5; d++)
                        {
                            iaArray10[a, b, c, d] = n_;
                            n_++;
                        }
                    }
                }
            }

            int n0 = iaArray10.GetLength(0);
            int n1 = iaArray10.GetLength(1);
            int n2 = iaArray10.GetLength(2);
            int n3 = iaArray10.GetLength(3);

            MessageBox.Show($"n0 : {n0}, n1 : {n1}, n2 : {n2}, n3 : {n3}");

            //foreach (int x in iaArray10)
            //{
            //    MessageBox.Show(Convert.ToString(x));
            //}

        }
    }
}
