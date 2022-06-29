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
    public partial class Chapter09_Switch_BranchingStatement : Form
    {
        public Chapter09_Switch_BranchingStatement()
        {
            InitializeComponent();
        }

        #region < switch 문 활용 >
        private void button1_Click(object sender, EventArgs e)
        {
            // 1. TextBox에 입력한 과일 이름 변수에 담기.
            string sFruitName = textBox1.Text.Trim();

            // 2. 과일의 가격 int 변수
            int iResult = 0;

            switch(sFruitName)
            {
                case "사과":
                    iResult = 3000;
                    break;
                case "참외":
                    iResult = 1500;
                    break;
                case "수박":
                    iResult = 13000;
                    break;
                case "바나나":
                    iResult = 3990;
                    break;
                default:
                    iResult = 0;
                    break;
            }
            _showMessage(sFruitName, iResult);
        }
        private void _showMessage(in string sFruitName, in int iFruitPrice)
        {
            if (iFruitPrice == 0)
            {
                MessageBox.Show($"{sFruitName}은 취급하지 않습니다.");
            }
            else
            {
                MessageBox.Show($"{sFruitName}의 값은 {Convert.ToString(iFruitPrice)} 입니다. 몇 개 드릴까요?");
            }
        }
        #endregion
    }
}
