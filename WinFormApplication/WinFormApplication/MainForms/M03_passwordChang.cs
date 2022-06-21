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

namespace MainForms
{
    public partial class M03_passwordChang : Form
    {
        // 1. 공통 클래스 (SELECT와 INSERT, UPDATE, DELETE 명령 전달 시 공통으로 사용)
        private SqlConnection _conn; // 데이터베이스 접속 정보 관리 클래스.

        // 2. Insert, Delete, Update르르 실행할 명령 전달 클래스.
        private SqlDataAdapter _adtr;

        // 3. 
        private SqlTransaction _tx; // 데이터 관리 권한 부여 클래스.
        private SqlCommand _cmd; // SQL 명령 전달 클래스.


        public M03_passwordChang()
        {
            InitializeComponent();
        }

        private void DoChangPassword()
        {
            ////////////////////////
            // 비밀번호 변경 클릭 //
            ////////////////////////
            try
            {
                // 텍스트박스에 필수 입력값 등록 여부 확인.
                string sMessage = string.Empty;
                if (textBoxUserID.Text == "")     sMessage = "사용자 아이디";
                else if (textBoxOldPW.Text == "") sMessage = "기존 비밀번호";
                else if (textBoxNewPW.Text == "") sMessage = "변경 비밀번호";

                if (sMessage != "")
                {
                    MessageBox.Show($"{sMessage}을 입력하지 않았습니다.");
                    return;
                }

                // Check validation and connect DB
                // 1. DB Conn Info
                string strConn = "Server=localhost;Uid=sa;Pwd=sqlserver12!@;database=AppDev;";

                // 2. Initialize SqlConnection with DB Conn Info
                _conn = new SqlConnection(strConn);

                // 3. open DB connection
                _conn.Open();

                // check DB connection
                if (_conn.State != ConnectionState.Open)
                {
                    MessageBox.Show("데이터베이스 연결에 실패하였습니다.");
                    return;
                }

                // 입력 내용 변수에 저장.
                string sLoginID = textBoxUserID.Text; // 사용자 아이디
                string sOldPW   = textBoxOldPW.Text;  // 기존 비밀번호
                string sNewPW   = textBoxNewPW.Text;  // 변경 비밀번호

                #region < 기존 비밀번호와 비교하여 변경 가능한 상태인지 체크>
                // 1. 기존 비밀번호 찾기 SQL 구문 작성.
                string sFindUserInfo = $"SELECT USR.USER_PW " +
                                            $", USR.NUM_OF_FAIL " +
                                         $"FROM TB_USER USR " +
                                        $"WHERE USR.USER_ID = '{sLoginID}';";

                // 2. Adapter(SELECT 구문을 실행하고 결과를 받아오는 클래스)
                //    에 SQL 구문과 접속정보 등록.
                _adtr = new SqlDataAdapter(sFindUserInfo, _conn);

                // 3. DB로부터 결과값을 담을 DataTable 객체 생성.
                DataTable dt = new DataTable();

                // 4. Adapter 실행 및 결과값 DataTalbe에 등록.
                _adtr.Fill(dt);

                // 5. ID 존재 여부 확인
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("There is no result. Please check your input text.");
                }
                else if (dt.Rows[0]["NUM_OF_FAIL"].ToString() != "" && Convert.ToInt32(dt.Rows[0]["NUM_OF_FAIL"] ??0) >= 3)
                {
                    MessageBox.Show("로그인 실패 3회 초과로 계정이 잠겼습니다.\r\n관리자에게 문의하세요.");
                    return;
                }
                // 6. 현재 비밀번호 비교.
                else if (sOldPW != Convert.ToString(dt.Rows[0]["USER_PW"]))
                {
                    MessageBox.Show("기존 비밀번호를 잘못 입력하였습니다.");
                    Commons commons = new Commons();
                    commons.increaseValueNumOfFail(_conn, sLoginID);
                    return;
                }

                if (MessageBox.Show("변경 비밀번호로 바꾸시겠습니까?", 
                                    "비밀번호 변경 확인", 
                                    MessageBoxButtons.YesNo) == DialogResult.No) // Yes/No 버튼 중 No 버튼을 눌렀을 때 return 처리
                {
                    return;
                }
                #endregion

                #region < 데이터베이스 명령 전달 클래스 객체에 설정한 SQL문 등록 및 실행 >
                // 1. 트랜잭션 선언 (데이터 관리 권한 부여)
                _tx = _conn.BeginTransaction("MyTran");

                // 2. Insert, Update, Delete 명령을 전달할 SqlCommand 클래스 객체 생성.
                _cmd = new SqlCommand();

                // 3. 생성한 Command에 트랜잭션 설정 정보 등록.
                _cmd.Transaction = _tx;

                // 4. 접속 정보 등록.
                _cmd.Connection = _conn;

                // 5. 실행할 SQL 구문 등록.
                string sUpdateSql = $"UPDATE TB_USER SET USER_PW = '{sNewPW}', NUM_OF_FAIL = 0 WHERE USER_ID = '{sLoginID}';";
                
                // 6. 커맨드에 실행할 SQL문 등록.
                _cmd.CommandText = sUpdateSql;

                // 7. 커맨드 실행
                _cmd.ExecuteNonQuery();

                // 8. 정상 완료 시 Commit
                _tx.Commit();

                MessageBox.Show("비밀번호를 정상적으로 변경했습니다.");
                #endregion

                this.Close();
            }
            catch (Exception ex)
            {
                _tx.Rollback();
                MessageBox.Show("비밀번호 등록 중 오류가 발생하였습니다.\r\n"+ex.Message);
            }
            finally
            {
                _conn.Close();
            }
        }

        private void buttonChgPW_Click(object sender, EventArgs e)
        {
            DoChangPassword();
        }

        private void textBoxNewPW_KeyDown(object sender, KeyEventArgs e)
        {
            // 변경될 비밀번호 입력 후 엔터 입력 시 변경 버튼 클릭.
            if (e.KeyCode == Keys.Enter)
            {
                DoChangPassword();
            }
        }
    }
}
