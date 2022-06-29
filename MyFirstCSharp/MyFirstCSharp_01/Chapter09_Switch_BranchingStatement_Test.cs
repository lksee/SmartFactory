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
    public partial class Chapter09_Switch_BranchingStatement_Test : Form
    {
        readonly string[] sFruitNames = new string[] { "사과", "참외", "수박" };
        readonly int[] iFruitPrices = new int[] { 2000, 2500, 18000 };
        int[] iFruitQuantities = new int[] { 10, 10, 10 };
        int iTotalSales = 0;

        GroupBox[] gFruitName = new GroupBox[3];
        Label[] lFruitPrices = new Label[3];
        Label[] lFruitQuantities = new Label[3];

        public Chapter09_Switch_BranchingStatement_Test()
        {
            InitializeComponent();

            // 컨트롤 그룹화.
            // 과일 이름과 연관된 그룹박스 배열.
            gFruitName[0] = groupBox1;
            gFruitName[1] = groupBox2;
            gFruitName[2] = groupBox3;
            // 과일 가격과 연관된 레이블 배열.
            lFruitPrices[0] = labelPrice1;
            lFruitPrices[1] = labelPrice2;
            lFruitPrices[2] = labelPrice3;
            // 과일 수량과 연관된 레이블 배열.
            lFruitQuantities[0] = labelQuantity1;
            lFruitQuantities[1] = labelQuantity2;
            lFruitQuantities[2] = labelQuantity3;


            for (int i = 0; i < 3; i++)
            {
                gFruitName[(int)i].Text = sFruitNames[i] ;
                lFruitPrices[(int)i].Text = Convert.ToString(iFruitPrices[i]);
                lFruitQuantities[(int)i].Text = Convert.ToString(iFruitQuantities[i]) + "개";
            }
        }

        private void _saleFruit(int iIndex, ref int iTotalSales)
        {
            // 수량이 0 이하이면(없으면) 팔지 않는다.
            if (iFruitQuantities[iIndex] <= 0)
            {
                MessageBox.Show($"{sFruitNames[iIndex]}의 남은 수량이 {iFruitQuantities[iIndex]} 개 입니다. 주문을 할 수 없습니다.");
                return;
            }
            // 수량이 있으면 판매 프로세스 진행.
            else
            {
                switch (iIndex)
                {
                    // 사과.
                    case 0:
                        lFruitQuantities[0].Text = Convert.ToString(--iFruitQuantities[iIndex])+"개";
                        break;
                    // 참외.
                    case 1:
                        lFruitQuantities[1].Text = Convert.ToString(--iFruitQuantities[iIndex]) + "개";
                        break;
                    // 수박.
                    case 2:
                        lFruitQuantities[2].Text = Convert.ToString(--iFruitQuantities[iIndex]) + "개";
                        break;
                }
                iTotalSales += iFruitPrices[iIndex];
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _saleFruit(0, ref iTotalSales);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            _saleFruit(1, ref iTotalSales);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _saleFruit(2, ref iTotalSales);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Convert.ToString($"총 결제 금액은 {iTotalSales} 원 입니다."));
        }
    }
}
