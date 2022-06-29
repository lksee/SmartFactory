using System.Windows.Forms;
using Assambly;
// 일반적인 SQL Server 접속 클래스 라이브러리
using System.Data.SqlClient;
using System.Data;
using System;

namespace FormList
{
    /// <summary>
    /// Name: Form04_UserMaster
    /// Desc: 저장 프로시져를 이용한 DB 접속 및 사용자 관리.
    /// Date: 2022.06.27
    /// author: 이기수
    /// Desc: 프로그램 최초 개발.
    /// </summary>
    public partial class Form04_UserMaster : BaseChildForms
    {
        // 1. 공통 클래스(데이터베이스 커넥터)
        private SqlConnection _conn; // 데이터베이스 접속 정보 관리 클래스.

        // 2. SELECT를 실행하여 데이터를 받아오는 클래스.
        private SqlDataAdapter _da;

        // 3. INSERT, UPDATE, DELETE의 명령을 전달하는 클래스.
        private SqlTransaction _tran; // 데이터베이스 데이터 관리 권한 부여.
        private SqlCommand _cmd;

        public Form04_UserMaster()
        {
            InitializeComponent();
        }

        public override void Inquire()
        {
            // 사용자 정보 조회
            // 파라미터 설정(인자)
            string sUserId = textBoxUserId.Text;
            string sUserName = textBoxUserName.Text;
            string sDeptCode = Convert.ToString(comboBoxGroup.SelectedValue);

            try
            {
                if (!_connDB()) return;

                // Adapter에 SQL 구문과 접속 정보 등록.
                _da = new SqlDataAdapter("13SP_USERMASTER_S", _conn);

                // Adapter에 프로시져 형식으로 호출함을 설정.
                _da.SelectCommand.CommandType = CommandType.StoredProcedure;

                // Adapter에 parameter 설정
                _da.SelectCommand.Parameters.AddWithValue("USERID", sUserId);
                _da.SelectCommand.Parameters.AddWithValue("USERNAME", sUserName);
                _da.SelectCommand.Parameters.AddWithValue("DEPTCODE", sDeptCode);

                // DataTable에 데이터 담기.
                DataTable dt = new DataTable();
                _da.Fill(dt);

                // 데이터가 있을 경우만 그리드에 맵핑
                if (dt.Rows.Count == 0)
                {
                    // 데이터 행 초기화.
                    ((DataTable)dataGridView.DataSource).Rows.Clear();
                    MessageBox.Show("조회할 데이터가 없습니다.");
                    return;
                }
                dataGridView.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _conn.Close();
            }
        }

        /// <summary>
        /// 사용자 내역 추가하는 행 신규 등록
        /// </summary>
        public override void DoNew()
        {
            // dataGridView의 데이터소스에 있는 데이터를
            // 데이터테이블 형식으로 만들고 테이블에 있는 행의 컬럼 내역을 DataRow로 신규 생성한다.
            DataRow dr = ((DataTable)dataGridView.DataSource).NewRow();

            // 신규로 만든 dataGridView의 컬럼 정보를 가진 빈깡통 행을 다시 dataGridView에 등록한다.
            ((DataTable)dataGridView.DataSource).Rows.Add(dr);
        }

        /// <summary>
        /// 사용자 내역 행을 그리드에서 삭제
        /// </summary>
        public override void Delete()
        {
            // 그리드에 표현되어있는 행이 없을경우 에는 삭제 할 필요가 없다.
            if (dataGridView.Rows.Count == 0) return;

            // 현재 선택된 행의 정보를 받아온다. 
            int iSelectIndex = dataGridView.CurrentRow.Index;

            // 선택한 행의 사용자 ID 를 받아온다.
            string sUserid = Convert.ToString(dataGridView.Rows[iSelectIndex].Cells["USERID"].Value);

            // 그리드의 데이터를 데이터테이블에 담는다.
            DataTable dtTemp = (DataTable)dataGridView.DataSource;

            // 추가 버튼을 통하여 신규로 추가 된 행의 삭제일 경우 그행 자체를 삭제한다. 
            if (sUserid == "") dtTemp.Rows.RemoveAt(iSelectIndex);
            else
            {
                // 데이터 테이블 행의 수 만큼 반복
                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    // 데이터 테이블의 행이 삭제 된 상태일 경우 continue
                    if (dtTemp.Rows[i].RowState == DataRowState.Deleted) continue;

                    // 데이터 테이블의 사용자 id 가 그리드에서 선택한 사용자 ID 와 같을경우
                    if (sUserid == Convert.ToString(dtTemp.Rows[i]["USERID"]))
                    {
                        // 데이터 테이블에서 삭제행 처리 (행 자체는 삭제 되지 않음.)
                        dtTemp.Rows[i].Delete();
                    }
                }
            }
        }

        /// <summary>
        /// 사용자 내역 갱신(삽입, 삭제, 수정된 행을 DB에 반영
        /// </summary>
        public override void Save()
        {
            try
            {
                // 데이터베이스 접속 여부 확인.
                if (!_connDB()) return;

                // 트랜잭션 선언(트랜잭션 명은 임의 설정 가능)
                _tran = _conn.BeginTransaction("MyTran");

                // 1. INSERT, DELETE, UPDATE 명령 전달 SqlCommand 클래스 선언.
                _cmd = new SqlCommand();

                // 2. Command에 트랜잭션 맵핑
                _cmd.Transaction = _tran;

                // 3. 접속정보 등록.
                _cmd.Connection = _conn;

                // 4. 프로시져 형태로 호출하겠다는 선언.
                _cmd.CommandType = CommandType.StoredProcedure;
                
                // 파라미터 누적 방지 초기화.
                _cmd.Parameters.Clear();
                
                // Grid에서 데이터의 변화가 있는 행만 추출
                DataTable _dt = ((DataTable)dataGridView.DataSource).GetChanges();

                // 만약에 변경된 행이 없다면 return;
                if (_dt is null) return;
                // if (_dt.Rows.Count == 0) return; // null 반환 시 error

                foreach (DataRow drRow in _dt.Rows)
                {
                    // 추출된 행의 상태 체크.
                    switch (drRow.RowState)
                    {
                        // 행의 상태가 삭제 됐을 경우
                        case DataRowState.Deleted:
                            drRow.RejectChanges(); // 지워진 행의 데이터 복구.
                            _cmd.CommandText = "13SP_USERMASTER_D";
                            // USERID라는 이름으로 파라미터에 drRow["USERID"] 데이터를 보낸다.
                            _cmd.Parameters.AddWithValue("USERID", drRow["USERID"]);

                            _cmd.ExecuteNonQuery();
                            break;

                        // 행의 상태가 추가 됐을 경우
                        case DataRowState.Added:
                            // 사용자 ID 입력 여부 Validation 체크
                            if (Convert.ToString(drRow["USERID"]) == "")
                            {
                                throw new Exception("사용자 ID를 입력하지 않았습니다.");
                            }

                            _cmd.CommandText = "13SP_USERMASTER_I";
                            _cmd.Parameters.AddWithValue("USERID",   drRow["USERID"]);
                            _cmd.Parameters.AddWithValue("USERNAME", drRow["USERNAME"]);
                            _cmd.Parameters.AddWithValue("PW",       drRow["PW"]);
                            _cmd.Parameters.AddWithValue("DEPTCODE", drRow["DEPTCODE"]);
                            _cmd.Parameters.AddWithValue("MAKER",    Commons.sLoginUserID);

                            _cmd.ExecuteNonQuery();

                            break;

                        // 행의 상태가 수정 됐을 경우
                        case DataRowState.Modified:
                            if (Convert.ToString(drRow["USERID"]) == "")
                            {
                                throw new Exception("사용자 ID를 입력하지 않았습니다.");
                            }
                            _cmd.CommandText = "13SP_USERMASTER_U";
                            _cmd.Parameters.AddWithValue("USERID",   drRow["USERID"]);
                            _cmd.Parameters.AddWithValue("USERNAME", drRow["USERNAME"]);
                            _cmd.Parameters.AddWithValue("PW",       drRow["PW"]);
                            _cmd.Parameters.AddWithValue("PW_F_CNT", drRow["PW_F_CNT"]);
                            _cmd.Parameters.AddWithValue("DEPTCODE", drRow["DEPTCODE"]);
                            _cmd.Parameters.AddWithValue("EDITOR",   Commons.sLoginUserID);

                            _cmd.ExecuteNonQuery();

                            break;
                    }
                }

                _tran.Commit();
                MessageBox.Show("정상적으로 데이터 등록을 완료하였습니다.");

            }
            catch (Exception e)
            {
                _tran.Rollback();
                MessageBox.Show("등록 중 오류가 발생했습니다. " + e.Message);
            }
            finally
            {
                _conn.Close();
            }
        }

        /// <summary>
        /// 기본 그리드 내역 세팅
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form04_UserMaster_Load(object sender, System.EventArgs e)
        {
            // 깡통 데이터 테이블 컬럼 추가.
            DataTable dtGrid = new DataTable();

            // 데이터 테이블 컬럼 추가.
            dtGrid.Columns.Add("USERID",   typeof(string)); // 사용자 ID
            dtGrid.Columns.Add("USERNAME", typeof(string)); // 사용자 명
            dtGrid.Columns.Add("PW",       typeof(string)); // 비밀번호
            dtGrid.Columns.Add("PW_F_CNT", typeof(string)); // 로그인 실패 회수
            dtGrid.Columns.Add("DEPTCODE", typeof(string)); // 관리부서
            dtGrid.Columns.Add("MAKEDATE", typeof(string)); // 생성일시
            dtGrid.Columns.Add("MAKER",    typeof(string)); // 생성자
            dtGrid.Columns.Add("EDITDATE", typeof(string)); // 수정일시
            dtGrid.Columns.Add("EDITOR",   typeof(string)); // 수정자

            // 빈 컬럼 테이블 그리드 매핑.
            dataGridView.DataSource = dtGrid;

            // 그리드 컬럼 세팅.
            dataGridView.Columns["USERID"].HeaderText = "사용자 ID";
            dataGridView.Columns["USERNAME"].HeaderText = "사용자 명";
            dataGridView.Columns["PW"].HeaderText = "비밀번호";
            dataGridView.Columns["PW_F_CNT"].HeaderText = "로그인 실패 회수";
            dataGridView.Columns["DEPTCODE"].HeaderText = "관리부서";
            dataGridView.Columns["MAKEDATE"].HeaderText = "생성일시";
            dataGridView.Columns["MAKER"].HeaderText = "생성자";
            dataGridView.Columns["EDITDATE"].HeaderText = "수정일시";
            dataGridView.Columns["EDITOR"].HeaderText = "수정자";

            // 컬럼 폭 지정.
            dataGridView.Columns["USERID"].Width = 100;
            dataGridView.Columns["PW_F_CNT"].Width = 200;
            dataGridView.Columns["MAKEDATE"].Width = 200;
            dataGridView.Columns["EDITDATE"].Width = 200;

            // 컬럼 수정 여부 설정.
            dataGridView.Columns["MAKEDATE"].ReadOnly = true;
            dataGridView.Columns["MAKER"].ReadOnly = true;
            dataGridView.Columns["EDITDATE"].ReadOnly = true;
            dataGridView.Columns["EDITOR"].ReadOnly = true;

            /// 콤보박스 관리부서 데이터 조회 및 추가
            // 1. 데이터베이스에 부서코드 조회.
            try
            {
                if (!_connDB()) return;

                // 부설을 찾을 SQL문 작성.
                string sSelect = $"SELECT '' AS CODE_ID " +
                                      $", '[선택]' AS CODE_NAME " +
                                  $"UNION " +
                                 $"SELECT STD.MINORCODE AS CODE_ID " + // 부서 코드
                                      $", '[' + STD.MINORCODE + ']' + STD.CODENAME AS CODE_NAME " + // 부서명
                                   $"FROM TB_Standard STD " +
                                  $"WHERE STD.MAJORCODE = 'DEPTCODE' " + //부서인 정보만 조회
                                    $"AND STD.MINORCODE <> '$'";

                // 조회 후 결과 값 받아오기.
                _da = new SqlDataAdapter(sSelect, _conn);
                DataTable dt = new DataTable();
                _da.Fill(dt);

                // 콤보박스에 데이터 등록하기.
                comboBoxGroup.DataSource = dt;
                comboBoxGroup.ValueMember = "CODE_ID";     // 실제로 DB에 사용될 코드
                comboBoxGroup.DisplayMember = "CODE_NAME"; // 사용자에게 보여질 이름
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _conn.Close();
            }
        }

        /// <summary>
        /// 데이터베이트 접속 여부 확인
        /// </summary>
        private bool _connDB()
        {
            _conn = new SqlConnection(Commons.DbPath);
            _conn.Open();
            if (_conn.State != ConnectionState.Open)
            {
                MessageBox.Show("데이터베이스 연결에 실패했습니다.");
                return false;
            }

            return true;
        }
    }
}
