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
    public partial class Chapter12_Quiz2 : Form
    {
        int[] iValues;

        public Chapter12_Quiz2()
        {
            InitializeComponent();

            // 숫자로 형변환 가능한 string 배열 생성.
            string[] sValues = labelText.Text.Trim(new char[] { '{', '}' }).Split(',');
            // sValues의 개수에 맞춰 배열 초기화
            iValues = new int[sValues.Length];

            // string -> int로 형변환에 성공한 개수
            int iTransSuccess = 0;
            
            // string -> int로 형변환
            for (int i = 0; i < sValues.Length; i++)
            {
                if (int.TryParse(sValues[i], out iValues[i++])) iTransSuccess++;
            }

            // ','로 Split한 개수와 형변환에 성공한 개수가 동일한가 확인.
            if (iTransSuccess != sValues.Length) MessageBox.Show($"','로 Split한 개수는 {sValues.Length}개, 형변환 성공 횟수 {iTransSuccess}개 입니다.");

            // 오름차순으로 정렬
            Array.Sort(iValues);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Keys: 숫자, Values: 숫자의 개수
            Dictionary<int, int> dValues = new Dictionary<int, int>();
            
            for (int i = 0; i < iValues.Length ; i++)
            {
                // 해당 Key가 없으면 초기화, 해당 Key가 있으면 값 1씩 누적 연산.
                if (dValues.ContainsKey(iValues[i]))
                {
                    dValues[iValues[i]] += 1;
                }
                else
                {
                    dValues[iValues[i]] = 1;
                }
            }

            // 중복된 수 오름차순 순서
            int iCount = 1;
            foreach (int i in dValues.Keys)
            {
                if (dValues[i] > 1)
                {
                    // 첫 번째, 세 번째 중복 값 메시지로 출력
                    if (iCount == 1 || iCount == 3) MessageBox.Show($"{iCount++}번째 중복 값은 {i}입니다.");
                    else iCount++;
                }

            }
        }

        private void labelText_Click(object sender, EventArgs e)
        {

        }
    }
}
