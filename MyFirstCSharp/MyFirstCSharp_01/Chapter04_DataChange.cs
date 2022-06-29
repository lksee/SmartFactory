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
    // 데이터 타입 형변환(숫자 -> 문자, 문자 -> 숫자)
    // 숫자 -> 문자열로 형변환 .ToString(), Convert.ToString()
    // 문자열 -> 숫자로 형변환 Parse(),     Convert.To***(),     TryParse()
    public partial class Chapter04_DataChange : Form
    {
        public Chapter04_DataChange()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 숫자 -> 문자로 형변환

            // 변환될 숫자 형식 데이터 예제 생성
            int iValue1 = 10;
            int iValue2 = 20;
            double dValue = 10.4;

            // 반환(return)된 문자를 저장할 변수 생성
            string sValue1;
            string sValue2;

            // 1. .ToString() 명령어로 문자로 형변환 후 대입
            sValue1 = iValue1.ToString();
            MessageBox.Show(sValue1);

            // 2. Convert.ToString() 명령어로 문자로 형변환 후 대입
            sValue2 = Convert.ToString(iValue2);
            MessageBox.Show(sValue2);

            string sSumString = sValue1 + sValue2;
            MessageBox.Show(sSumString);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 문자 -> 숫자로 형변환

            // 1. 숫자로 바꿀 문자열 변수, 값 예제 데이터 생성.
            string sValue1 = "안녕하세요.";
            string sValue2 = "10";
            string sValue3 = "10.12";

            // 2. 형변환되어 반환된 숫자를 저장할 숫자 type의 변수 생성
            int iValue1;
            int iValue2;
            double dValue1;

            //// 3. Parse()로 형변환
            ////iValue1 = int.Parse(sValue1); // 숫자가 아닌 문자열을 변환하므로 오류 발생
            //iValue2 = int.Parse(sValue2); // 정수 문자열("10")을 정수로 변환 성공
            ////iValue1 = int.Parse(sValue3); // 소수 문자열을 정수 변수에 대입했으므로 오류 발생
            //dValue1 = double.Parse(sValue3); // 소수 문자열을 소수 변수에 대입 성공

            //// 4. Convert.To***()로 형변환
            //iValue1 = Convert.ToInt32(sValue1); // 정수로 바뀔 수 없는 문자열이므로 오류 발생
            //iValue2 = Convert.ToInt32(sValue2); // 정수로 바뀔 수 있는 문자열이므로 형변환 성공
            //dValue1 = Convert.ToDouble(sValue3); // 소수로 바뀔 수 있는 문자열이므로 성공

            // ** 숫자로 바뀔 수 없는 값(문자열)인 경우에 Parse(), Convert.To~~~()를 활용하여 형변환을 시도하면 코드 작성할 땐 문제 없지만 실행하면 오류가 발생한다.

            // 5. 정수, 소수로 변환할 수 있는 문자열인지 판단하는 명령어(method) TryParse()
            int iResult; // 변환된 값이 저장되는 데이터 변수
            int.TryParse(sValue1, out iResult);
            MessageBox.Show(Convert.ToString(iResult));

            int.TryParse(sValue2, out iResult);
            MessageBox.Show(Convert.ToString(iResult));

            int.TryParse(sValue3, out iResult);
            MessageBox.Show(Convert.ToString(iResult));

            double dResult;
            double.TryParse(sValue3, out dResult);
            MessageBox.Show(Convert.ToString(dResult + 10));
        }
    }
}
