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
    // 네임스페이스 아래에 두어 모든 클래스에서 참조할 수 있도록 한다.
    public enum ItemType2
    {
        HAWA,
        FERT = 11,
        HALB,
        ROH,
    }


    // Enum : 정수형 상수의 모음. --> 열거형
    //   -  정수형 상수 데이터의 묶음
    //   -  기본 값을 지정하지 않아도 됨
    //   -  Enum 자료형 자체가 데이터가 되므로 메모리 관리가 용이
    public partial class Chapter13_Enum : Form
    {
        public Chapter13_Enum()
        {
            InitializeComponent();
            MessageBox.Show(Convert.ToString(HAWA)); // 상수 HAWA를 호출.

            MessageBox.Show(Convert.ToString(ItemType.HAWA)); // Enum에 있는 HAWA 호출.
        }

        // 1
        // 상수 : 초기화 필수✨
        // 상수의 이름을 보고 변수 내용을 파악할 수 있지만
        // 어떤 유형의 상수인지 알기 힘든 경우가 있다.
        const int HAWA = 0; // 상품
        const int FERT = 1; // 제품
        const int HALB = 2; // 반제품
        const int ROH  = 3; // 원자재

        // 2
        // Enum
        public enum ItemType
        {
            HAWA,      // 0
            FERT = 11, // 11
            HALB,      // 12
            ROH,       // 13

            // Enum 상수 열거형으로 정수값을 가지며 대입되지 않았을 경우 0부터 순차적으로 값이 된다.
            // 특정 값이 대입된 상수가 있을 경우 다음 상수는 +1된 값을 자동으로 가진다.
        }

    }
}
