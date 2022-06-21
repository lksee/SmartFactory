using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// SQL Server에 접속할 수 있는 클래스 라이브러리
using System.Data.SqlClient;

namespace MainForms
{
    /* <summary>
     * Name: M01_LOGIN
     * Desc: 시스템 로그인
     * 
     * Date        : 2022.06.20
     * Author      : 이기수
     * Description : 최초 프로그램 작성.
     * </summary>
     */

    // WinFormApplication 강의의 목표.
    // C# .NETFramework에서 제공하는 기본 도구와 프로그래밍 문법을 사용하여 개발 솔루션의 프레임을 만들어보고
    // 시스템 개발 프레임 소스의 원리를 이해 및 구현하고 기능을 습득한다.
    public partial class M01_Login_N : Form
    {
        // SQL Server 커넥터 객체 생성.
        private SqlConnection _conn = null;
        // 로그인 실패 횟수 카운터
        private int _loginFail = 0;

        public M01_Login_N()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            // click login button
            _doLogin();
        }
        
        private void _doLogin()
        {
            try
            {
                // 데이터베이스 접속 경로 설정.
                string strConn = Commons.sConnectInfo;

                // 접속 경로 커넥터 객체에 전달.
                _conn = new SqlConnection(strConn);

                // 데이터베이스 접속 여부 확인.
                _conn.Open();

                if (_conn.State != /*System.Data.*/ConnectionState.Open)
                {
                    MessageBox.Show("데이터베이스 연결에 실패했습니다.");
                    return;
                }
                else
                {
                    string sLoginID = textBoxID.Text; // USER ID
                    string sLoginPW = textBoxPW.Text; // USER PW

                    // ID / PW 찾는 SQL 구문.
                    string sFindUserSQL = $"SELECT USR.USER_NAME" +
                                               $", USR.USER_PW " +
                                               $", ISNULL(USR.NUM_OF_FAIL) AS NUM_OF_FAIL " +
                                            $"FROM TB_USER USR " +
                                           $"WHERE USR.USER_ID = '{sLoginID}' ";

                    // SqlDataAdapter: 데이터베이스에 연결 후 SQL 구문 전달. 결과값 리턴받는 클래스.
                    SqlDataAdapter adapter = new SqlDataAdapter(sFindUserSQL, _conn);

                    // DataTable: 프로그래밍 언어에서 데이터를 DB의 테이블 형태로 관리하는 데이터 자료 구조 클래스.
                    DataTable dtTemp = new DataTable();

                    // SQL Server로 SQL문 전달 후 결과를 DataTable에 담기.
                    adapter.Fill(dtTemp);

                    // 일치하는 ID가 없는 경우 (dtTemp에 데이터가 한 건도 없는 경우)
                    // return;
                    if (dtTemp.Rows.Count == 0)
                    {
                        MessageBox.Show("로그인 ID가 없습니다.");
                        textBoxID.Text = "";
                        textBoxPW.Text = "";
                        textBoxID.Focus();
                        _failLogin();
                        return;
                    }
                    else if (dtTemp.Rows[0]["NUM_OF_FAIL"].ToString() != "" && Convert.ToInt32(dtTemp.Rows[0]["NUM_OF_FAIL"] ?? 0) >= 3)
                    {
                        MessageBox.Show("로그인 실패 3회 초과로 계정이 잠겼습니다.\r\n관리자에게 문의하세요.");
                        return;
                    }
                    // PW가 일치하지 않는 경우
                    else if (sLoginPW != Convert.ToString(dtTemp.Rows[0]["USER_PW"]))
                    {
                        MessageBox.Show("PW가 일치하지 않습니다.");
                        textBoxPW.Text = "";
                        textBoxPW.Focus();
                        _failLogin();
                        Commons commons = new Commons();
                        commons.increaseValueNumOfFail(_conn, sLoginID);
                        return;
                    }
                    // ID와 PW가 일치할 경우
                    else
                    {
                        if (dtTemp.Rows[0]["NUM_OF_FAIL"].ToString() != "" && Convert.ToInt32(dtTemp.Rows[0]["NUM_OF_FAIL"] ?? 0) >= 1)
                        {
                            Commons commons = new Commons();
                            commons.resetNumOfFail(_conn, sLoginID);
                        }
                        Commons.sLoginUserID = sLoginID;
                        Commons.sLoginUserName = Convert.ToString(dtTemp.Rows[0]["USER_NAME"]);
                        MessageBox.Show($"{Commons.sLoginUserName} 님 반갑습니다.");

                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _conn.Close();
            }
        }

        private void _failLogin()
        {
            ++_loginFail;
            if(_loginFail >= 3)
            {
                MessageBox.Show("3회 로그인에 실패하였습니다.\r\n프로그램을 종료합니다.");
                this.Close();
            }
        }

        private void buttonChgPw_Click(object sender, EventArgs e)
        {
            M03_passwordChang m03 = new M03_passwordChang();
            //this.Hide();
            this.Visible = false;
            m03.ShowDialog();
            //this.Show();
            this.Visible = true;
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
