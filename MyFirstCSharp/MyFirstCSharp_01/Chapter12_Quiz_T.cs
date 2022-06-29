using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace MyFirstCSharp_01
{
    public partial class Chapter12_Quiz_T : Form
    {
        int[] iRandomValues;
        Dictionary<string, int> alTextBox = new Dictionary<string, int>();
        int iIndex = 0;

        public Chapter12_Quiz_T()
        {
            InitializeComponent();

            // Form 내 모든 textBox를 ArrayList에 담기
            foreach (Control ctl in this.Controls)
            {
                if (ctl is TextBox)
                {
                    alTextBox[ctl.Name] = iIndex++;
                    
                }
            }
            iRandomValues = new int[alTextBox.Count];
        }

        private void buttonMakeRandomValue_Click(object sender, EventArgs e)
        {
            if (alTextBox.Count == iIndex) iIndex = 0;
            Random random = new Random();

            for (int i = 0; i < alTextBox.Count; i ++)
            {
                if (iIndex == i)
                {
                    iRandomValues[iIndex] = random.Next(0, 100);
                    //alTextBox.Text = Convert.ToString(iRandomValues[iIndex++]);
                }
            }
        }
    }
}
