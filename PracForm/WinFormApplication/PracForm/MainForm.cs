using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace PracForm
{
    public partial class MainForm : Form
    {
        // thread manage time
        Thread t_Now = null;

        #region < initialize control >
        public MainForm()
        {
            InitializeComponent();

            // Login
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();

            // don't login -> exit
            if (Convert.ToBoolean(loginForm.Tag) != true) Environment.Exit(0);
        }

        private void setWatch()
        {
            while (true)
            {
                Thread.Sleep(1000); // 1000 -> 1 sec
                toolStripStatusLabelWatch.Text = String.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            t_Now = new Thread(new ThreadStart(setWatch));
            if (!t_Now.IsAlive) t_Now.Start();
        }
        #endregion

        #region < exit this application >
        private void _exitApp()
        {
            // exit message
            if (MessageBox.Show("종료하시겠습니까?", "프로그램 종료 안내", MessageBoxButtons.YesNo) == DialogResult.No) return;

            // abort thread
            if (t_Now.IsAlive) t_Now.Abort();

            // exit Application.
            Environment.Exit(0);
        }

        private void toolStripButtonExit_Click(object sender, EventArgs e)
        {
            _exitApp();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _exitApp();
        }
        #endregion
    }
}
