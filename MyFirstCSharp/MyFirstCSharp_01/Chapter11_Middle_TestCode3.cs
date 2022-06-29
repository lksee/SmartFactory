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
    public partial class Chapter11_Middle_TestCode3 : Form
    {
        string sText = "ABCLD/EML/BAMDC/";

        public Chapter11_Middle_TestCode3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Dictionary와 foreach를 사용하는 방식
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (char c in sText)
            {
                if (dict.ContainsKey(c))
                {
                    dict[c] += 1;

                }
                else
                {
                    dict[c] = 0;
                }
            }
            foreach (char c in sText)
            {
                if (dict[c] == 0)
                {
                    MessageBox.Show($"중복되지 않는 문자 중 왼쪽에서 가장 첫 문자는 {c} 입니다.");
                    break;
                }
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // LastIndexOf() 방식
            foreach (char ch in sText)
            {
                if(sText.IndexOf(ch) == sText.LastIndexOf(ch))
                {
                    MessageBox.Show($"중복되지 않는 문자 중 왼쪽에서 가장 첫 문자는 {ch} 입니다.");
                    break;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 둘 다 사용하지 않고 하는 방식
            
            foreach(char ch in sText)
            {
                if ($" {sText} ".Split(ch).Length == 2)
                {
                    MessageBox.Show($"중복되지 않는 문자 중 왼쪽에서 가장 첫 문자는 {ch} 입니다.");
                    break;
                }
            }
        }
    }
}
