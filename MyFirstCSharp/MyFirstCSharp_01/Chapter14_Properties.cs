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

    // properties
    // 클래스 내부 변수의 값을 읽거나 쓸 때 사용하는 방법.
    // public으로 선언한 변수의 변질을 막고, public 사용을 최소한으로 할 것을 지향.

    // 캡슐화(= encapsulation)
    // : 정보 은닉을 위해 클래스에서 선언된 변수가 외부에서 접근이 안 되도록
    //   접근 권한의 범위를 최소로 하는 것(public이 아닌 private으로 선언하여) 지향.
    //   불필요한 접근을 불가능하게 만드는 객체지향 언어에서 지향하는 목표 중 하나.
    //   --> 코드의 종속성을 낮춰 유지보수성을 높인다.

    public partial class Chapter14_Properties : Form
    {
        // 6. BookStore instance 생성.
        private BookStore B_S = new BookStore();

        public Chapter14_Properties()
        {
            InitializeComponent();
        }

        private void buttonIn_Click(object sender, EventArgs e)
        {
            // 7. 책 입고 로직.
            int iInBookCount = Convert.ToInt32(textBoxInput.Text);
            
            B_S.BookCount2 += iInBookCount; // 입고되는 책의 수량을 BookStore instance의 iBookCount에 누적.
            textBoxInput.Text = string.Empty;
            labelStock.Text = Convert.ToString(B_S.BookCount2); // 현재 총 재고량을 레이블에 출력.
            MessageBox.Show($"{iInBookCount}권의 책이 입고되었습니다.");
        }

        private void buttonOut_Click(object sender, EventArgs e)
        {
            //// 8. 책 판매 현황 및 데이터 변경.
            //--B_S.BookCount;

            //// 9. 책의 재고 값은 음수가 될 수 없다.
            //// 만약 iBookcount를 public으로 선언하거나 BookCount property를 get/set 상태로 그대로 둔다면
            //// -재고로 남게 된다.
            //if (B_S.BookCount < 0) { 
            //    B_S.BookCount = 0;
            //    MessageBox.Show("책의 수량은 0보다 작을 수 없습니다.");
            //}
            //labelStock.Text = Convert.ToString(B_S.BookCount);

            // 12. 
            --B_S.BookCount2;
            labelStock.Text = Convert.ToString(B_S.BookCount2);

            // 10. 
            // 다른 사람이 instance의 BookCount 또는 public iBookCount에 접근할 때
            // iBookCount가 음수 값을 가질 수 있다.
            // 따라서 공통으로 사용하는 클래스의 필드일 경우 public 방식보다는
            // get/set을 통한 properties로 선언하는 게 좋다.
        }
    }

    // 2. 서점이라는 class가 잇다고 할 때
    class BookStore
    {
        private int iBookCount; // 3. 외부에 Open 하지 않을 iBookCount 변수

        public int BookCount // 4. 외부에서 접근할 공용 properties BookCount로 접근할 수 있다.
        {
            get { return iBookCount; } // BookCount를 외부(다른 class)에서 호출할 경우 iBookCount 값을 반환함
            set { iBookCount = value; } // Bookcount에 외부에서 값을 대입할 경우 iBookCount 값을 대입함.
        }


        // 11. 데이터의 변질을 막기 위한 property BookCount2 선언
        public int BookCount2
        {
            get { return iBookCount; }
            set
            {
                // 지금 값이 0 미만인 경우
                if (value < 0)
                {
                    MessageBox.Show("책의 수량은 0이하일 수 없습니다.");
                }
                else iBookCount = value;
            }
        }

        // properties의 간단한 생성 방법
        public int BookCount3
        {
            // BookCount3를 자동으로 생성한다.
            get;set;
        }

        // read-only property
        public int BookCount4
        {
            get;
        }

        // write-only property
        public int BookCount5
        {
            set
            {
                BookCount5 = value;
            }
        }

        // 5. 정보은닉을 위해 변수(iBookCount) 자체는 private로 선언을 했지만
        // get과 set으로 접근을 가능하게 하니 public과 별 차이 없어보인다.?

        // properties
        // 정보의 은닉성(캡슐화)를 위하여 class의 fields를 private로 선언.
        // 공통으로 사용하는 변수일 경우 데이터의 변질을 막을 수 있어 은닉성과 데이터 변질에 대한 Validation을 동시에 수행하도록 선언 가능하다.
    }
}
