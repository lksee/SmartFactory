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
    public partial class Chapter03_Static_Const : Form
    {
        // static -> 한정자 : 프로그램 전체에서 유기적으로 관리해야 하는 값이 발생할 경우 사용한다.
        //                    객체의 생성 없이 클래스 내의 필드값 자체를 바꾸어 사용
        //                    클래스에 머물러있는 필드나 메서드라는 의미에서 '정적 필드', '정적 메서드'라고 한다.

        // Const : 상수 - 변하지 않는 값
        //         최초 1회 값을 대입 후 후속으로 값을 대입 시 오류가 발생하여
        //         여러 작업자가 동시에 개발하는 작업을 할 경우 또는
        //         코딩의 길이가 길어져 상수 명에 대한 판단이 모호할 시 발생할 수 있는 오류를 방지할 수 있다.
        public Chapter03_Static_Const()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Class_Static.sValue);
            Class_Static.sValue = "반갑습니다.";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Class_Static.sValue);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Chapter03_Class_Test CCT = new Chapter03_Class_Test();
            CCT.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // 상수(Constant): 바뀌지 않는 값, 해당 명령 --> const

            // 1. 클래스 Class_Const 객체 생성
            // 객체를 생성하였지만 sValue 필드를 찾을 수 없다.
            Class_Const C_C = new Class_Const();

            // 2. Const 상수는 기본적으로 static 한정자를 포함하고 있다.
            MessageBox.Show(Class_Const.sValue);

            // 3. 상수에 값을 대입 시 오류가 발생한다.
            //Class_Const.sValue = "";
            
        }
    }

    // class를 생성할 경우 프로젝트에 cs 형식으로 추가하는 방법과 코드 내에 class를 생성하는 방법이 있다.
    // 여러 개발자가 하나의 응용 프로그램을 개발할 경우 공통적으로 관리하는 class는 UI를 통해 프로젝트에 추가하여
    // 솔루션 탐색기에 보여지게 하는 것이 좋으며, 해당 화면 안에서만 사용할 경우 class를 namespace 묶음 단위 안에 별도로 생성 가능하다.

    class Class_Static
    {
        // 단일 필드만 static으로 한정한 경우
        public static string sValue = "안녕하세요.";


    }

    class Class_Static_2
    {
        // 여러 필드로 구성되어 있는 클래스의 경우
        // static으로 한정하지 않은 필드를 호출하기 위해서는 객체를 생성해야 한다.
        public static string sValue = "안녕하세요.";
        public string sValue2 = "반갑습니다.";
    }

    static class Class_Static_3
    {
        // class 자체를 static으로 한정
        // class 내의 모든 필드와 메소드는 static으로 한정되어야 한다.
        // class 자체가 메모리에 등록되는 형식
        public static string sValue = "안녕하세요";
        public static string sValue2 = "반갑습니다";

    }

    class Class_Const
    {
        public const string sValue = "dddd";
    }
}
