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
    public partial class Chapter06_Null : Form
    {
        /* 1. Null이란
         *  - 데이터 용량(메모리) 자체가 주어지지 않음.
         *  - 값이 존재하지 않다.
         *  - e.g. 아파트 건축 전 세대주로 등록된 상태
         *  - ""은 아무 것도 없는 데이터가 존재
         *  - e.g. 아파트는 지었으나 물건을 넣지않아 텅 빈 상태
         */


        public Chapter06_Null()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // 숫자형 데이터의 값이 null인지 판단하는 방법(HasValue)
            string sValue = null;
            //int iBalue = null; // 기본적으로 정수형 데이터에는 null을 입력할 수 없다. (오류)
            // 하지만 특별한 경우 숫자 변수를 초기화 해야할 경우에는 ? 사용해서 null 상태로 만들 수 있다.
            int? iValue = null;

            // 숫자형 데이터의 값이 null 인지 판단하는 방법 HasValue
            MessageBox.Show(Convert.ToString(iValue));

            // iValue는 null 상태라서 false를 반환한다.
            MessageBox.Show(Convert.ToString(iValue.HasValue));

            iValue = 11;
            // 11이라는 데이터가 iValue에 존재하므로 true를 반환한다.
            MessageBox.Show(Convert.ToString(iValue.HasValue));

            // 문자열은 기본적으로 null을 허용한다. 따라서 HasValue 기능 없다.
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // null 병합 연산자 --> ??
            // 데이터 타입의 유형이 null인지 판단하여 null일 경우 지정한 값을 표현
            // Validation

            int? iValue = null;
            MessageBox.Show(Convert.ToString(iValue ?? 0));

            iValue = 11;
            MessageBox.Show(Convert.ToString(iValue ?? 0));

            string sValue = null;
            MessageBox.Show(sValue ?? "Null 입니다.");
        }
    }
}
