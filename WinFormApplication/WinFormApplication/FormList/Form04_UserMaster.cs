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
            // 그리드에 표현된 행이 없을 경우 삭제할 필요 없음
            if (dataGridView.Rows.Count == 0) return;

            // 지금 선택한 행의 index를 찾기
            int iSelectedIndex = dataGridView.CurrentCell.RowIndex;

            // dataGridView의 행과 컬럼의 모든 정보를 깡통 DataTable에 담는다.
            DataTable _dt = (DataTable)dataGridView.DataSource;

            // 데이터테이블의 행을 삭제한다.
            _dt.Rows[iSelectedIndex].Delete();
        }

        public override void Save()
        {
            
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
