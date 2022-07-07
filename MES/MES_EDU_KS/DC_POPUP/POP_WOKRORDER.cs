using System;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win;
using DC00_assm;

namespace DC_POPUP
{
    public partial class POP_WOKRORDER : DC00_WinForm.BasePopupForm
    {
        #region < MEMBER AREA >
        DataTable dtTemp = new DataTable();
        UltraGridUtil _GridUtil = new UltraGridUtil();
        private string sPlantCode = LoginInfo.PlantCode;

        private string sWorkCenterCode = string.Empty; // 팝업에서 사용할 작업장 코드 변수
        private string sWorkCenterName = string.Empty; // 팝업에서 사용할 작업장 명 변수
        #endregion

        public POP_WOKRORDER()
        {
            InitializeComponent();
        }

        public POP_WOKRORDER(string workCenterCode, string workCenterName)
        {
            InitializeComponent();
            this.sWorkCenterCode = workCenterCode;
            this.sWorkCenterName = workCenterName;
        }

        private void POP_WOKRORDER_Load(object sender, EventArgs e)
        {
            // Grid 세팅.
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);

            // 자재 발주 부분
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장", GridColDataType_emu.VarChar, 120, HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장 코드", GridColDataType_emu.VarChar, 160, HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장 명", GridColDataType_emu.VarChar, 140, HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO", "작업 지시 번호", GridColDataType_emu.VarChar, 150, HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERDATE", "작업 지시 일자", GridColDataType_emu.YearMonthDay, 150, HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품번", GridColDataType_emu.VarChar, 140, HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", GridColDataType_emu.VarChar, 150, HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERQTY", "작업 지시 수량", GridColDataType_emu.Double, 140, HAlign.Right, true, false);
            _GridUtil.SetInitUltraGridBind(grid1);

            #region < 콤보박스 세팅 설명 >
            // 콤보박스 세팅.
            // 공장 : 공장에 대한 시스템 공통 코드 내역을 DB에서 가여온다. dtTemp 데이터테이블에 담는다.
            dtTemp = Common.StandardCODE("PLANTCODE");
            // 콤보박스에 받아온 데이터를 벨류멤버와 디스플레이멤버로 표현한다.
            Common.FillComboboxMaster(this.cboPlantCode_H, dtTemp, dtTemp.Columns["CODE_ID"].ColumnName, dtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            // 그리드의 컬럼에 받아온 데이터를 콤보박스 형식으로 세팅한다.
            UltraGridUtil.SetComboUltraGrid(grid1, "PLANTCODE", dtTemp);

            // 공장 로그인 정보로 자동 세팅
            cboPlantCode_H.Value = sPlantCode;

            // 선택한 작업장 표시
            txtWorkCenterCode_H.Text = sWorkCenterCode;
            txtWorkCenterName_H.Text = sWorkCenterName;
            #endregion
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            // 툴바의 조회 버튼 클릭.
            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode_     = Convert.ToString(cboPlantCode_H.Value);                // 공장
                string sWorkCenterCode = txtWorkCenterCode_H.Text;                              // 작업장 코드
                string sWorkCenterName = txtWorkCenterName_H.Text;                              // 작업장 코드
                string sStartDate      = string.Format("{0:yyyy-MM-01}", dtpStart.Value);       // 작업 지시 시작 일자
                string sEndDate        = string.Format("{0:yyyy-MM-dd}", dtpEnd.Value);         // 작업 지시 종료 일자

                dtTemp = helper.FillTable("13USP_OrderNo_POP", CommandType.StoredProcedure
                                          , helper.CreateParameter("@PLANTCODE", sPlantCode_)
                                          , helper.CreateParameter("@WORKCENTERCODE", sWorkCenterCode)
                                          , helper.CreateParameter("@WORKCENTERNAME", sWorkCenterName)
                                          , helper.CreateParameter("@STARTDATE", sStartDate)
                                          , helper.CreateParameter("@ENDDATE", sEndDate)
                                          );

                // 받아온 데이터를 그리드에 매핑
                if (dtTemp.Rows.Count == 0)
                {
                    // initialize grid
                    _GridUtil.Grid_Clear(grid1);
                    MessageBox.Show("작업장에 내려진 작업 지시가 없습니다.");
                    return;
                }

                grid1.DataSource = dtTemp;
                grid1.DataBinds(dtTemp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }

        private void grid1_DoubleClick(object sender, EventArgs e)
        {
            if (grid1.Rows.Count == 0) return;
            this.Tag = Convert.ToString(grid1.ActiveRow.Cells["ORDERNO"].Value);
            this.Close();
        }

        private void cboPlantCode_H_ValueChanged(object sender, EventArgs e)
        {
            Search();
        }
    }
}
