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
    public partial class Chapter12_Quiz4 : Form
    {
        int[] iValues;

        public Chapter12_Quiz4()
        {
            InitializeComponent();

            // 레이블 텍스트 -> string[] -> int[]로 초기화.
            string[] sValues = labelValue.Text.Split(',');
            iValues = new int[sValues.Length];
            for (int i = 0; i < sValues.Length; i++)
            {
                iValues[i] = Convert.ToInt32(sValues[i].Trim());
            }
        }

        private void buttonSortDesc_Click(object sender, EventArgs e)
        {
            // 삽입 정렬 구현.
            for (int i = 0; i < iValues.Length - 1; i++)
            {
                try
                {
                    for (int j = i + 1; j > 0 && iValues[j - 1] < iValues[j]; j--)
                    {
                        int _ = iValues[j-1];
                        iValues[j - 1] = iValues[j];
                        iValues[j] = _;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"{ex.Message}");
                }
            }


            // int[] -> string.
            string sResults = "";
            foreach (int i in iValues)
            {
                sResults += $", {i}";
            }
            sResults = sResults.TrimStart(',', ' ');

            textBoxResult.Text = sResults;
        }
    }
}
