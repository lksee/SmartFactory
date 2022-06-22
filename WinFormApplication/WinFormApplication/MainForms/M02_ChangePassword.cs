using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// SQL Server 접속 클래스 클라이언트
using System.Data.SqlClient;
using Assambly;

namespace MainForms
{
    public partial class M02_ChangePassword : Form
    {
        private SqlConnection _conn;  // 데이터베이스 접속 정보 관리 클래스.
        private SqlTransaction _tran; // 데이터베이스 데이터 관리 권한 부여 클래스.
        private SqlCommand _command = new SqlCommand();  // 데이터베이스 트랜잭션 명령 전달 클래스.

        public M02_ChangePassword()
        {
            InitializeComponent();
        }

        private void buttonChgPW_Click(object sender, EventArgs e)
        {
            // 비밀번호 변경 클릭.
            _doChangePassword();
        }

        private void _doChangePassword()
        {
            // 기본값 입력 여부 확인.
            string sMessage = string.Empty;
            if (textBoxUserID.Text == "")
            {
                sMessage = "사용자 아이디";
            }
            else if (textBoxOldPW.Text == "")
            {
                sMessage = "이전 비밀번호";
            }
            else if (textBoxNewPW.Text == "")
            {
                sMessage = "신규 비밀번호";
            }

            if (sMessage != "")
            {
                MessageBox.Show(sMessage + "을 입력하지 않았습니다.");
                return;
            }

            // 비밀번호 변경을 위한 로직 시작.

            // 1. ID와 이전 비밀번호가 일치하는 지 확인.

            // 데이터베이스 접속 경로 설정.
            string sConnect = Commons.sConnectInfo;

            // 접속 경로 커넥터 객체에 전달.
            _conn = new SqlConnection(sConnect);

            // 데이터베이스 연결 상태 확인.
            _conn.Open();
            if (_conn.State != ConnectionState.Open)
            {
                MessageBox.Show("데이터베이스 접속에 실패했습니다.");
                return;
            }

            string sLoginID = textBoxUserID.Text; // 사용자 ID
            string sOldPW = textBoxOldPW.Text;    // 이전 비밀번호
            string sNewPW = textBoxNewPW.Text;    // 신규 비밀번호

            string sFindUserInfo = $"SELECT USR.USER_PW " +
                                     $"FROM TB_USER USR " +
                                    $"WHERE USR.USER_ID = '{sLoginID}' " +
                                      $"AND USR.USER_PW = '{sOldPW}';";

            SqlDataAdapter adapter = new SqlDataAdapter(sFindUserInfo, _conn);
            DataTable dtTemp = new DataTable();
            adapter.Fill(dtTemp);

            // ID와 PW 동시에 일치 여부 확인.
            if (dtTemp.Rows.Count == 0)
            {
                // ID와 PW가 일치하는 데이터가 없다.
                MessageBox.Show("ID 또는 PW가 일치하지 않습니다.");
                textBoxUserID.Text = "";
                textBoxOldPW.Text = "";
                textBoxNewPW.Text = "";
                textBoxUserID.Focus();
                return;
            }

            // ID와 PW가 동일할 경우 비밀번호 변경 여부
            // 메시지 및 결과에 따른 진행여부 결정. OlO IiLl
            if (MessageBox.Show("해당 비밀번호를 변경하시겠습니까?", "비밀번호 변경", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            // 트랜잭션 선언.
            _tran = _conn.BeginTransaction("MyTran");

            // 데이터베이스 트랜잭션 명령 전달 클래스 객체에 설정한 트랜잭션 등록.
            _command.Transaction = _tran; // 생성한 트랜잭션 등록.
            _command.Connection  = _conn; // 접속 정보 등록.

            // 트랜잭션 SQL 구문 등록.
            string sUpdateSQL = $"UPDATE TB_USER " +
                                   $"SET USER_PW = '{sNewPW}' " +
                                 $"WHERE USER_ID = '{sLoginID}';";

            _command.CommandText = sUpdateSQL;

            // SQL문 실행.
            _command.ExecuteNonQuery();

            // 정상 완료 시 Commit
            _tran.Commit();
            MessageBox.Show("비밀번호가 정상적으로 변경되었습니다.");
        }
    }
}
