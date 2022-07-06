using System;
using System.Data;
using System.Windows.Forms;
using DC00_assm;
using DC00_WinForm;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using DC00_PuMan;

namespace KFQS_Form
{
    /// <summary>
    /// Form ID   : PP_ActualOutput
    /// Form Name : 생산 실적 등록
    /// Date      : 2022-07-06
    /// Maker     : 이기수
    /// </summary>
    public partial class PP_ActualOutput : DC00_WinForm.BaseMDIChildForm
    {
        #region < Member Area >
        DataTable dtTemp = new DataTable();
        UltraGridUtil _GridUtil = new UltraGridUtil();   // 그리드 세팅 클래스.
        private string sPlantCode = LoginInfo.PlantCode; // 로그인한 공장 정보.

        #endregion

        public PP_ActualOutput()
        {
            InitializeComponent();
        }

        private void PP_ActualOutput_Load(object sender, EventArgs e)
        {
            // Grid 세팅.
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);

            // 자재 발주 부분
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",            "공장",             GridColDataType_emu.VarChar,         120, HAlign.Left,   true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE",       "작업장 코드",      GridColDataType_emu.VarChar,         160, HAlign.Left,   true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME",       "작업장 명",        GridColDataType_emu.VarChar,         140, HAlign.Left,   true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO",              "작업 지시 번호",   GridColDataType_emu.VarChar,         150, HAlign.Left,   true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",             "품번",             GridColDataType_emu.VarChar,         140, HAlign.Left,   true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",             "품명",             GridColDataType_emu.VarChar,         150, HAlign.Left,   true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERQTY",             "작업 지시 수량",   GridColDataType_emu.Double,          140, HAlign.Right,  true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY",              "양품 수량",        GridColDataType_emu.Double,          150, HAlign.Right,  true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "BADQTY",               "불량 수량",        GridColDataType_emu.Double,          120, HAlign.Right,  true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE",             "단위",             GridColDataType_emu.VarChar,         120, HAlign.Left,   true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKSTATUSCODE",       "입출 유형",        GridColDataType_emu.VarChar,         130, HAlign.Left,   false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKSTATUS",           "상태",             GridColDataType_emu.VarChar,         130, HAlign.Left,   true,  false);

            _GridUtil.InitColumnUltraGrid(grid1, "MATLOTNO",             "투입 LOT NO",      GridColDataType_emu.VarChar,         120, HAlign.Left,   true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "COMPONENTQTY",         "투입 잔량",        GridColDataType_emu.Double,          120, HAlign.Right,  true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKER",               "작업자 ID",        GridColDataType_emu.VarChar,         130, HAlign.Left,   false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKERNAME",           "작업자 명",        GridColDataType_emu.VarChar,         130, HAlign.Left,   true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "STARTDATE",            "지시 시작 일시",   GridColDataType_emu.VarChar,         130, HAlign.Left,   true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "ENDDATE",              "지시 종료 일시",   GridColDataType_emu.VarChar,         130, HAlign.Left,   true,  false);

            _GridUtil.InitColumnUltraGrid(grid1, "MAKER",                "생성자",           GridColDataType_emu.VarChar,         130, HAlign.Left,   true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE",             "생성일자",         GridColDataType_emu.DateTime24,      130, HAlign.Left,   true,  false);
            _GridUtil.SetInitUltraGridBind(grid1);

            #region < 콤보박스 세팅 설명 >
            // 콤보박스 세팅.
            // 공장 : 공장에 대한 시스템 공통 코드 내역을 DB에서 가여온다. dtTemp 데이터테이블에 담는다.
            dtTemp = Common.StandardCODE("PLANTCODE");
            // 콤보박스에 받아온 데이터를 벨류멤버와 디스플레이멤버로 표현한다.
            Common.FillComboboxMaster(this.cboPlantCode_H, dtTemp, dtTemp.Columns["CODE_ID"].ColumnName, dtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            // 그리드의 컬럼에 받아온 데이터를 콤보박스 형식으로 세팅한다.
            UltraGridUtil.SetComboUltraGrid(grid1, "PLANTCODE", dtTemp);

            // 단위
            dtTemp = Common.StandardCODE("UNITCODE");
            UltraGridUtil.SetComboUltraGrid(grid1, "UNITCODE", dtTemp);

            // 작업장 마스터 콤보박스
            dtTemp = Common.GET_Workcenter_Code();
            Common.FillComboboxMaster(this.cboWorkCenter_H, dtTemp);

            BizTextBoxManager bizTextPopUp = new BizTextBoxManager();
            bizTextPopUp.PopUpAdd(txtWorkerID_H, txtWorkerName_H, "WORKER_MASTER");

            // 공장 로그인 정보로 자동 세팅
            cboPlantCode_H.Value = sPlantCode;
            #endregion
        }

        #region < ToolBar Area >
        public override void DoInquire()
        {
            SetWorkCenter();
        }

        private void SetWorkCenter()
        {
            // 1. 작업장 조회

            // 툴바의 조회 버튼 클릭.
            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode_     = Convert.ToString(cboPlantCode_H.Value);                // 공장
                string sWorkCenterCode = Convert.ToString(cboWorkCenter_H.Value);               // 작업장 코드

                dtTemp = helper.FillTable("13PP_ActualOutput_S", CommandType.StoredProcedure
                                          , helper.CreateParameter("@PLANTCODE",      sPlantCode_)
                                          , helper.CreateParameter("@WORKCENTERCODE", sWorkCenterCode)
                                          );

                // 받아온 데이터를 그리드에 매핑
                if (dtTemp.Rows.Count == 0)
                {
                    // initialize grid
                    _GridUtil.Grid_Clear(grid1);
                    ShowDialog("조회할 데이터가 없습니다.", DialogForm.DialogType.OK);
                    return;
                }

                grid1.DataSource = dtTemp;
                grid1.DataBinds(dtTemp);
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        private void cboWorkCenter_H_ValueChanged(object sender, EventArgs e)
        {
            // 작업자 콤보박스 변경 시 해당 작업장 내역만 조회되도록 설정.
            SetWorkCenter();
        }
    }
}
