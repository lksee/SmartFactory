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
    public partial class Chapter12_Quiz : Form
    {
        int[] iRandomValues;

        public Chapter12_Quiz()
        {
            InitializeComponent();
        }

        private void buttonMakeRandomValue_Click(object sender, EventArgs e)
        {
            iRandomValues= GetRanInt(3);
            loadValue();
        }

        private int[] GetRanInt(int iIndex)
        {
            int[] iRanValues = new int[iIndex];
            Random random = new Random();
            for (int i = 0; i < iRanValues.Length; i++)
            {
                // 대부분의 Windows 시스템에서 Random 15밀리초 이내에 생성된 개체는 동일한 시드 값을 가질 가능성이 높습니다.
                // https://docs.microsoft.com/ko-kr/dotnet/api/system.random?view=net-6.0
                // iRandomValues[i] = new Random().Next(0, 100);

                // 이 문제를 방지하려면 여러 개체 대신 단일 Random 개체를 만듭니다.
                iRanValues[i] = random.Next(0, 100);
            }
            return iRanValues;
        }

        private void loadValue()
        {
            if (!(iRandomValues is null))
            {
                int i = 0;
                foreach (Control ctl in groupBoxRandom.Controls)
                {
                    if (ctl is TextBox)
                    {
                        ctl.Text = iRandomValues[i++].ToString();
                    }
                }
            }
            else
            {
                foreach (Control ctl in groupBoxRandom.Controls)
                {
                    if (ctl is TextBox)
                    {
                        ctl.Text = String.Empty;
                    }
                }
            }
        }

        private void buttonResult_Click(object sender, EventArgs e)
        {
            int iSum = 0;

            Array.Sort(iRandomValues);

            foreach (int iValue in iRandomValues)
            {
                iSum += iValue;
            }
            // 세 수의 합이 100미만 --> 최소값 * 최대값 메시지로.
            if (iSum < 100)
            {
                MessageBox.Show($"최소값 * 최대값은 {iRandomValues.Min() * iRandomValues.Max()}입니다.");
                MessageBox.Show($"최소값 * 최대값은 {iRandomValues[0] * iRandomValues[iRandomValues.Length-1]}입니다.");
            }
            // 세 수의 합이 100이상 200미만 --> 최소값 * 최대값
            else if (iSum >= 100 && iSum < 200)
            {
                MessageBox.Show($"최소값 * 최대값은 {iRandomValues.Min() * iRandomValues.Max()}입니다.");
                MessageBox.Show($"최소값 * 최대값은 {iRandomValues[0] * iRandomValues[iRandomValues.Length - 1]}입니다.");
            }
            // 세 수의 합이 200이상 --> "세 수의 합이 200이 넘습니다."
            else if (iSum >= 200)
            {
                MessageBox.Show("세 수의 합이 200이 넘습니다.");
            }
        }
    }
}
