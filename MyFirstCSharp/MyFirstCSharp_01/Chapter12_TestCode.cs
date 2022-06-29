using System;
using System.Collections;
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
    public partial class Chapter12_TestCode : Form
    {
        #region < set fields >
        // 아이템 이름.
        string[] itemsName = new string[] { "사과", "참외", "수박" };
        // 아이템 소매가.
        int[] itemsRetailPrice = new int[] { 2000, 2500, 18000 };
        // 아이템 수량.
        int[] quantity = new int[] { 10, 10, 10 };

        // 고객 잔액
        int clientBalance = 100_000;
        // 관리자 잔액
        int managerBalance = 100_000;

        // 고객 결제 전 주문량
        int[] makedOrderQuantity = new int[] { 0, 0, 0 };
        // 고객 결제 전 총 주문액
        int totalOrdersPayments = 0;

        // 아이템별 판매 누적 개수
        int[] buyItem = new int[3] { 0, 0, 0 };
        // 아이템별 구매 누적 개수
        int[] sellItem = new int[3] { 0, 0, 0 };
        #endregion

        public Chapter12_TestCode()
        {
            InitializeComponent();

            loadValue();
            deleteOrder();
        }

        #region < 화면에 값을 로드한다. >
        private void loadValue()
        {
            // set item1 value 
            groupBoxItem1.Text = itemsName[0];
            labelItem1.Text = itemsName[0];
            buttonItemRadio1.Text = itemsName[0];
            buttonOrderItem1.Text = $"{itemsName[0]} 주문";
            labelPrice1.Text = $"{itemsRetailPrice[0]}원";
            labelQuantity1.Text = $"남은 개수 {quantity[0]}개";

            // set item2 value 
            groupBoxItem2.Text = itemsName[1];
            labelItem2.Text = itemsName[1];
            buttonItemRadio2.Text = itemsName[1];
            buttonOrderItem2.Text = $"{itemsName[1]} 주문";
            labelPrice2.Text = $"{itemsRetailPrice[1]}원";
            labelQuantity2.Text = $"남은 개수 {quantity[1]}개";

            // set item3 value 
            groupBoxItem3.Text = itemsName[2];
            labelItem3.Text = itemsName[2];
            buttonItemRadio3.Text = itemsName[2];
            buttonOrderItem3.Text = $"{itemsName[2]} 주문";
            labelPrice3.Text = $"{itemsRetailPrice[2]}원";
            labelQuantity3.Text = $"남은 개수 {quantity[2]}개";

            // set client value
            labelClientBalance.Text = $"고객 잔액 {clientBalance}원";

            // set manager value
            labelManagerBalance.Text = $"거래 잔액 {managerBalance}원";
        }
        #endregion

        #region < 고객 아이템별 주문 버튼>
        private void buttonOrderItem1_Click(object sender, EventArgs e)
        {
            // make a order item1
            MakeAOrder(labelQuantity1, 0);
        }

        private void buttonOrderItem2_Click(object sender, EventArgs e)
        {
            // make a order item2
            MakeAOrder(labelQuantity2, 1);
        }

        private void buttonOrderItem3_Click(object sender, EventArgs e)
        {
            // make a order item3
            MakeAOrder(labelQuantity3, 2);
        }
        #endregion

        #region < 고객 총 결제금액 보기 >
        private void buttonToTalPayment_Click(object sender, EventArgs e)
        {
            // 총 결제금액 보기
            MessageBox.Show($"총 결제금액은 {totalOrdersPayments}원 입니다.");
        }
        #endregion

        #region < 고객 주문 취소하기 >
        private void buttonCancelOrder_Click(object sender, EventArgs e)
        {
            if (totalOrdersPayments == 0)
            {
                MessageBox.Show("취소할 내역이 없습니다.");
                return;
            }
            // 주문 취소하기
            totalOrdersPayments = 0;

            // 주문 전 quantity로 값을 되돌리고, 주문량을 0으로 초기화한다.
            for (int i = 0; i < makedOrderQuantity.Length; i++)
            {
                quantity[i] += makedOrderQuantity[i];
                makedOrderQuantity[i] = 0;
            }
            loadValue();
        }
        #endregion

        #region < 고객 결제하기 >
        private void buttonMakePayment_Click(object sender, EventArgs e)
        {
            // 결제하기
            // 잔액 범위 내에서 주문 가능
            if (totalOrdersPayments <= clientBalance)
            {
                // 총 주문액수만큼 고객 잔고에서 차감하고, 관리자 잔고에 증액한다.
                clientBalance -= totalOrdersPayments;
                managerBalance += totalOrdersPayments;

                // 판매내역 출력, 판매 수량 기록, 주문 초기화
                textBoxTransactionDetail1.Text += $"--------------- 판매내역 ---------------\r\n";
                for (int i = 0; i < makedOrderQuantity.Length; i++)
                {
                    if (makedOrderQuantity[i] > 0)
                    {
                        textBoxTransactionDetail1.Text += $"{itemsName[i]} 판매 개수 : {makedOrderQuantity[i]}, 판매 금액 : {makedOrderQuantity[i] * itemsRetailPrice[i]} \r\n";
                        sellItem[i] += makedOrderQuantity[i];
                    }
                    makedOrderQuantity[i] = 0;
                }

                loadValue();

                // 주문 총액 초기화
                totalOrdersPayments = 0;

                MessageBox.Show("결제가 완료되었습니다.");
            }
            else
            {
                MessageBox.Show("주문 금액이 고객 잔액을 초과합니다. 주문할 수 없습니다.");
            }
        }
        #endregion

        #region < 관리자 발주 입고 >
        private void buttonPlaceAOrder_Click(object sender, EventArgs e)
        {
            // 발주 입고

            // 3개의 textBox에 값이 없는 경우에 대한 처리.
            if (textBoxOderItem1.Text == "" && textBoxOderItem2.Text == "" && textBoxOderItem3.Text == "")
            {
                MessageBox.Show("발주 내역이 없습니다.");
                return;
            }

            // 발주 총액
            int totalOrders = 0;
            // 아이템별 발주량
            int[] quantityItem = new int[3];
            // 입력 값을 담는 string 배열
            string[] sValues = new string[3] { textBoxOderItem1.Text, 
                                               textBoxOderItem2.Text, 
                                               textBoxOderItem3.Text };

            // 발주 입력 값이 string.Empty인 경우 "0"으로 처리.
            for (int i = 0; i < sValues.Length; i++)
            {
                if (sValues[i] == "")
                {
                    sValues[i] = "0";
                }
            }

            // int로 형변환 성공하면 그 값을, 실패하면 0 값을 quantityItem에 assignment.
            bool bChangeSuccess1 = int.TryParse(sValues[0], out quantityItem[0]);
            bool bChangeSuccess2 = int.TryParse(sValues[1], out quantityItem[1]);
            bool bChangeSuccess3 = int.TryParse(sValues[2], out quantityItem[2]);

            // textBox의 값을 숫자로 변환할 수 없는 경우
            if (bChangeSuccess1 && bChangeSuccess2 && bChangeSuccess3)
            {
                // 발주할 금액 전체 합산
                for (int i = 0; i < quantityItem.Length; i++)
                {
                    totalOrders += quantityItem[i] * itemsRetailPrice[i] * 60 / 100;
                }

                // 발주할 금액이 잔액보다 많으면 주문할 수 없다.
                if (managerBalance < totalOrders)
                {
                    MessageBox.Show("발주할 총액이 잔액을 초과합니다. 발주할 수 없습니다.");
                    deleteOrder();
                }
                // 발주 수량을 음수로 입력하면 발주할 수 없다.
                else if (checkValidValue(quantityItem))
                {
                    MessageBox.Show("발주 수량은 1 이상의 값을 입력하세요.");
                    deleteOrder();
                }
                // 정상적인 발주의 처리
                else
                {
                    //발주 총액을 관리자 잔고에서 차감
                    managerBalance -= totalOrders;

                    // 구매내역 출력, 구매 수량 기록, 판매 수량 증가분 반영
                    textBoxTransactionDetail1.Text += $"--------------- 구매내역 ---------------\r\n";
                    for (int i = 0; i < quantityItem.Length; i++)
                    {
                        if (quantityItem[i] > 0)
                        {
                            textBoxTransactionDetail1.Text += $"{itemsName[i]} 구매 개수 : {quantityItem[i]}, 구매 금액 : {quantityItem[i] * itemsRetailPrice[i] * 60 / 100} \r\n";
                            buyItem[i]  += quantityItem[i];
                            quantity[i] += quantityItem[i];
                        }
                    }

                    loadValue();
                    deleteOrder();
                }
            }
            // 양의 정수가 아닌 값을 입력하는 경우
            else
            {
                MessageBox.Show($"양의 정수 값만 입력해주세요.");
                deleteOrder();
            }
        }
        #endregion

        #region < int[]에 음수 값이 있으면 true, 아니면 false >
        private bool checkValidValue(int[] quantityItem)
        {
            foreach (int qty in quantityItem)
            {
                if (qty < 0)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region < 발주 초기화 >
        private void buttonResetOrder_Click(object sender, EventArgs e)
        {
            // 전체 삭제
            deleteOrder();
        }
        #endregion

        #region < 관리자 개별 마진 보기 >
        private void buttonItemMargin_Click(object sender, EventArgs e)
        {
            // 개별 마진 보기
            if (buttonItemRadio1.Checked)
            {
                calcMargin(0);
            }
            else if (buttonItemRadio2.Checked)
            {
                calcMargin(1);
            }
            else if (buttonItemRadio3.Checked)
            {
                calcMargin(2);
            }
        }
        #endregion

        #region < 관리자 아이템별 마진 구하기 >
        private void calcMargin(int iIndex)
        {
            int marginItem = sellItem[iIndex] * itemsRetailPrice[iIndex] - buyItem[iIndex] * itemsRetailPrice[iIndex] * 60 / 100;

            MessageBox.Show($"{itemsName[iIndex]} 아이템에 대한 요약입니다.\r\n" +
                            $" {itemsRetailPrice[iIndex]} 원에 {sellItem[iIndex]}개 판매하였고, \r\n" +
                            $"{itemsRetailPrice[iIndex] * 60 / 100} 원에 {buyItem[iIndex]}개 구입하였습니다. \r\n" +
                            $"{itemsName[iIndex]} 아이템에 대한 마진은 {marginItem} 원 입니다.");
        }
        #endregion

        #region < 관리자 총 마진 보기 >
        private void buttonTotalMargin_Click(object sender, EventArgs e)
        {
            // 총 마진 보기
            int marginItem = 0;
            string sMessage = "";
            for (int i = 0; i < itemsRetailPrice.Length; i++)
            {
                marginItem += sellItem[i] * itemsRetailPrice[i] - buyItem[i] * itemsRetailPrice[i] * 60 / 100;
                sMessage += $"{itemsName[i]} 아이템에 대한 요약입니다. \r\n" +
                            $"{itemsRetailPrice[i]} 원에 {sellItem[i]}개 판매하였고, \r\n" +
                            $"{itemsRetailPrice[i] * 60 / 100} 원에 {buyItem[i]}개 구입하였습니다.\r\n";
            }
            sMessage += $"총 마진은 {marginItem} 원 입니다.";
            MessageBox.Show(sMessage);
        }
        #endregion

        #region < 고객 주문 프로세스 >
        private void MakeAOrder(Label label, int quantityIndex)
        {
            if (quantity[quantityIndex] == 0)
            {
                MessageBox.Show("주문할 수 없습니다.");
            }
            else
            {
                label.Text = $"남은 개수 {--quantity[quantityIndex]}개";
                makedOrderQuantity[quantityIndex]++;

                totalOrdersPayments = 0;
                for (int i = 0; i < quantity.Length; i++)
                {
                    totalOrdersPayments += itemsRetailPrice[i] * makedOrderQuantity[i];
                }
            }
        }
        #endregion

        #region < 관리자 발주 초기화 >
        private void deleteOrder()
        {
            textBoxOderItem1.Text = string.Empty;
            textBoxOderItem2.Text = string.Empty;
            textBoxOderItem3.Text = string.Empty;
        }
        #endregion
    }
}
