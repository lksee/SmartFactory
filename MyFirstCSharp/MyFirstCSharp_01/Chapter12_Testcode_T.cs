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
    public partial class Chapter12_Testcode_T : Form
    {
        // 총 결제 금액.
        int iOrderPrice = 0;

        // 현재 사과 잔량.
        int iAppleLeftCount = 10;
        // 현재 참외 잔량.
        int iOMelonLeftCount = 10;
        // 현재 수박 잔량.
        int iWMelonLeftCount = 10;

        // 결제 후 이전 사과 잔량.
        int iALeftC = 10;
        // 결제 후 이전 참외 잔량.
        int iOMLeftC = 10;
        // 결제 후 이전 수박 잔량.
        int iWMLeftC = 10;

        public Chapter12_Testcode_T()
        {
            InitializeComponent();
        }

        private void buttonOrderItem1_Click(object sender, EventArgs e)
        {
            FruitOperator("사과");
        }

        private void buttonOrderItem2_Click(object sender, EventArgs e)
        {
            FruitOperator("참외");
        }

        private void buttonOrderItem3_Click(object sender, EventArgs e)
        {
            FruitOperator("수박");
        }

        private void FruitOperator(string sFruitName)
        {
            switch (sFruitName)
            {
                case "사과":
                    iAppleLeftCount = Convert.ToInt32(labelQuantity1.Text);
                    if(!CheckFruitCount("사과", ref iAppleLeftCount)) return;
                    labelQuantity1.Text = Convert.ToString(iAppleLeftCount);
                    iOrderPrice += 2000;

                    break;
                case "참외":
                    iOMelonLeftCount = Convert.ToInt32(labelQuantity2.Text);
                    if(!CheckFruitCount("참외", ref iOMelonLeftCount)) return;
                    labelQuantity2.Text = Convert.ToString(iOMelonLeftCount);
                    iOrderPrice += 2500;

                    break;
                case "수박":
                    iWMelonLeftCount = Convert.ToInt32(labelQuantity3.Text);
                    if(!CheckFruitCount("수박", ref iWMelonLeftCount)) return;
                    labelQuantity3.Text = Convert.ToString(iWMelonLeftCount);
                    iOrderPrice += 18000;

                    break;

            }
        }

        private void buttonToTalPayment_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"총 결제 금액은 {iOrderPrice} 입니다.");
        }

        private bool CheckFruitCount(string sFruitName, ref int iLeftCount)
        {
            if (iLeftCount == 0)
            {
                MessageBox.Show($"{sFruitName}의 잔량이 0개 입니다.");
                return false;
            }
            --iLeftCount;
            return true;
        }

        private void buttonMakePayment_Click(object sender, EventArgs e)
        {
            // 결제할 금액이 잔액보다 많은 경우.
            if (iOrderPrice > Convert.ToInt32(labelClientBalance.Text))
            {
                MessageBox.Show("잔액이 부족합니다.");
                return;
            }

            // 결재 금액 차감, 관리자 잔액 증가.
            labelClientBalance.Text = Convert.ToString(Convert.ToInt32(labelClientBalance.Text) - iOrderPrice);
            labelManagerBalance.Text = Convert.ToString(Convert.ToInt32(labelManagerBalance.Text) + iOrderPrice);

            // 주문 수량, 금액 TextBox에 표현
            // 사과의 판매 개수
            int iAOrderCount = iALeftC - iAppleLeftCount;
            // 참외의 판매 개수
            int iOMOrderCount = iOMLeftC - iOMelonLeftCount;
            // 수박의 판매 개수
            int iWMOrderCount = iWMLeftC - iWMelonLeftCount;

            // 과일의 각 판매 금액.
            int iASalePrice = iAOrderCount * 2000;
            int iOMSalePrice = iOMOrderCount * 2500;
            int iWMSalePrice = iWMOrderCount * 18000;

            // 거래 내역있는 내역만 TextBox에 표현.
            string sOrderList = "-------------------- 판매 내역 --------------------\r\n";
            if (iAOrderCount != 0) sOrderList  += $"사과의 판매 개수 : {iAOrderCount }, 판매 금액 : {iASalePrice }\r\n";
            if (iOMOrderCount != 0) sOrderList += $"참외의 판매 개수 : {iOMOrderCount}, 판매 금액 : {iOMSalePrice}\r\n";
            if (iWMOrderCount != 0) sOrderList += $"수박의 판매 개수 : {iWMOrderCount}, 판매 금액 : {iWMSalePrice}\r\n";

            textBoxTransactionDetail1.Text = sOrderList;

            // 결제 후 재고 기억하기.
            iALeftC = iAppleLeftCount;
            iOMLeftC = iOMelonLeftCount;
            iWMLeftC = iWMelonLeftCount;

            // 결제 금액 초기화
            iOrderPrice = 0;

            // 결제 완료 메시지 표현
            MessageBox.Show("결제가 완료 되었습니다.");
        }
    }
}
