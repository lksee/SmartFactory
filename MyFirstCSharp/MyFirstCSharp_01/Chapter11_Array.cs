using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace MyFirstCSharp_01
{
    public partial class Chapter11_Array : Form
    {
        // 배열 : 같은 데이터 타입의 여러 데이터가 있을 경우
        //        하나의 배열 변수 이름으로 정의하는 데이터 형식
        public Chapter11_Array()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. 배열을 초기화: 크기가 맞아야 하고, 크기가 가변적이지 않다.
            int[] iaValue = new int[10];
            int[] iaValue1 = new int[6] { 40, 10, 2, 30, 3, 1 };
            int[] iaValue2 = new int[] { 10, 20, 30, 40 };
            int[] iaValue3 = { 10, 20 };

            string[] saValue1 = "ABCD/EFG".Split('/');
            int[] iValue4 = new int[iaValue.Length];

            // 2. 배열에서 사용할 수 있는 주요 기능.
            // 배열 정렬
            Array.Sort(iaValue1);
            foreach(int ivalue in iaValue1)
            {
                MessageBox.Show(Convert.ToString(ivalue));
            }

            // 특정 데이터의 index를 반환하는 기능
            int iIndex = Array.IndexOf(iaValue1, 30);
            //MessageBox.Show($"30의 Index는 : {iIndex}");

            // 배열을 복사 : 배열의 참조 주소를 복사한다.
            int[] iaValue4 = iaValue3;
            MessageBox.Show($"iaValue4의 첫번째 값은 : {iaValue4[0]}입니다.");
            iaValue3[0] = 3;
            MessageBox.Show($"iaValue4의 첫번째 값은 : {iaValue4[0]}입니다.");


            // 배열의 크기를 조정한다.
            Array.Resize<int>(ref iaValue1, 3);
            foreach (int ivalue in iaValue1)
            {
                MessageBox.Show(Convert.ToString(ivalue));
            }

            // 배열을 전체적으로 초기화
            Array.Clear(iaValue1, 0, iaValue1.Length);
            foreach (int ivalue in iaValue1)
            {
                MessageBox.Show(Convert.ToString(ivalue));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 2차원 배열의 초기화하는 방법.
            int[,] iaArray = new int[2, 3];
            iaArray[0, 0] = 1;
            iaArray[0, 1] = 2;
            iaArray[0, 2] = 3;
            iaArray[1, 0] = 4;
            iaArray[1, 1] = 5;
            iaArray[1, 2] = 6;


            int[,] iaArray2 = new int[2, 3] { { 1, 2, 3, }, 
                                              { 4, 5, 6, } };

            // 행의 수를 구하는 기능
            int iArrayRowCount = iaArray2.GetLength(0);

            // 열의 수 구하는 기능
            int iArrayRowCount2 = iaArray2.GetLength(1);

            // 1. 위의 배열을 텍스트 박스에 표현하세요.
            textBox1.Text = "===================For===================\r\n";
            string sArrayList = string.Empty;
            for (int x = 0; x < iArrayRowCount; x++)
            {
                for (int y = 0; y < iArrayRowCount2; y++)
                {
                    sArrayList += $"iaArray2의 [{x}, {y}]의 값은 : {iaArray2[x, y]} \r\n";
                }
                textBox1.Text += sArrayList + "\r\n";
                sArrayList = string.Empty;
            }

            // 2. foreach
            textBox1.Text += "=================Foreach=================\r\n";
            //textBox1.Text = textBox1.Text + "=================Foreach=================\r\n";
            int iDem = 0;
            foreach(int iResult in iaArray2)
            {
                sArrayList += $"{iResult}, ";
                if (++iDem == iaArray2.GetLength(1))
                {
                    sArrayList += "\r\n";
                    iDem = 0;
                }
            }
            textBox1.Text += sArrayList;

            int[,,,] iaArray10 = new int[2, 3, 4, 5];
            int n_ = 0;

            for (int a = 0; a < 2; a++)
            {
                for(int b = 0; b < 3; b++)
                {
                    for(int c = 0; c < 4; c++)
                    {
                        for(int d = 0; d < 5; d++)
                        {
                            iaArray10[a, b, c, d] = n_;
                            n_++;
                        }
                    }
                }
            }

            int n0 = iaArray10.GetLength(0);
            int n1 = iaArray10.GetLength(1);
            int n2 = iaArray10.GetLength(2);
            int n3 = iaArray10.GetLength(3);

            MessageBox.Show($"n0 : {n0}, n1 : {n1}, n2 : {n2}, n3 : {n3}");

            //foreach (int x in iaArray10)
            //{
            //    MessageBox.Show(Convert.ToString(x));
            //}

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 가변 배열(배열의 배열) Jagged_array(배열을 담는 배열)
            int[][] iJa = new int[3][]; // [3] 배열의 개수
            iJa[0] = new int[3] { 1, 2, 3 };
            iJa[1] = new int[] { 1, 2, 3, 4 };
            iJa[2] = new int[] { 1, 2 };
        }

        private void button4_Click(object sender, EventArgs e)

        {
            // Queue
            // 선입선출(First In First Out) 방식 자료 구조
            // 데이터나 작업을 차례대로 입력된 순서로 하나씩 처리.

            Queue<int> Que = new Queue<int>();

            // Queue에 값 대입
            Que.Enqueue(1);
            Que.Enqueue(2);
            Que.Enqueue(3);
            Que.Enqueue(4);

            // Queue 값 추출
            textBox1.Text = "======== Que ========\r\n";
            while (Que.Count > 0)
            {
                textBox1.Text += Convert.ToString(Que.Dequeue());
            }

            // Queue의 초기화
            int[] iaValue = new int[] { 1, 2 };
            Queue<int> Que2 = new Queue<int>(iaValue);
            Queue<int> Que3 = new Queue<int>(new int[4] { 1, 2, 3, 4 });

            textBox1.Text += "\r\n======== Que2 ========\r\n";
            foreach (int q in Que2)
            {
                textBox1.Text += Convert.ToString(q);
            }

            textBox1.Text += "\r\n======== Que3 ========\r\n";
            foreach (int q in Que3)
            {
                textBox1.Text += Convert.ToString(q);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Stack
            // 선입후출(First In Last Out) 방식 자료 구조


            // Stack 선언 데이터 초기화
            Stack<int> iStack = new Stack<int>();
            iStack.Push(1);
            iStack.Push(2);
            iStack.Push(3);

            textBox1.Text = "======== iStack ========\r\n";
            while (iStack.Count > 0)
            {
                textBox1.Text += Convert.ToString(iStack.Pop()) + ", ";
            }

            // Stack 배열로 초기화
            Stack<int> iStack1 = new Stack<int>(new int[2] { 1, 2 });

            textBox1.Text += "\r\n======== iStack1 ========\r\n";
            foreach (int q in iStack1)
            {
                textBox1.Text += Convert.ToString(q) + ", ";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // ArrayList
            // 배열과 비슷한 성격을 가지고 있으나,
            // 생성 시 크기를 미리 지정해 두지 않아도 된다.
            // 모든 값을 참조형식으로 처리하기 때문에 성능 저하의 원인이 될 수 있다.
            // using System.Collections;

            ArrayList list = new ArrayList();

            // 1. ArrayList에 데이터를 추가.
            for (int i = 0; i < 5; i++)
            {
                list.Add(i);
            }

            // 인덱스가 2인 내용 삭제
            list.Remove(2);

            // 2번 인덱스에 10 데이터를 넣어라.
            list.Insert(2, 10);

            // 배열을 입력하여 데이터 초기화
            int[] iArray = new int[2] { 1, 2 };

            string sMessage = string.Empty;
            foreach (object obj in list)
            {
                sMessage += Convert.ToString(obj) + ", ";
            }
            textBox1.Text = sMessage;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // HashTable
            // 키와 값으로 이루어진 데이터를 다룰 때 사용
            // Arraylit는 순서대로 값을 Indexing 하지만
            // HashTable은 지정한 키를 통하여 값을 찾아내어 속도가 빠른 장점이 있다.
            // 데이터 형식에 구애없이 키와 값을 지정할 수 있다.

            // 모든 데이터 타입은 object로 되어 사용시 데이터 형변환이 필요하다.

            Hashtable hs = new Hashtable();
            hs[1] = "ONE";
            hs["2"] = 2;
            hs[true] = 2;
            hs[1.23] = "1.23";

            // 값을 표현하기 위한 형변환
            MessageBox.Show(hs[1.23] as string);
            int iValue = (int)hs["2"];
            int iValue2 = Convert.ToInt32(hs["2"]);

            // HashTable의 초기화
            // 1. 딕셔너리 방식 (사전식)
            Hashtable Ht2 = new Hashtable()
            {
                ["하나"] = 1,
                ["둘"] = "TWO",
                [2] = 1.3,
            };

            // 2. 컬렉션 초기자(Collection initializer)를 통한 초기화
            Hashtable Ht4 = new Hashtable()
            {
                { "하나", 1 }, 
                { "둘", "TWO" }, 
                { 2, 1.3 },
            };

            // HashTable의 복사
            // 참조 복사
            Hashtable Ht5 = Ht4;

            // 값형 복사.
            Hashtable Ht6 = new Hashtable(Ht4);

            // 키와 값 추가.
            Ht6.Add(232, "232");

            // 232 키와 값을 삭제.
            Ht6.Remove(232);

            // 232 라는 키 값을 가진 데이터가 있는지 True/False로 반환
            bool Check = Ht6.Contains(232);

            // Ht6의 키와 값을 모두 삭제한다.
            Ht6.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Dictionary
            // HashTable과 유사하나 중복된 키를 사용할 수 없다.
            // 데이터 타입을 명시하여 사용하므로 형변환을 하지 않아도 되며
            // 타입이 다를 경우 에러를 표현하여 개발을 용이하게 한다.

            // 고정적으로 하나의 데이터 타입을 관리할 경우는 딕셔너리를 사용하며
            // Value의 일정한 데이터 형식에 구애없이 사용할 경우 HashTable을 사용한다.

            // 1. Dictionary의 생성
            // 키와 값의 데이터 타입이 구체적으로 명시돼야 한다.
            Dictionary<string, int> MyTable = new Dictionary<string, int>();
            MyTable.Add("A", 1);
            MyTable.Add("B", 2);
            MyTable.Add("C", 3);
            MyTable["D"] = 4;

            // 1. Dictionary 복사
            // 1.1. 값형 복사.
            Dictionary<string, int> MyTable2 = new Dictionary<string, int>(MyTable);
            MyTable2["A"] = 10;
            MessageBox.Show("값형 복사 후" + Convert.ToString(MyTable["A"]));

            // 참조형 복사.
            Dictionary<string, int> MyTable3 = MyTable;
            MyTable3["A"] = 10;
            MessageBox.Show("참조형 복사 후" + Convert.ToString(MyTable["A"]));

            // Key의 사용여부 확인
            if (MyTable.ContainsKey("A"))
            {
                MessageBox.Show("A 키가 있습니다.");
            }

            // Value의 사용여부 확인
            if (MyTable.ContainsValue(2))
            {
                MessageBox.Show("값 2을 가지고 있는 데이터가 있습니다.");
            }

            // Dictionary 삭제
            if (MyTable.Remove("A"))
            {
                MessageBox.Show("키 A를 삭제했습니다.");
            }

            // Key의 사용여부 확인
            if (MyTable.ContainsKey("A"))
            {
                MessageBox.Show("A 키가 있습니다.");
            }
            else
            {
                MessageBox.Show("A 키가 없습니다.");
            }
        }
    }
}
