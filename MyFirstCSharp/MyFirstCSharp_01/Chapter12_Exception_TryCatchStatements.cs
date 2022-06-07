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
    public partial class Chapter12_Exception_TryCatchStatements : Form
    {
        int[] iValueArray = new int[] { 1, 2, 3 };

        // 예외처리 Exception
        // 프로그램 구동 시 발생할 수 있는 오류를 검출하여
        // 오류로 인해 프로그램이 비정상적인 동작 또는 종료되지 않도록 처리하는 방식.
        // try...catch...finally, throw

        // 개발자가 예상하지 못한 벨리데이션 체크를 로직에 작성하여
        // 에러 발생 원인을 유연하게 파악할 수 있는 편의 제공

        // Java, Javascript, Python(try...except) 프로그래밍 언어에서 모두 존재하는 statements

        public Chapter12_Exception_TryCatchStatements()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 예외상황 발생시키기
            for (int i = 0; i < iValueArray.Length + 1; i++)
            {
                MessageBox.Show(Convert.ToString(iValueArray[i]));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 예외 처리 Try...Catch Statements는 반드시 쌍으로 작성한다.
            // try{} 프로그램 로직을 처리하는 부분
            try
            {
                // index 범위를 초과하기에 오류가 발생
                for (int i = 0; i < iValueArray.Length + 1; i++)
                {
                    MessageBox.Show(Convert.ToString(iValueArray[i]));
                }
            }
            // catch{} 오류 발생 시 실행되는 부분
            catch
            {
                MessageBox.Show("동작 중 오류가 발생하였습니다.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if ( GetError() ) MessageBox.Show("정상적으로 완료되었습니다."); // GetError method is invoked.
            }
            catch
            {
                MessageBox.Show("동작 중 오류가 발생하였습니다. button3_Click");
            }
        }

        private bool GetError()
        {
            // 예외 처리 Try...Catch Statements는 반드시 쌍으로 작성한다.
            // try{} 프로그램 로직을 처리하는 부분
            try
            {
                // index 범위를 초과하기에 오류가 발생
                for (int i = 0; i < iValueArray.Length + 1; i++)
                {
                    MessageBox.Show(Convert.ToString(iValueArray[i]));
                }
                return true;
            }
            // catch{} 오류 발생 시 실행되는 부분
            catch
            {
                //throw new Exception();
                MessageBox.Show("동작 중 오류가 발생하였습니다. in GetError Method");
                return false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Exception
            // 시스템 구동 시 발생할 수 있는 오류의 원인을 검출하고 메시지로 내역을 반환하는 클래스
            // 프로그램 개발자 또는 사용자에게 오류내역을 표현하도록 하여
            // 어떤 오류인지 확인할 수 있다.
            // 에러가 검출되는 상황에 통상적으로 Exception 클래스 (모든 예외상황을 검출)를 사용하여
            // 자세한 오류 내역을 검출하고자 할 때는별도의 Exception 클래스를 혼합하여 사용.

            try
            {
                int a = 1;
                int b = 0;
                int c = a / b;

                // index 범위를 초과하기에 오류가 발생
                for (int i = 0; i < iValueArray.Length + 1; i++)
                {
                    MessageBox.Show(Convert.ToString(iValueArray[i]));
                }

            }
            catch (DivideByZeroException dEx)
            {
                MessageBox.Show(dEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("배열을 표현하는 중 오류가 발생하였습니다.");
                MessageBox.Show(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // try...catch statemens 다음에 위치, 오류 발생 여부와 관계없이 무조건 실행되는 statements.
                // e.g. Database 작업 후 DB connection을 종료하는 로직 작성.
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // throw
            // 예외 상황을 발생시켜 catch로 처리하게끔 한다.

            // 0-20까지의 임의의 수를 생성하고 10 이하의 값 생성 시 catch로 throw
            // 아닐 경우 생성된 수를 메시지로 표현하는 구문
            int iRandomInt = 0;
            try
            {
                iRandomInt = _randomValueMaker();
                if (iRandomInt < 10)
                {
                    throw new Exception($"10 이상의 값 {iRandomInt}이 생성되었습니다.");
                }
            }
            catch(RandomValueCheckException ex)
            {

            }
        }

        private int _randomValueMaker()
        {
            // 난수 생성 클래스.
            Random random = new Random();

            return random.Next(0, 20);
        }
    }

    class RandomValueCheckException : Exception
    {
        public RandomValueCheckException()
        {
        }

        public RandomValueCheckException(string message)
            : base(message)
        {
        }

        public RandomValueCheckException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
