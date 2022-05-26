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
    public partial class Chapter05_practice : Form
    {
        const string sText = "안녕하세요 2022 스마트 팩토리 S/W 개발 교육 과정을 이수 하게된 OOO 입니다.즐겁고 보람찬 SMARTFACTORY  교육 이 되었으면 합니다.";
        const string sDefaultName = "OOO";
        const string sName = "이기수";
        const string sValue1 = "S/W";
        const string sValue2 = "-품질재단-";
        const string sValue3 = "SMARTFACTORY";
        
        int iNameIndex = sText.IndexOf(sDefaultName);
        int iNameLength = sDefaultName.Length;
        string sChangedText;

        public Chapter05_practice()
        {
            InitializeComponent();
            label1.Text = sText;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sChangedText = label1.Text.Replace(sDefaultName, sName);
            label1.Text = sChangedText;
            iNameIndex = sChangedText.IndexOf(sName);
            iNameLength = sName.Length;
            //MessageBox.Show(sChangedText);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Convert.ToString(label1.Text.IndexOf(sValue1)));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = label1.Text.Insert(label1.Text.Length, sValue2).Insert(0, sValue2);
            iNameIndex = iNameIndex + sValue2.Length;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(label1.Text.Substring(label1.Text.IndexOf('.')+1));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(label1.Text.Substring(iNameIndex, iNameLength));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string s_ = label1.Text.Substring(label1.Text.IndexOf(sValue3)).ToLower();
            label1.Text = label1.Text.Remove(label1.Text.IndexOf(sValue3)) + s_;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label1.Text = sText.Remove(sText.IndexOf('.') + 1);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label1.Text = label1.Text.Replace(" ", "");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            label1.Text = sText;
        }
    }
}
