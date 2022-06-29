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
    public partial class Chapter12_Quiz3 : Form
    {
        Random random = new Random();
        int iARideFee;   // 100~3000
        int iRideNumber; // 1~20
        int iRideAmount; // 10000~500000

        public Chapter12_Quiz3()
        {
            InitializeComponent();
            initialRandomValue();
            loadValues();
        }

        private void loadValues()
        {
            textBoxARideFee.Text = iARideFee.ToString();
            textBoxRideNumber.Text = iRideNumber.ToString();
            textBoxRideAmount.Text = iRideAmount.ToString();
        }

        private void initialRandomValue()
        {
            iARideFee = random.Next(1, 30) * 100;
            iRideNumber = random.Next(1, 20);
            iRideAmount = random.Next(1, 50) * 10000;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int iSum = 0;
            string sMessage = $"{iRideAmount}원이 있을 때 이용요금 {iARideFee}인 놀이기구를 {iRideNumber}번 타면 ";
            for (int i = 1; i <= iRideNumber; i++)
            {
                iSum += iARideFee * i;
            }

            if (iSum < iRideAmount)
            {
                sMessage += $"{iRideAmount - iSum}원이 남습니다.";
            }
            else
            {
                sMessage += $"{iSum - iRideAmount}원이 모자랍니다.";
            }

            MessageBox.Show(sMessage);

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            initialRandomValue();
            loadValues();
        }
    }
}
