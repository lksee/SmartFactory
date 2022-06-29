using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PracForm
{
    public partial class LoginForm : Form
    {
        private int intRow = 0;
        private string sID = "";
        private string sPW = "";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void execute(string mySQL, string param)
        {
            Commons.cmd = new SqlCommand(mySQL, Commons.conn);
            addParameters(param);
            Commons.PerformCRUD(Commons.cmd);
        }

        private void addParameters(string str)
        {
            Commons.cmd.Parameters.Clear();
            Commons.cmd.Parameters.AddWithValue("USER_ID", textBoxID.Text.Trim());
            Commons.cmd.Parameters.AddWithValue("USER_PW", textBoxPW.Text.Trim());

            if (str == "Update" || str == "Delete" && !string.IsNullOrEmpty(this.sID))
            {
                Commons.cmd.Parameters.AddWithValue("id", this.sID);
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (_doLogin())
            {
                this.Close();
            }
        }

        private bool _doLogin()
        {
            sID = textBoxID.Text.Trim();
            sPW = textBoxPW.Text.Trim();

            if (this.sID.Length == 0)
            {
                MessageBox.Show("아이디를 입력하세요.");
                textBoxID.Focus();
                return false;
            }
            else if (this.sPW.Length == 0)
            {
                MessageBox.Show("비밀번호를 입력하세요.");
                textBoxPW.Focus();
                return false;
            }

                Commons.sql = $"SELECT USR.USER_PW " +
                               $", USR.USER_NAME " +
                            $"FROM TB_USER USR " +
                           $"WHERE USR.USER_ID = @keyword;";

            string strKeyword = string.Format("{0}", sID);
            Commons.cmd = new SqlCommand(Commons.sql, Commons.conn);
            Commons.cmd.Parameters.Clear();
            Commons.cmd.Parameters.AddWithValue("keyword", strKeyword);

            DataTable dt = Commons.PerformCRUD(Commons.cmd);

            if (dt.Rows.Count > 0)
            {
                intRow = Convert.ToInt32(dt.Rows.Count.ToString());
            }
            else
            {
                MessageBox.Show("해당하는 아이디가 없습니다. 다시 입력해주세요.");
                textBoxID.Text = "";
                textBoxPW.Text = "";
                textBoxID.Focus();
                intRow = 0;
                return false;
            }

            if (sPW != Convert.ToString(dt.Rows[0]["USER_PW"]))
            {
                //
                Commons.sql = "UPDATE TB_USER SET NUM_OF_FAIL = ISNULL(NUM_OF_FAIL, 0) + 1 WHERE USER_ID = @USER_ID";
                execute(Commons.sql, "Update");

                MessageBox.Show("비밀번호가 틀립니다. 다시 입력해주세요.");
                textBoxPW.Text = "";
                textBoxPW.Focus();
                return false;
            }

            this.Tag = true;
            MessageBox.Show($"{dt.Rows[0]["USER_NAME"]} 님 환영합니다.");
            
            return true;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            textBoxID.Focus();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Convert.ToBoolean(this.Tag) != true)
            {
                if (MessageBox.Show("로그인해야 사용 가능합니다.\r\n프로그램을 종료하시겠습니까?", "종료 확인", MessageBoxButtons.YesNo) == DialogResult.No) return;
            }
        }

        private void textBoxID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _doLogin();
            }
        }

        private void textBoxPW_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _doLogin();
            }
        }
    }
}
