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
    public partial class Chapter11_Middle_TestCode4 : Form
    {
        public Chapter11_Middle_TestCode4()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 중복되지 않는 문자열 찾기 (for in for)

            // 비교해야 할 문자열 변수에 등록
            string sTitle = label2.Text;
            string sBaseString = string.Empty; // 비교할 기준 문자
            string sCheckString = string.Empty; // 비교될 문자

            bool bFind = false;

            // 기준 문자열 찾기
            for (int i = 0; i < sTitle.Length; i++)
            {
                sBaseString = sTitle.Substring(i, 1);
                for (int k = sTitle.Length - 1; k >= 0; k--)
                {
                    sCheckString = sTitle.Substring(k, 1);
                    if (i == k) // 같은 문자가 비교할 기준 문자 자기 자신 밖에 없음.
                    {
                        bFind = true;
                        break;
                    }
                    if (sBaseString == sCheckString) // 비교할 기준 문자와 비교될 문자가 일치할 때 1. 자기 자신 2. 중복된 문자
                    {
                        break;
                    }
                }
                if (!bFind) break;
            }
            MessageBox.Show($"중복되지 않는 첫 문자는 {sBaseString} 입니다.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 중복되지 않는 문자열 찾기 (LastIndexOf)
            string sTitle = label2.Text;
            string sBaseString = string.Empty;  // 비교할 기준 문자
            int iLastIndex = 0;

            bool bCheckFind = false; // 문자를 찾았는지 못 찾았는지
            for (int i = 0; i < sTitle.Length; i++)
            {
                sBaseString = sTitle.Substring(i, 1);
                iLastIndex = sTitle.LastIndexOf(sBaseString); // 기준문자가 포함되어 있는 마지막 Index
                if (i == iLastIndex)
                {
                    bCheckFind = true;
                    break;
                }
            }
            if (bCheckFind) MessageBox.Show($"중복되지 않는 첫 문자는 {sBaseString} 입니다.");
            else MessageBox.Show("중복되지 않은 문자가 없습니다.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 중복되지 않는 문자 찾기(dictionary foreach)
            Dictionary<char, int> dMydic = new Dictionary<char, int>();

            foreach (char BaseString in label1.Text)
            {
                if (dMydic.ContainsKey(BaseString))
                {
                    dMydic[BaseString] = dMydic[BaseString] + 1;
                }
                else
                {
                    dMydic[BaseString] = 1;
                }
            }

            // 딕셔너리에 넣은 키와 값 중 값이 1인 가장 첫 데이터를 찾기.
            foreach (char sValue in label1.Text)
            {
                if (dMydic[sValue] == 1)
                {
                    MessageBox.Show($"중복되지 않은 가장 첫 문자는 {sValue} 입니다.");
                    break;
                }
            }
        }
    }
}

