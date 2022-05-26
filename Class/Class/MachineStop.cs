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
    public partial class MachineStop : Form
    {
        public MachineStop()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("중지 전 기계 상태: " + MachineRunStopFlag.sRunStopFlag);

            MachineRunStopFlag.sRunStopFlag = "대기";

            MessageBox.Show("중지 후 기계 상태: " + MachineRunStopFlag.sRunStopFlag);
        }
    }
}
