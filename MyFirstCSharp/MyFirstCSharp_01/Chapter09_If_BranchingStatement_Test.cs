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
    public partial class Chapter09_If_BranchingStatement_Test : Form
    {
        const string sText1 = "2와 5의 공배수입니다.";
        const string sText2 = "2와 5의 공배수가 아닙니다.";
        const string sText3 = "1~100까지의 자연수를 입력해주세요.";

        int iCount = 0;
        int iValue;

        public Chapter09_If_BranchingStatement_Test()
        {
            InitializeComponent();
            textBox3.Text = Convert.ToString(iCount);
        }

        #region < 2와 5의 공배수 찾는 기능 및 8배수에 대한 별도 처리 >
        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = Convert.ToString(++iCount);
            if (int.TryParse(textBox1.Text, out iValue) && iValue >= 1 && iValue <= 100)
            {
                // 2와 5의 공배수일 때.
                if (iValue % 2 == 0 && iValue % 5 == 0)
                {
                    MessageBox.Show(sText1);
                }
                else
                {
                    MessageBox.Show(sText2);
                }
                // 8배수 확인
                _is8multiple(iValue);
            }
            else
            {
                MessageBox.Show(sText3);
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }
        private void _is8multiple(int iValue)
        {
            if (iValue % 8 == 0)
            {
                textBox2.Text = Convert.ToString(iValue * 8);
            }
            else
            {
                textBox2.Text = "";
            }
        }
        #endregion
    }
}
