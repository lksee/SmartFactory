using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Assambly;

namespace FormList
{
    public partial class Form05_Standard : Assambly.BaseChildForms
    {
        // 1. 공통 클래스(데이터베이스 커넥터)
        private SqlConnection _conn; // 데이터베이스 접속 정보 관리 클래스.

        // 2. SELECT를 실행하여 데이터를 받아오는 클래스.
        private SqlDataAdapter _da;

        // 3. INSERT, UPDATE, DELETE의 명령을 전달하는 클래스.
        private SqlTransaction _tran; // 데이터베이스 데이터 관리 권한 부여.
        private SqlCommand _cmd;

        public Form05_Standard()
        {
            InitializeComponent();
        }

        private void Form05_Standard_Load(object sender, EventArgs e)
        {
            loadData();
        }

        public override void Inquire()
        {
            // 사용자 정보 조회
            // 파라미터 설정(인자)
            string sUserMajorCode = textBoxMajorCode.Text;
            string sUserMinorCode = textBoxMinorCode.Text;

            try
            {
                if (!_connDB()) return;

                // Adapter에 SQL 구문과 접속 정보 등록.
                _da = new SqlDataAdapter("13SP_STANDARD_S", _conn);

                // Adapter에 프로시져 형식으로 호출함을 설정.
                _da.SelectCommand.CommandType = CommandType.StoredProcedure;

                // Adapter에 parameter 설정
                _da.SelectCommand.Parameters.AddWithValue("MAJORCODE", sUserMajorCode);
                _da.SelectCommand.Parameters.AddWithValue("MINORCODE", sUserMinorCode);

                // DataTable에 데이터 담기.
                DataTable dt = new DataTable();
                _da.Fill(dt);

                // 데이터가 있을 경우만 그리드에 맵핑
                if (dt.Rows.Count == 0)
                {
                    // 데이터 행 초기화.
                    ((DataTable)dataGridViewStandard.DataSource).Rows.Clear();
                    MessageBox.Show("조회할 데이터가 없습니다.");
                    return;
                }
                dataGridViewStandard.DataSource = dt;
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
            DataRow dr = ((DataTable)dataGridViewStandard.DataSource).NewRow();

            // 신규로 만든 dataGridView의 컬럼 정보를 가진 빈깡통 행을 다시 dataGridView에 등록한다.
            ((DataTable)dataGridViewStandard.DataSource).Rows.Add(dr);
        }

        /// <summary>
        /// 사용자 내역 행을 그리드에서 삭제
        /// </summary>
        public override void Delete()
        {
            // 그리드에 표현된 행이 없을 경우 삭제할 필요 없음
            if (dataGridViewStandard.Rows.Count == 0) return;

            // 지금 선택한 행의 index를 찾기
            int iSelectedIndex = dataGridViewStandard.CurrentCell.RowIndex;

            // dataGridView의 행과 컬럼의 모든 정보를 깡통 DataTable에 담는다.
            DataTable _dt = (DataTable)dataGridViewStandard.DataSource;

            // 데이터테이블의 행을 삭제한다.
            _dt.Rows[iSelectedIndex].Delete();
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
                DataTable _dt = ((DataTable)dataGridViewStandard.DataSource).GetChanges();

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
                            _cmd.CommandText = "13SP_STANDARD_D";
                            
                            _cmd.Parameters.AddWithValue("MAJORCODE", drRow["MAJORCODE"]);
                            _cmd.Parameters.AddWithValue("MINORCODE", drRow["MINORCODE"]);

                            _cmd.ExecuteNonQuery();
                            break;

                        // 행의 상태가 추가 됐을 경우
                        case DataRowState.Added:
                            // PK Validation 체크
                            if (Convert.ToString(drRow["MAJORCODE"]) == "")
                            {
                                throw new Exception("주코드를 입력하지 않았습니다.");
                            }
                            if (Convert.ToString(drRow["MINORCODE"]) == "")
                            {
                                throw new Exception("부코드를 입력하지 않았습니다.");
                            }

                            _cmd.CommandText = "13SP_STANDARD_I";
                            _cmd.Parameters.AddWithValue("MAJORCODE", drRow["MAJORCODE"]);
                            _cmd.Parameters.AddWithValue("MINORCODE", drRow["MINORCODE"]);
                            _cmd.Parameters.AddWithValue("CODENAME",  drRow["CODENAME"]);
                            _cmd.Parameters.AddWithValue("DISPLAYNO", drRow["DISPLAYNO"]);

                            _cmd.ExecuteNonQuery();

                            break;

                        // 행의 상태가 수정 됐을 경우
                        case DataRowState.Modified:
                            // PK Validation 체크
                            if (Convert.ToString(drRow["MAJORCODE"]) == "")
                            {
                                throw new Exception("주코드를 입력하지 않았습니다.");
                            }
                            if (Convert.ToString(drRow["MINORCODE"]) == "")
                            {
                                throw new Exception("부코드를 입력하지 않았습니다.");
                            }
                            _cmd.CommandText = "13SP_STANDARD_U";
                            _cmd.Parameters.AddWithValue("MAJORCODE", drRow["MAJORCODE"]);
                            _cmd.Parameters.AddWithValue("MINORCODE", drRow["MINORCODE"]);
                            _cmd.Parameters.AddWithValue("CODENAME", drRow["CODENAME"]);
                            _cmd.Parameters.AddWithValue("DISPLAYNO", drRow["DISPLAYNO"]);

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
                Inquire();
            }
        }

        private void loadData()
        {
            // 깡통 데이터 테이블 컬럼 추가.
            DataTable dtGrid = new DataTable();

            // 데이터 테이블 컬럼 추가.
            dtGrid.Columns.Add("MAJORCODE", typeof(string)); // 주코드
            dtGrid.Columns.Add("MINORCODE", typeof(string)); // 부코드
            dtGrid.Columns.Add("CODENAME",  typeof(string)); // 코드명
            dtGrid.Columns.Add("DISPLAYNO", typeof(int));    // 표시순번

            // 빈 컬럼 테이블 그리드 매핑.
            dataGridViewStandard.DataSource = dtGrid;

            // 그리드 컬럼 세팅.
            dataGridViewStandard.Columns["MAJORCODE"].HeaderText = "주코드";
            dataGridViewStandard.Columns["MINORCODE"].HeaderText = "부코드";
            dataGridViewStandard.Columns["CODENAME"].HeaderText  = "코드명";
            dataGridViewStandard.Columns["DISPLAYNO"].HeaderText = "표시순번";

            // 컬럼 폭 지정.
            dataGridViewStandard.Columns["MAJORCODE"].Width = 150;
            dataGridViewStandard.Columns["MINORCODE"].Width = 150;
            dataGridViewStandard.Columns["CODENAME"].Width = 200;
            dataGridViewStandard.Columns["DISPLAYNO"].Width = 200;
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
