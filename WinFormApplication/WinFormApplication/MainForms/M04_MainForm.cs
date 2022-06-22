using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Thread 사용하기 위한 라이브러리
using System.Threading;
using Assambly;
using FormList;

namespace MainForms
{
    public partial class M04_MainForm : Form
    {
        // 현재 시각을 표현할 스레드 객체
        private Thread thNowTime;

        public M04_MainForm()
        {
            InitializeComponent();
            //M01_Login m01_Login = new M01_Login();
            //m01_Login.ShowDialog();

            //// 호출했던 로그인 화면의 결과 Tag 값이 성공이 아니면 프로그램 종료.
            //if (Convert.ToBoolean(m01_Login.Tag) != true)
            //{
            //    // 프로그램 강제 종료
            //    Environment.Exit(0);
            //}
        }

        private void M04_MainForm_Load(object sender, EventArgs e)
        {
            // 현재 시각 Thread 시작.
            thNowTime = new Thread(new ThreadStart(GetNowTime));
            if (thNowTime.IsAlive == false) thNowTime.Start();
        }

        // 신규 스레드를 통한 현재 시간 체크
        // Thread: 프로세스 내부에서 생성되는 작업을 하는 주체.
        //         스레드를 생성함으로써 하나의 프로세스 외 여러가지 일을 동시에 수행 가능.
        private void GetNowTime()
        {
            // 5초 뒤에 스레드 종료를 위한 임시 변수.
            //int iThBreak = 0;
            while (true)
            {
                // 1초마다 갱신.
                Thread.Sleep(1000);
                toolStripStatusLabelNowDate.Text = String.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
                //iThBreak++;
                //if (iThBreak == 5) break;
            }
            
            //MessageBox.Show("현재시각 출력 스레드를 종료합니다.");
            
            // 스레드 종료.
            //thNowTime.Abort();
        }


        #region < 프로그램 종료 >
        private void toolStripButtonExit_Click(object sender, EventArgs e)
        {
            // 프로그램 종료 버튼 클릭.
            ApplicationExit();
        }

        private void ApplicationExit()
        {
            // 확인 메시지 표현 후 프로그램 종료.
            if (MessageBox.Show("프로그램을 종료하시겠습니까?", "프로그램 종료", MessageBoxButtons.YesNo) == DialogResult.No) return;
            
            // 구동되고 있는 스레드 종료.
            if (thNowTime.IsAlive) thNowTime.Abort();


            // Application 종료
            Environment.Exit(0);
        }

        private void M04_MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 윈도우창 X 버튼 클릭.
            ApplicationExit();
        }

        private void M_Test_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // DropDownItem -> 메뉴가 아래로 펼쳐질 때
            // 메뉴 클릭
            // 1. CS 파일을 직접 호출.
            Form01_MDI_TEST form01 = new Form01_MDI_TEST();
        }
        #endregion

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    // 1틱이 발생될 때마다(Interval: 1000 --> 1초) 현재 일시를 레이블에 출력
        //    toolStripStatusLabelNowDate.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
        //}
    }
}
