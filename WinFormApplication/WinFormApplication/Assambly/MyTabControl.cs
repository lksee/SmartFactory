using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assambly
{
    // 사용자 정의 컨트롤
    // MyTabControl 클래스는 TabControl의 기능을 상속 받는다.
    public class MyTabControl : TabControl
    {
        // 클래스 상속.
        // 만들어진 클래스의 기능을 그대로 물려받고 새로운 기능을 추가할 수 있는 기능.
        public void AddFrom(Form NewForm)
        {
            if (NewForm is null) return; // 인자로 받은 폼이 없을 경우 실행 중지.
            NewForm.TopLevel = false; // 인자로 받은 폼이 최상위 객체가 아님을 선언. MDI 하위 창으로 사용하겠다는 선언.

            TabPage tabpage = new TabPage(); // 탭 페이지 객ㅊ에 생성.

            tabpage.Controls.Clear(); // 페이지 초기화.
            tabpage.Controls.Add(NewForm); // 페이지에 폼 추가.
            tabpage.Text = NewForm.Text; // 폼에서 지정한 명칭으로 탭 페이지 설정.
            tabpage.Name = NewForm.Name; // 활성화시킬 폼에서 지정한 명칭으로 탭 페이지 설정.

            // this --> MyTabControl, base --> TabControl
            base.TabPages.Add(tabpage); // 탭 컨트롤에 페이지를 추가한다.
            NewForm.Show(); // 인자로 받은 폼을 보여준다.
            base.SelectedTab = tabpage; // 선택된 페이지를 지금 호출한 페이지로 설정한다.
        }
    }
}
