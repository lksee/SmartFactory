using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstCSharp_01 //프로젝트명
{
    public partial class Form1 : Form //': Form'은 System.Windows.Forms.Form Class를 상속해서 Form1 class를 선언.
    {
        public Form1() //class의 생성자 class 이름과 동일한 함수로 클래스가 생성될 때 제일 처음 시작하는 지점
        {
            InitializeComponent(); //Form1.Designer.cs에 선언된 메소드 호출
            textBox1.Text = "HELLO WORLD"; //명령어는 세미콜론을 항상 작성해야 한다. 오류의 원인 중 하나.
        }
    }
}//닫는 범위(})를 빼먹으면 오류의 원인이 된다. 항상 쌍이 맞도록 작성할 것.