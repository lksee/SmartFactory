using System;
using System.Collections;
using System.Windows.Forms;

namespace MyFirstCSharp_01
{
    public partial class Test_String : Form
    {
        public Test_String()
        {
            InitializeComponent();
        }

        private void buttonChangeString_Click(object sender, EventArgs e)
        {
            //아래의 문자열 중 첫번째 ? 와 세번째 ? 의 Index를 찾아
            //각 Index의 합의 Index에 있는 문자열 3자리를 구하고
            //xxx로 변경 후 텍스트박스에 표현하세요.

            // 텍스트
            string sText = labelText.Text;
            // 물음표 인덱스를 저장할 ArrayList 초기화.
            ArrayList alQuestionMarkIndexs = new ArrayList();

            // 물음표의 인덱스를 구하고 그 값을 ArrayList에 저장.
            for (int i = 0; i < sText.Length; i++)
            {
                if (sText[i] == '?') alQuestionMarkIndexs.Add(i); // 4, 14, 27, 35, 43
            }

            // 물음표 순서를 나타내는 변수
            int iCount = 1;
            // 첫번째와 세번째 인덱스들의 합을 구할 변수
            int iSumIndexes = 0;
            foreach (int iValue in alQuestionMarkIndexs)
            {
                // 첫번째 ? 와 세번째 ? 의 Index를 찾아 각 Index의 합 의 Index를 구하기.
                if (iCount == 1 || iCount == 3) iSumIndexes += iValue; // iSumIndexes --> 4+ 27 --> 31
                iCount++;
            }

            // Index에 있는 문자열 3자리를 구하고
            string sResult = sText.Substring(iSumIndexes, 3); // "나라만"

            // xxx로 변경 후 텍스트박스에 표현하세요.
            textBoxResult.Text = sText.Replace(sResult, "xxx");

        }
    }
}
