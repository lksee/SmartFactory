using System;
using System.Collections;
using System.Windows.Forms;

namespace MyFirstCSharp_01
{
    public partial class Test_Array_RandomValues : Form
    {
        // 랜덤으로 생성할 숫자의 개수
        int iCount = 20;
        // 랜덤으로 생성할 숫자의 시작 값
        int iStartNum = 0;
        // 램덤으로 생성할 숫자의 끝 값
        int iEndNum = 20;
        // 랜덤으로 생성한 숫자를 담는 배열
        int[] iaRandomValues;
        // 난수 발생을 위한 단일 random instance
        Random random = new Random();

        public Test_Array_RandomValues()
        {
            InitializeComponent();
        }

        private void buttonSumValues_Click(object sender, EventArgs e)
        {
            // 랜덤함수로 0부터 20까지의 수를 20개 받아 배열에 담아
            // 오름차순으로 정렬하여 텍스트박스에 표현 후
            // 0부터 20까지 수 중 없는 수를 모두 합한 결과를 메시지로 표현하시오.

            // textBox 초기화
            textBoxResult.Text = "";

            // 랜덤함수로 0부터 20까지의 수를 20개 받아 배열에 담아
            iaRandomValues = new int[iCount];
            for (int i = 0; i < iaRandomValues.Length; i++)
            {
                iaRandomValues[i] = random.Next(iStartNum, iEndNum);
            }

            // 오름차순으로 정렬하여 텍스트박스에 표현 후
            Array.Sort(iaRandomValues);
            for (int i = 0; i < iaRandomValues.Length; i++)
            {
                textBoxResult.Text += $"{iaRandomValues[i]} ";
            }

            // 0~20 숫자를 가진 ArrayList
            ArrayList alNonExistValues = new ArrayList();
            for (int i = iStartNum; i <= iEndNum; i++)
            {
                alNonExistValues.Add(i);
            }

            // 0부터 20까지 수 중 없는 수 구하기.
            foreach (int i in iaRandomValues)
            {
                if(alNonExistValues.Contains(i)) alNonExistValues.Remove(i);
            }

            // 0부터 20까지 수 중 없는 수
            int iSumNonExistValues = 0;
            // 최종 메시지
            string sMessage = "난수중 ";

            // 0부터 20까지 수 중 없는 수를 모두 합하기
            foreach (int i in alNonExistValues)
            {
                sMessage += $"{i} ";
                iSumNonExistValues += i;
            }
            sMessage += $"가 없으며 총 합은 {iSumNonExistValues} 입니다.";

            // 메시지로 표현
            MessageBox.Show(sMessage);
        }
    }
}
