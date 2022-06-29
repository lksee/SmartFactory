using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstCSharp_01 //Project(=App) 이름
{
    // internal : 동일한 어셈블리(Namespace) 파일 내에서만 접근이 가능하도록 하는 접근제한자. 그 종류로 public/private/internal/protected가 존재한다.
    internal class Chapter02_DataType //class 안에 변수를 선언하고, 그 변수를 다른 class에서 활용하기 위해 만든 class
    {
        // 수학에서 같다는 의미의 부등호는 ==로 표기하고 비교연산자, =는 오른쪽의 값(리터럴)을 왼쪽 변수명에 대입하는 대입연산자.
        // 변수에도 접근제어자가 붙는다. 생략할 경우 private이 default이다.

        // 1. 정수형 데이터 타입과 변수
        int ia = 11;     // ia라는 정수 int 변수에 11  을 대입(정상)
        // int ib = 1.0;    // ib라는 정수 int 변수에 1.0 을 대입(실수 데이터 타입을 대입하였으므로 에러가 발생)
        // int ic = "aaaa"; // id라는 정수 int 변수에 문자를 대입(문자 데이터 타입을 대입하였으므로 에러가 발생)
        // int id = "11";   // id라는 정수 int 변수에 문자를 대입(문자 데이터 타입을 대입하였으므로 에러가 발생)
        // int ie = int.MaxValue + 1; //변수의 가용 범위를 초과했기에 에러 발생

        // 2. 실수형 데이터 타입과 변수
        double da = 0.1;    // da라는 실수 변수에 소수 대입(정상)
        double db = 1;      // db라는 실수 변수에 정수 대입(정상). 단 메모리 효율, 연산 속도가 떨어지므로 권장 않음.
        double dc = 1.0;
        // double dd = "dddd"; // dd라는 실수 변수에 문자 대입(오류)

        // 3. 문자형 데이터 타입과 변수
        string sa = "";     // sa라는 문자 변수에 empty string 대입(정상)
        string sb = "11";   // sb라는 문자 변수에 "11" 문자 리터럴 대입(정상)
        // string sc = 11;     // sc라는 문자 변수에 11 정수 리터럴 대입(오류)
        public string sMessage1 = "안녕하세요.";
        public string sMessage2 = "반갑습니다.";
        public string sMessage3 = "화이팅!";

        // 4. 논리형 데이터(true/false) 타입과 변수
        // bool ba = 1;        // ba라는 논리 변수에 1 정수 리터럴 대입(오류)
        // bool bb = "";       // bb라는 논리 변수에 empty string 문자 리터럴 대입(오류)
        bool bc = true;     // bc라는 논리 변수에 true 논리 리터럴 대입(정상)
        bool bd = false;    // bc라는 논리 변수에 false 논리 리터럴 대입(정상)

        // 기계가 열심히 돌아가던 중
        // 멈추고 싶을 때 bc에 false 값을 대입하는 법.

        private void BoolChange()
        {
            bc = false;
            bc = !bc;  //!(not): 논리 리터럴 값을 반대로 만든다. true --> false, false --> true
        }
    }
}
