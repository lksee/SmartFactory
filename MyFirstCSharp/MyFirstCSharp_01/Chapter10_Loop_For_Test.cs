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
    public partial class Chapter10_Loop_For_Test : Form
    {
        public Chapter10_Loop_For_Test()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if(_validInputValue2())
            {
                int iResult = calcValue(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), 2);
                MessageBox.Show(Convert.ToString(iResult));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_validInputValue2())
            {
                int iResult = calcValue(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), 5);
                MessageBox.Show(Convert.ToString(iResult));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_validInputValue2())
            {
                int iResult = calcValue(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), 10);
                MessageBox.Show(Convert.ToString(iResult));
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _validInputValue(sender);
        }

        private void _validInputValue(object sender)
        {
            int iValue;
            TextBox txtBox1 = sender as TextBox;

            // string --> int : Fail
            if (!int.TryParse(txtBox1.Text, out iValue))
            {
                if (txtBox1.Text != "")
                {
                    MessageBox.Show("숫자만 입력 가능합니다.");
                    txtBox1.Text = "";
                    return;
                }
            }
            else if (iValue < 0)
            {
                MessageBox.Show("0보다 큰 수를 입력해주세요.");
                txtBox1.Text = "";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            _validInputValue(sender);
        }

        private bool _validInputValue2()
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("값을 입력해주세요.");
                return false;
            }
            if(Convert.ToInt32(textBox1.Text) >= Convert.ToInt32(textBox2.Text))
            {
                MessageBox.Show("올바른 범위를 입력해주세요.");
                return false;
            }
            return true;
        }

        private int calcValue(int iValue1, int iValue2, int iValue3)
        {
            int iTotal = 0;
            for (int i = iValue1; iValue1 <= iValue2; iValue1++)
            {
                if (iValue1 % iValue3 == 0)
                {
                    iTotal += iValue1;
                }
            }
            return iTotal;
        }
    }
}
