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
        string[] itemsName = new string[] { "사과", "참외", "수박" };
        int[] itemsRetailPrice = new int[] { 2000, 2500, 18000 };
        int[] quantity = new int[] { 10, 10, 10 };
        int clientBalance = 100_000;
        int managerBalance = 100_000;
        int[] makedOrderQuantity = new int[] { 0, 0, 0 };
        int totalOrdersPayments = 0;
        
        public Chapter12_TestCode()
        {
            InitializeComponent();

            #region < set controls.Text values >
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
            #endregion
        }


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

        private void buttonToTalPayment_Click(object sender, EventArgs e)
        {
            // 총 결제금액 보기
            MessageBox.Show($"총 결제금액은 {totalOrdersPayments}원 입니다.");
        }

        private void buttonCancelOrder_Click(object sender, EventArgs e)
        {
            // 주문 취소하기
            totalOrdersPayments = 0;
            for (int i = 0; i < makedOrderQuantity.Length; i++)
            {
                quantity[i] += makedOrderQuantity[i];
                makedOrderQuantity[i] = 0;
            }
            labelQuantity1.Text = $"남은 개수 {quantity[0]}개";
            labelQuantity2.Text = $"남은 개수 {quantity[1]}개";
            labelQuantity3.Text = $"남은 개수 {quantity[2]}개";

        }

        private void buttonMakePayment_Click(object sender, EventArgs e)
        {
            // 결제하기
            if (totalOrdersPayments <= clientBalance)
            {
                clientBalance -= totalOrdersPayments;
                managerBalance += totalOrdersPayments;

                textBoxTransactionDetail1.Text += $"------------- 판매내역 -------------\r\n";
                for (int i = 0; i < makedOrderQuantity.Length; i++)
                {
                    if (makedOrderQuantity[i] > 0)
                    {
                        textBoxTransactionDetail1.Text += $"{itemsName[i]} 판매 개수 : {makedOrderQuantity[i]}, 판매 금액 : {makedOrderQuantity[i] * itemsRetailPrice[i]} \r\n";
                    }
                    makedOrderQuantity[i] = 0;
                }

                // set client value
                labelClientBalance.Text = $"고객 잔액 {clientBalance}원";

                // set manager value
                labelManagerBalance.Text = $"거래 잔액 {managerBalance}원";

                totalOrdersPayments = 0;

                MessageBox.Show("결제가 완료되었습니다.");
            }
            else
            {
                MessageBox.Show("주문 금액이 고객 잔액을 초과합니다. 주문할 수 없습니다.");
            }
        }

        private void buttonPlaceAOrder_Click(object sender, EventArgs e)
        {
            // 발주 입고
            int totalOrders;
            try
            {
                totalOrders = textBoxOderItem1.Text == "" ? 0 : Convert.ToInt32(textBoxOderItem1.Text) * itemsRetailPrice[0] * 60 / 100
                            + textBoxOderItem2.Text == "" ? 0 : Convert.ToInt32(textBoxOderItem2.Text) * itemsRetailPrice[1] * 60 / 100
                            + textBoxOderItem3.Text == "" ? 0 : Convert.ToInt32(textBoxOderItem3.Text) * itemsRetailPrice[2] * 60 / 100;

                if (textBoxOderItem1.Text == "" && textBoxOderItem2.Text == "" && textBoxOderItem3.Text == "")
                {
                    MessageBox.Show("발주 내역이 없습니다.");
                }
                else if (managerBalance < totalOrders)
                {
                    MessageBox.Show("발주할 총액이 잔액을 초과합니다. 발주할 수 없습니다.");
                }
                else
                {
                    managerBalance -= totalOrders;
                }
            }
            catch(FormatException ex)
            {
                MessageBox.Show($"숫자 값만 입력해주세요.");
                textBoxOderItem1.Text = "";
                textBoxOderItem2.Text = "";
                textBoxOderItem3.Text = "";
            }

        }

        private void buttonResetOrder_Click(object sender, EventArgs e)
        {
            // 전체 삭제
            deleteOrder();
        }

        private void buttonItemMargin_Click(object sender, EventArgs e)
        {
            // 개별 마진 보기
            if (buttonItemRadio1.Checked)
            {

            }
            else if (buttonItemRadio2.Checked)
            {

            }
            else if (buttonItemRadio3.Checked)
            {

            }
        }

        private void buttonTotalMargin_Click(object sender, EventArgs e)
        {

        }

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

        private void deleteOrder()
        {
            textBoxOderItem1.Text = string.Empty;
            textBoxOderItem2.Text = string.Empty;
            textBoxOderItem3.Text = string.Empty;
        }
    }
}
