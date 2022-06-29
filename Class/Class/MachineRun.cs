using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Class
{
    public partial class MachineRun : Form
    {
        public MachineRun()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //// MachineRunStopFlag.cs에 있는 데이터를 machineRunStopFlag 이름의 객체로 복사
            //MachineRunStopFlag machineRunStopFlag = new MachineRunStopFlag();

            //// 복사해온 machineRunStopFlag에 있는 sRunStopFlg의 값을 MessageBox로 출력
            //MessageBox.Show(machineRunStopFlag.sRunStopFlag);

            //// 복사해온 machineRunStopFlag 객체에 있는 sRunStopFlag 변수에 "가동" 문자열 데이터 대입
            //machineRunStopFlag.sRunStopFlag = "가동";

            //// 복사해온 machineRunStopFlag 객체에 있는 sRunStopFlag 값이 바뀐 최신의 상태를 MessageBox로 출력
            //MessageBox.Show(machineRunStopFlag.sRunStopFlag);


            MessageBox.Show("가동 전 기계 상태: " + MachineRunStopFlag.sRunStopFlag);

            MachineRunStopFlag.sRunStopFlag = "가동";

            MessageBox.Show("가동 후 기계 상태: " + MachineRunStopFlag.sRunStopFlag);
        }
    }
}
