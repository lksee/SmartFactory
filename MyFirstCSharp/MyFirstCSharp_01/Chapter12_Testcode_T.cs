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

        Dictionary<string, int> MyDicMargin = new Dictionary<string, int>();

        public Chapter12_Testcode_T()
        {
            InitializeComponent();

            MyDicMargin["사과"] = 0;
            MyDicMargin["참외"] = 0;
            MyDicMargin["수박"] = 0;
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

            MyDicMargin["사과"] += iASalePrice;
            MyDicMargin["참외"] += iOMSalePrice;
            MyDicMargin["수박"] += iWMSalePrice;

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

        private void buttonCancelOrder_Click(object sender, EventArgs e)
        {
            // 주문 취소하기
            // 1. 취소할 내역이 없으면 메시지
            //if ( iALeftC  == iAppleLeftCount 
            //  && iOMLeftC == iOMelonLeftCount 
            //  && iWMLeftC == iWMelonLeftCount )
            //{
            //    MessageBox.Show("주문 수량이 없습니다.");
            //    return;
            //}

            if (iOrderPrice == 0)
            {
                MessageBox.Show("주문 내역이 없습니다.");
                return;
            }

            // 마지막 결제 이전 재고 수량 표현하기.
            labelQuantity1.Text = Convert.ToString(iALeftC);
            labelQuantity2.Text = Convert.ToString(iOMLeftC);
            labelQuantity3.Text = Convert.ToString(iWMLeftC);

            //iAppleLeftCount = iALeftC;
            //iOMelonLeftCount = iOMLeftC;
            //iWMelonLeftCount = iWMLeftC;

            // 결제 주문 금액 초기화하기.
            iOrderPrice = 0;
        }

        private void buttonPlaceAOrder_Click(object sender, EventArgs e)
        {
            // 발주 입고 버튼 클릭

            // 발주 수량 가져오기
            int iAlnvCount = 0;
            int iOMInvCount = 0;
            int iWMInvCount = 0;

            // 사과의 발주 수량
            int.TryParse(textBoxOderItem1.Text, out iAlnvCount);
            // 참외의 발주 수량
            int.TryParse(textBoxOderItem2.Text, out iOMInvCount);
            // 수박의 발주 수량
            int.TryParse(textBoxOderItem3.Text, out iWMInvCount);

            if (iAlnvCount == 0 && iOMInvCount == 0 && iWMInvCount == 0)
            {
                MessageBox.Show("발주 수량을 입력하지 않았습니다.");
                return;
            }

            // 발주 금액 산출하기.
            int iAInvPrice = Convert.ToInt32(iAlnvCount * 0.6 * 2000);
            int iOMInvPrice = Convert.ToInt32(iOMInvCount * 0.6 * 2500);
            int iWMInvPrice = Convert.ToInt32(iWMInvCount * 0.6 * 18000);

            // 차감 총액 변수에 담기.
            int iTotalInvPrice = iAInvPrice + iOMInvPrice + iWMInvPrice;

            // 관리자 금액에서 총 발주 금액 차감하기.
            int iManLeftCash = Convert.ToInt32(labelManagerBalance.Text);

            if (iManLeftCash < iTotalInvPrice)
            {
                MessageBox.Show("잔액이 부족하여 발주를 진행할 수 없습니다.ㅋ");
                return;
            }

            labelManagerBalance.Text = Convert.ToString(iManLeftCash - iTotalInvPrice);

            // 주문 가능 수량 증가하기
            iAppleLeftCount = iALeftC += iAlnvCount;
            iOMelonLeftCount = iOMLeftC += iOMInvCount;
            iWMelonLeftCount = iWMLeftC += iWMInvCount;

            labelQuantity1.Text = Convert.ToString(iAppleLeftCount);
            labelQuantity2.Text = Convert.ToString(iOMelonLeftCount);
            labelQuantity3.Text = Convert.ToString(iWMelonLeftCount);

            // 발주 내역 TextBox에 출력
            string sInvList = "-------------------- 발주 내역 --------------------\r\n";
            if (iAlnvCount != 0) sInvList += $"사과 구매 개수 : {iAlnvCount}, 구매 금액 : {iAInvPrice} \r\n";
            if (iOMInvCount != 0) sInvList += $"참외 구매 개수 : {iOMInvCount}, 구매 금액 : {iOMInvPrice} \r\n";
            if (iWMInvCount != 0) sInvList += $"수박 구매 개수 : {iWMInvCount}, 구매 금액 : {iWMInvPrice} \r\n";

            textBoxTransactionDetail1.Text += sInvList;

            MyDicMargin["사과"] -= iAInvPrice;
            MyDicMargin["참외"] -= iOMInvPrice;
            MyDicMargin["수박"] -= iWMInvPrice;

            // 수량 입력한 텍스트 내용 지우기
            InvoiceCountClear();

            // 메시지
            MessageBox.Show("발주/입고를 완료하였습니다.");
        }

        private void InvoiceCountClear()
        {
            // 발주 수량 초기화 메서드
            foreach (Control txt in groupBoxOrder.Controls)
            {
                if (txt is TextBox)
                {
                    txt.Text = "";
                }
            }
        }

        private void buttonResetOrder_Click(object sender, EventArgs e)
        {
            InvoiceCountClear();

        }

        private void buttonItemMargin_Click(object sender, EventArgs e)
        {
            if (buttonItemRadio1.Checked)
            {
                MessageBox.Show($"사과의 마진은 {MyDicMargin["사과"]}원 입니다.");
            }
            else if (buttonItemRadio2.Checked)
            {
                MessageBox.Show($"참외의 마진은 {MyDicMargin["참외"]}원 입니다.");
            }
            else if (buttonItemRadio3.Checked)
            {
                MessageBox.Show($"수박의 마진은 {MyDicMargin["수박"]}원 입니다.");
            }
        }

        private void buttonTotalMargin_Click(object sender, EventArgs e)
        {
            // 총 마진 보기
            int iTotalSaleMargin = 0;
            foreach (int iFruitMargin in MyDicMargin.Values)
            {

                iTotalSaleMargin += iFruitMargin;
            }
            MessageBox.Show($"금일 발생한 총 마진은 {iTotalSaleMargin}입니다.");
        }
    }
}
