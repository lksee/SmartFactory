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
    public partial class Chapter08_Method_Return : Form
    {
        //클래스 내에 생성할 수 잇는 요소는 필드(변수), 메서드
        string sValue = string.Empty; // ""

        public Chapter08_Method_Return()
        {
            InitializeComponent();
        }

        #region < 기본 메서드 호출 >
        private void button1_Click(object sender, EventArgs e)
        {
            // 기본 메서드 호출
            ShowMessage();
        }

        private void ShowMessage()
        {
            MessageBox.Show("안녕하세요.");
            textBox1.Text = "안녕하세요.";
            label1.Text = "안녕하세요.";
        }
        #endregion

        #region < 인수와 인자 값을 통한 함수의 호출 >
        private void button2_Click(object sender, EventArgs e)
        {
            // 인수와 인자 값을 주고 받는 함수 호출
            // 주는 값 : 인수 argument
            // 받는 값 : 인자(=매개변수) parameter
            ShowMessage("안뇽하세유."); // "안녕하세요" --> argument, 인수
        }

        // overload
        private void ShowMessage(string Message) // parameter, 인자
        {
            MessageBox.Show(Message);
            textBox1.Text = Message;
            label1.Text   = Message;
        }
        #endregion

        #region < TEST >
        private void button3_Click(object sender, EventArgs e)
        {
            ShowMessage("안녕하세요.", "반갑습니다.", "화이팅!");
        }

        // overload
        private void ShowMessage(string Messg1, string Messg2, string Messg3)
        {
            MessageBox.Show(Messg1);
            textBox1.Text = Messg2;
            label1.Text   = Messg3;
        }
        #endregion

        #region < 아무 값을 반환하지 않는 method >
        private void button4_Click(object sender, EventArgs e)
        {
            // return : 메소드에서 처리한 어떠한 결과를 호출한 부분으로 넘겨주는 기능
            // void 키워드는 어떤 결과값도 return하지 않는다.
            // return 키워드는 사용 가능
            // return에 값을 반환하면 오류 발생.
            ShowMessage2();
        }

        private void ShowMessage2()
        {
            MessageBox.Show("안녕하세요.");
            textBox1.Text = "안녕하세요.";
            return; // method 내용 실행을 마치고 method 호출부로 돌아감
            label1.Text   = "안녕하세요.";
        }
        #endregion

        #region < return type이 string인 method 구현 >
        private void button5_Click(object sender, EventArgs e)
        {
            string sMessage = ShowMessage3("argument 보냅니다.");
            MessageBox.Show(sMessage);
        }

        private string ShowMessage3(string Message)
        {
            MessageBox.Show("parameter로 다음의 값을 받았어요 --> " + Message);
            return "Success";
        }
        #endregion

        #region < return type이 int인 method 구현 >
        private void button6_Click(object sender, EventArgs e)
        {
            // 메시지박스 보이는 순서
            // B --> A --> 30 --> C
            int iResult; // 결과 값을 받을 변수
            MessageBox.Show("B");
            iResult = intSum(10, 20);
            MessageBox.Show(Convert.ToString(iResult));
            MessageBox.Show("C");
        }

        private int intSum(int iValue1, int iValue2)
        {
            MessageBox.Show("A");
            // 인자 값을 더하고 그 결과를 반환하는 메소드 구현
            return iValue1 + iValue2;
        }
        #endregion

        #region < 인자(parameter)가 기본값(default)을 가지는 method의 결과값을 반환하는 메소드 리턴 (선택적 인수(=argument) >
        private void button7_Click(object sender, EventArgs e)
        {
            int iResult;
            iResult = intSum2(10, 20);
            // 이미 parameter에 값을 가지고 있음(=default)
            // method 호출 시 해당 argument를 생략 가능 --> 생략 시 default 값을 가지고 method가 실행됨
            // default 값을 갖는 parameter에 argument를 넘겨주면 넘겨받은 argument의 값으로 parameter 값을 대체한다.
            MessageBox.Show(Convert.ToString(iResult));
        }
        private int intSum2(int iValue1, int iValue2 = 20)
        {
            return iValue1 + iValue2;
        }
        #endregion

        #region < 인수를 배열로 전달하는 경우 >
        private void button8_Click(object sender, EventArgs e)
        {
            // 배열 인수 생성
            string[] sArrayString = { "안녕하세요.", "반갑습니다.", "화이팅!" };
            //                  Index :   [0]             [1]          [2]
            // sArrayString[0] : "안녕하세요."
            // sArrayString[1] : "반갑습니다."
            // sArrayString[2] : "화이팅!"

            // string[] sArrayString2 = new string[1000]; // 배열 초기화(배열 데이터 타입의 변수를 선언하고 메모리 할탕)

            ShowMessage4(sArrayString);
        }

        private void ShowMessage4(string[] sValue, string a = "", int b = 2)
        {
            MessageBox.Show(sValue[0]);
            textBox1.Text = sValue[1];
            label1.Text   = sValue[2];
        }
        #endregion

        #region < return type이 Array인 method 구현 >
        private void button9_Click(object sender, EventArgs e)
        {
            // 1. 배열 인자 생성
            int[] iArrayInt = { 10, 20 };
            iArrayInt = IntSum3(iArrayInt);

            MessageBox.Show(Convert.ToString(iArrayInt[0]));
            MessageBox.Show(Convert.ToString(iArrayInt[1]));
        }

        // 2. 배열 인수를 일정한 값과 합하는 method 생성
        private int[] IntSum3(int[] iArrayInt)
        {
            int[] iSumInt = { 5, 10 };
            iSumInt[0] = iArrayInt[0] + iSumInt[0];
            iSumInt[1] = iArrayInt[1] + iSumInt[1];
            return iSumInt;
        }
        #endregion

        #region < 다른 클래스의 함수 호출 >
        private void button10_Click(object sender, EventArgs e)
        {
            NewClass NC = new NewClass();
            MessageBox.Show(Convert.ToString(NC.IntSum(40)));
        }
        #endregion
    }

    class NewClass
    {
        public int IntSum(int iValue, int iValue2 = 20)
        {
            int iResult = iValue + iValue2;
            return iResult;
        }
    }
}
