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
    public partial class Chapter03_Class : Form
    { // class 범위 시작
        // class 생성하고 CHP_02라는 이름에 할당하고
        // class를 생성할 때 생성자 파라미터가 없으니 아무 조건 없이 만듦.
        Chapter02_DataType CHP_02 = new Chapter02_DataType(); //객체 초기화, class 인스턴스화 --> 객체가 클래스 범위에 생성됐기에 클래스 범위 내에서 쓸 수 있다.

        public Chapter03_Class() // Chapter03_Class class의 생성자
        { // 생성자 범위 시작
            InitializeComponent();
            // CHP_02 객체의 ia 변수에 10
            Chapter02_DataType CHP_02 = new Chapter02_DataType(); // 여기서 선언한 CHP_02는 생성자 범위 안에서만 사용됨
            CHP_02.sMessage1 = "반갑습니다.";
            textBox1.Text = CHP_02.sMessage1;
        } // 생성자 범위 끝

        private void button1_Click(object sender, EventArgs e) //Click Event
        { // button1_Click 메소드 범위 시작
            Chapter02_DataType CHP_02 = new Chapter02_DataType(); // 여기서 선언한 CHP_02는 button1_Click 메소드 범위 안에서만 사용됨
            textBox1.Text = CHP_02.sMessage1;
        } // button1_Click 메소드 범위 끝
    } // class 범위 끝
}
