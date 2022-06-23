using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assambly
{
    // Interface
    // 클래스와 비슷하게 인터페이스는 메서드, 필드, 이벤트 등을 갖지만,
    // 이를 직접 구현하지 않고 정의만 한다.
    // 클래스가 인터페이스를 상속하는 경우 인터페이스의 모든 멤버를 구현해야 한다.

    // * 상속받는 클래스가 구현해야 할 기본 멤버를 정의하여 하나의 틀로 제공하기 위한 기능.

    public interface IChildCommands
    {
        void Inquire(); // 조회 버튼.
        void DoNew(); // 추가 버튼.
        void Delete(); // 삭제 버튼.
        void Save(); // 저장 버튼.
    }
}
