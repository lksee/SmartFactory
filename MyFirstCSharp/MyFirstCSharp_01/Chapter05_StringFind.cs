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
    public partial class Chapter05_StringFind : Form
    {
        string sTitle = "동해물과 백두산이 마르고 닳도록 하느님이 보우하사 우리 나라 만세!😃";

        public Chapter05_StringFind()
        {
            InitializeComponent();
            label1.Text = sTitle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // IndexOf() : 문자열 내에서 찾고자 하는 지정된 문자 또는 문자열의 위치 Index 찾기.

            // 1. 타이틀 레이블에 있는 문자열 문자 변수에 등록
            string sTitle = label1.Text;

            // 2. 사용자 지정한 문자
            string sIndex = textBox1.Text;

            // 3. 위치 표시하기 IndexOf는 int 형식을 반환(return)한다.(=int type의 output을 돌려준다.)
            int iIndex = sTitle.IndexOf(sIndex);

            // 4. 메시지 박스로 겨로가 표현하기
            MessageBox.Show(Convert.ToString(iIndex));

            // 위치 정보로 응용할 수 있는 예제
            // 해당 문자열의 위치 Index를 찾아서 그 위치 뒤 내용을 모두 삭제
            label1.Text = sTitle.Remove(iIndex);

            //textBox1.Text가 빈 값으로 버튼을 누르면 sIndex 값이 ""(=empty string)이 된다.
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // LastIndexOf : 문자열의 뒤에서부터 찾아 해당 위치가 몇 번째 인덱스에 있는 지 int 값 반환

            // 1. 타이틀 레이블에 있는 문자열 문자 변수에 등록
            string sTitle = label1.Text;

            // 2. 사용자가 지정한 문자
            string sIndex = textBox2.Text;

            // 3. 위치 표시하기 (int type의 결과값 반환)
            int iIndex = sTitle.LastIndexOf(sIndex);

            // 4. 메시지 박스로 출력하기
            MessageBox.Show(Convert.ToString(iIndex) + " 번째 위치에 있습니다.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // StartWith() : 현재 문자열이 해당 문자열로 시작되는 지 판단

            // 1. 타이틀 레이블에 있는 문자열을 문자 변수에 등록
            string sTitle = label1.Text;

            // 2. 사용자가 지정한 문자를 sStartswith 변수에 저장
            string sStartsWith = textBox3.Text;

            // 3. 판단 결과 반환 boolean
            bool bStartWith = sTitle.StartsWith(sStartsWith);

            // 4. 메시지 박스로 출력하기
            MessageBox.Show(Convert.ToString(bStartWith));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // EndsWith() : 현재 문자열이 해당 문자열로 끝나는 지 판단

            // 1. 타이틀 레이블에 있는 문자열 문자 변수에 등록
            string sTitle = label1.Text;

            // 2. 사용자가 지정한 문자를 변수에 등록
            string sEndsWith = textBox4.Text;

            // 3. 판단 결과 반환 boolean
            bool bEndsWith = sTitle.EndsWith(sEndsWith);

            // 4. 메시지 박스로 출력하기
            MessageBox.Show(Convert.ToString(bEndsWith));

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Contains() : 현재 문자열이 지정한 문자열을 포함하는 지 결과를 반환

            // 1. 타이틀 레이블에 있는 문자열 문자 변수에 등록
            string sTitle = label1.Text;

            // 2. 사용자가 지정한 문자
            string sContains = textBox5.Text;

            // 3. 문자를 포함하는 지 결과값 반환
            bool bContains = sTitle.Contains(sContains);

            // 4. 메시지 박스로 출력하기
            MessageBox.Show(Convert.ToString(bContains));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Replace : 문자열 변환
            MessageBox.Show(label1.Text.Replace(textBox6.Text, textBox7.Text));
        }
    }
}
