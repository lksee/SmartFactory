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
    public partial class Chapter15_Exam03 : Form
    {
        public Chapter15_Exam03()
        {
            InitializeComponent();
        }

        private void buttonSumValues_Click(object sender, EventArgs e)
        {
            // 난수 20개 생성하기.
            Random random = new Random();
            
            // 난수 20개를 받을 배열 선언하기.
            int[] iArray = new int[20];
            
            // 난수를 생성하여 배열에 담기.
            for (int i = 0; i < iArray.Length; i++)
            {
                iArray[i] = random.Next(0, 20);
            }

            // 배열 오름차순 정렬하기
            Array.Sort(iArray);
            //Array.Reverse(iArray); // Array.Sort 기능과 함께 사용하면 내림차순 정렬

            foreach (int iValue in iArray)
            {
                // 텍스트 박스에 배열에 있는 수를 하나씩 가져와서 누적 표현
                textBoxResult.Text += Convert.ToString(iValue) + " ";
            }

            // 배열에 있는 값 중 없는 값을 담을 변수
            string sMessage = string.Empty;
            // 없는 값의 합을 누적시킬 변수
            int iResult = 0;
            for (int i = 0; i <= 20; i++)
            {
                int iIndex = Array.IndexOf(iArray, i);
                if (iIndex == -1) // 배열에 비교할 값이 없다면 return -1
                {
                    iResult += i; // 없는 수 결과 값에 합산하기.
                    sMessage += Convert.ToString(i) + " ";
                }
            }

            // 결과 검색을 다 마친 후 메시지 표현.
            MessageBox.Show($"난수 중 {sMessage} 수가 없으며 총합은 {iResult}입니다.");
        }
    }
}
