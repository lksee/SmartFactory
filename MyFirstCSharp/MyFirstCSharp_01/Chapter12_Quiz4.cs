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

            string[] sValues = labelValue.Text.Split(',');
            iValues = new int[sValues.Length];
            for (int i = 0; i < sValues.Length; i++)
            {
                iValues[i] = Convert.ToInt32(sValues[i].Trim());
            }
        }

        private void buttonSortDesc_Click(object sender, EventArgs e)
        {
            string sResults = "";
            int[] iResults = new int[iValues.Length];

            for (int i = 0; i < iResults.Length; i++)
            {
                int iMax = 0;
                foreach (int iValue in iValues)
                {
                    if (iResults.Contains(iValue)) continue;
                    if (iMax < iValue)
                    {
                        iMax = iValue;
                    }
                }
                iResults[i] = iMax;
            }

            foreach (int i in iResults)
            {
                sResults += $", {i}";
            }
            sResults = sResults.TrimStart(',', ' ');

            textBoxResult.Text = sResults;
        }
    }
}
