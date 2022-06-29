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
            // 이름
            sChangedText = label1.Text.Replace(sDefaultName, sName);
            label1.Text = sChangedText;
            iNameIndex = sChangedText.IndexOf(sName);
            iNameLength = sName.Length;
            //MessageBox.Show(sChangedText);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // S/W 위치 찾기
            MessageBox.Show(Convert.ToString(label1.Text.IndexOf(sValue1)));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // -품질재단- 문구 앞, 뒤에 추가
            //label1.Text = label1.Text.Insert(label1.Text.Length, sValue2).Insert(0, sValue2);
            label1.Text = $"{sValue2}{label1.Text}{sValue2}";
            iNameIndex = iNameIndex + sValue2.Length;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 두번째 문장 표현
            MessageBox.Show(label1.Text.Substring(label1.Text.IndexOf('.')+1));

            // 선생님 방법.
            //string[] sValue = label1.Text.Split('.');
            //MessageBox.Show(sValue[1]);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //문자열 중 본인 이름만 찾아서 메시지박스로 표현
            MessageBox.Show(label1.Text.Substring(iNameIndex, iNameLength));

            // 선생님 방법.
            //int iIndex = label1.Text.IndexOf(sName);
            //string sResult = label1.Text.Substring(iIndex, 3);
            //MessageBox.Show(sResult);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // SMARTFACTORY만 소문자로 변환

            // 처리할 문자열
            string s_ = label1.Text.Substring(label1.Text.IndexOf(sValue3)).ToLower();
            label1.Text = label1.Text.Remove(label1.Text.IndexOf(sValue3)) + s_;

            // 선생님 방법.
            //string sValue = "SMARTFACTORY";
            //int iIndex = label1.Text.IndexOf(sValue);

            //// 위치에서 글자수만큼 원본 문자열에서 삭제
            ////string sResult = label1.Text.Remove(iIndex, 12);
            //string sResult = label1.Text.Remove(iIndex, sValue.Length);

            //// 위치에 소문자로 변경된 문구 입력
            //string sResult2 = sValue.ToLower();
            //label1.Text = sResult.Insert(iIndex, sResult2);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // 레이블에 기준 두번째 문장을 삭제 후 표시
            // = 첫번째 문장만 표현하세요.
            label1.Text = sText.Remove(sText.IndexOf('.') + 1);
            //string[] sValue = label1.Text.Split('.');
            //label1.Text = sValue[0];
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // 모든 공백 없애기
            label1.Text = label1.Text.Replace(" ", "");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // 되돌리기
            label1.Text = sText;
        }
    }
}
