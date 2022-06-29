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
    public partial class Chapter11_Middle_Exam_TestCode2 : Form
    {
        public Chapter11_Middle_Exam_TestCode2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] iaValue = new int[7] { 1, 4, 6, 9, 10, 12, 16 };
            ArrayList alResult = new ArrayList();
            int iaValueLength = iaValue.Length;
            Array.Sort(iaValue);
            
            for (int i = 0; i < iaValueLength; i++)
            {
                if (iaValue.Contains(16 - iaValue[i]))
                {
                    int[] iaResult = new int[2];
                    iaResult[0] = iaValue[i];
                    iaResult[1] = 16 - iaValue[i];

                    //Array.Sort(iaResult);

                    alResult.Add(iaResult);
                }
            }


            // 출력 부분.
            string sText = string.Empty;
            foreach (object obj in alResult)
            {
                int[] _ = (int[]) obj;
                sText += Convert.ToString($"{_[0]}, {_[1]} \r\n");
            }
            MessageBox.Show(sText);
        }
    }
}
