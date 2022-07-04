using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DC00_assm;
using DC00_WinForm;
using DC00_PuMan;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace KFQS_Form
{
    /// <summary>
    /// Form ID   : MM_POMake
    /// Form Name : 자재발주및입고
    /// Date      : 2022-07-04
    /// Maker     : 이기수
    /// </summary>
    public partial class MM_POMake : DC00_WinForm.BaseMDIChildForm
    {
        #region < Member Area >
        DataTable dtTemp = new DataTable();
        UltraGridUtil _GridUtil = new UltraGridUtil();   // 그리드 세팅 클래스.
        private string sPlantCode = LoginInfo.PlantCode; // 로그인한 공장 정보.

        #endregion

        public MM_POMake()
        {
            InitializeComponent();
        }

        private void MM_POMake_Load(object sender, EventArgs e)
        {
            // Grid 세팅.
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);

            // 자재 발주 부분
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",           "공장",           GridColDataType_emu.VarChar,         130, HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PONO",                "발주 번호",      GridColDataType_emu.VarChar,         130, HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "POSEQ",               "발주 시퀀스",    GridColDataType_emu.VarChar,         130, HAlign.Left,   false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PODATE",              "발주 일자",      GridColDataType_emu.YearMonthDay,    130, HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",            "품목 코드",      GridColDataType_emu.VarChar,         130, HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "POQTY",               "발주 수량",      GridColDataType_emu.Double,          130, HAlign.Right,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE",            "단위",           GridColDataType_emu.VarChar,         130, HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE",            "거래처(협력)",   GridColDataType_emu.VarChar,         130, HAlign.Left,   true, false);

            // 작업 지시 확정 부분
            _GridUtil.InitColumnUltraGrid(grid1, "CHK",                 "입고",           GridColDataType_emu.CheckBox,        100, HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "INQTY",               "입고 수량",      GridColDataType_emu.Double,          130, HAlign.Right,  true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO",               "LOT 번호",       GridColDataType_emu.VarChar,         150, HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INDATE",              "입고 일자",      GridColDataType_emu.YearMonthDay,    130, HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INWORKER",            "입고자",         GridColDataType_emu.VarChar,         130, HAlign.Left,   true, false);


            _GridUtil.InitColumnUltraGrid(grid1, "MAKER",               "생성자",         GridColDataType_emu.VarChar,         130, HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE",            "생성일자",       GridColDataType_emu.DateTime24,      130, HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR",              "수정자",         GridColDataType_emu.VarChar,         130, HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE",            "수정일자",       GridColDataType_emu.DateTime24,      130, HAlign.Left,   true, false);
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

            // 거래처 코드
            dtTemp = Common.GET_Cust_Code("V"); // V == 협력업체(VENDER), C == 고객사(CUSTOMER)
            Common.FillComboboxMaster(this.cboCust_H, dtTemp);
            UltraGridUtil.SetComboUltraGrid(grid1, "CUSTCODE", dtTemp);

            // 품목코드
            // FERT: 완제품 / ROH: 원자재 / HALB: 반제품 / OM: 외주가공품
            dtTemp = Common.Get_ItemCode(new string[] { "ROH" }); // 현 시스템은 원자재만 발주한다고 가정
            Common.FillComboboxMaster(this.cboItemCode_H, dtTemp);
            UltraGridUtil.SetComboUltraGrid(grid1, "ITEMCODE", dtTemp);
            #endregion

            // 공장 로그인 정보로 자동 세팅
            cboPlantCode_H.Value = sPlantCode;

            // 발주 시작 일자 설정.
            dtpStart_H.Value = string.Format("{0:yyyy-MM-01}", DateTime.Now); // 현재 달의 1일로 설정.
            dtpEnd_H.Value   = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
        }

        #region < ToolBar Area >
        public override void DoInquire()
        {
            // 툴바의 조회 버튼 클릭.
            base.DoInquire();
            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode_     = Convert.ToString(cboPlantCode_H.Value);                // 공장
                string sItemCode       = Convert.ToString(cboItemCode_H.Value);                 // 품목 코드
                string sCustCode       = Convert.ToString(cboCust_H.Value);                     // 거래처 코드
                string sStartDate      = string.Format("{0:yyyy-MM-dd}", dtpStart_H.Value);     // 발주 시작 일자
                string sEndDate        = string.Format("{0:yyyy-MM-dd}", dtpEnd_H.Value);       // 발주 종료 일자
                string sPONo           = Convert.ToString(txtPONo_H.Value);                     // 발주 번호

                dtTemp = helper.FillTable("13MM_POMake_S", CommandType.StoredProcedure
                                          , helper.CreateParameter("@PLANTCODE", sPlantCode_)
                                          , helper.CreateParameter("@ITEMCODE",  sItemCode)
                                          , helper.CreateParameter("@CUSTCODE",  sCustCode)
                                          , helper.CreateParameter("@STARTDATE", sStartDate)
                                          , helper.CreateParameter("@ENDDATE",   sEndDate)
                                          , helper.CreateParameter("@PONO",      sPONo)
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

        public override void DoNew()
        {
            base.DoNew();

            // grid에 새로운 행을 하나 생성한다.
            this.grid1.InsertRow();

            // 생성된 행에 디폴트 데이터를 입력한다.
            this.grid1.ActiveRow.Cells["PLANTCODE"].Value = sPlantCode;
            this.grid1.ActiveRow.Cells["PODATE"].Value    = string.Format("{0:yyyy-MM-dd}", DateTime.Now);

            // 수정을 하지못하도록 컬럼 제어.
            // 신규 추가 시에는 생산 계획 편성 데이터만 등록할 수 있도록 함.
            grid1.ActiveRow.Cells["PONO"].Activation             = Activation.Disabled;  // 자재 발주 번호

            // 입고 관련 부분.
            grid1.ActiveRow.Cells["CHK"].Activation              = Activation.Disabled;  // 입고 등록 체크박스
            grid1.ActiveRow.Cells["LOTNO"].Activation            = Activation.Disabled;  // LOT NO
            grid1.ActiveRow.Cells["INDATE"].Activation           = Activation.Disabled;  // 입고 일자
            grid1.ActiveRow.Cells["INQTY"].Activation            = Activation.Disabled;  // 입고 수량
            grid1.ActiveRow.Cells["INWORKER"].Activation         = Activation.Disabled;  // 입고자

            grid1.ActiveRow.Cells["MAKER"].Activation            = Activation.Disabled; 
            grid1.ActiveRow.Cells["MAKEDATE"].Activation         = Activation.Disabled; 
            grid1.ActiveRow.Cells["EDITOR"].Activation           = Activation.Disabled; 
            grid1.ActiveRow.Cells["EDITDATE"].Activation         = Activation.Disabled; 
        }

        public override void DoDelete()
        {
            if (Convert.ToString(grid1.ActiveRow.Cells["ORDERNO"].Value) != "")
            {
                ShowDialog("작업 지시 확정 내역을 취소 후 진행하세요.");
                return;
            }

            base.DoDelete();
            this.grid1.DeleteRow();
        }

        public override void DoSave()
        {
            // 1. 그리드에 있는 갱신 이력이 있는 행들만 추출.
            DataTable dt = grid1.chkChange();
            if (dt is null) return;

            // 데이터베이스 오픈 및 트랜잭션 설정.
            DBHelper helper = new DBHelper("", true);

            try
            {
                // 해당 내역을 저장하시겠습니까?
                if (ShowDialog("해당 내역을 저장하시겠습니까?") == DialogResult.Cancel)
                {
                    throw new Exception("비가동 코드를 입력하지 않았습니다.");
                }

                // 갱신 이력이 담긴 데이터테이블에서 한 행씩 뽑아와서 처리한다.
                foreach (DataRow dr in dt.Rows)
                {
                    // 추출한 행의 상태가
                    switch (dr.RowState)
                    {
                        // 추가된 상태이면
                        case DataRowState.Added:
                            // 품목과 수량을 입력했는 지 확인
                            string sMessage = string.Empty;

                            if (Convert.ToString(dr["ITEMCODE"]) == "") sMessage += "품목 ";
                            if (Convert.ToString(dr["POQTY"])  == "")   sMessage += "발주 수량 ";
                            if (Convert.ToString(dr["CUSTCODE"]) == "") sMessage += "협력 업체 ";
                            if (Convert.ToString(dr["PODATE"]) == "") sMessage += "발주 일자 ";
                            if (sMessage != "") throw new Exception($"{sMessage}을 입력하지 않았습니다.");

                            helper.ExecuteNoneQuery("13MM_POMake_I", CommandType.StoredProcedure
                                , helper.CreateParameter("PLANTCODE",  Convert.ToString(dr["PLANTCODE"]))
                                , helper.CreateParameter("ITEMCODE",   Convert.ToString(dr["ITEMCODE"]))
                                , helper.CreateParameter("PODATE",     Convert.ToString(dr["PODATE"]))
                                , helper.CreateParameter("POQTY",      Convert.ToString(dr["POQTY"]).Replace(",", ""))
                                , helper.CreateParameter("UNITCODE",   Convert.ToString(dr["UNITCODE"]))
                                , helper.CreateParameter("CUSTCODE",   Convert.ToString(dr["CUSTCODE"]))
                                , helper.CreateParameter("MAKER",      LoginInfo.UserID)
                               );
                            break;
                        // 삭제된 상태이면
                        case DataRowState.Deleted:
                            dr.RejectChanges();

                            helper.ExecuteNoneQuery("13MM_POMake_D", CommandType.StoredProcedure
                                                    , helper.CreateParameter("@PLANTCODE", Convert.ToString(dr["PLANTCODE"]))
                                                    , helper.CreateParameter("@PLANNO",    Convert.ToString(dr["PLANNO"])));
                            break;
                        // 수정된 상태이면
                        case DataRowState.Modified:
                            // 원자재 입고 등록
                            if (Convert.ToString(dr["CHK"]) == "1")
                            {
                                if (Convert.ToString(dr["INQTY"]) == "") throw new Exception("입고 수량을 입력하지 않았습니다.");
                            }

                            // 체크박스에 체크가 되어 있으면 확정 로직으로 간주
                            // 체크박스에 체크가 해제되어 있으면 확정 취소 로직으로 간주
                            string sInFlag = "N";
                            if (Convert.ToString(dr["CHK"]) == "1") sInFlag = "Y";
                            helper.ExecuteNoneQuery("13MM_POMake_U",   CommandType.StoredProcedure
                                , helper.CreateParameter("@PLANTCODE", Convert.ToString(dr["PLANTCODE"]))
                                , helper.CreateParameter("@PONO",      Convert.ToString(dr["PONO"]))
                                , helper.CreateParameter("@PODATE",    Convert.ToString(dr["PODATE"]))
                                , helper.CreateParameter("@POSEQ",     Convert.ToString(dr["POSEQ"]))
                                , helper.CreateParameter("@ITEMCODE",  Convert.ToString(dr["ITEMCODE"]))
                                //, helper.CreateParameter("@INFLAG",    sInFlag)
                                , helper.CreateParameter("@INQTY",     Convert.ToString(dr["INQTY"]))
                                //, helper.CreateParameter("@LOTNO",     Convert.ToString(dr["LOTNO"]))
                                //, helper.CreateParameter("@INDATE",    Convert.ToString(dr["INDATE"]))
                                //, helper.CreateParameter("@INWORKER",  LoginInfo.UserID)
                                , helper.CreateParameter("@EDITOR",    LoginInfo.UserID)
                                );
                            break;
                    }

                    if (helper.RSCODE != "S")
                    {
                        throw new Exception(helper.RSMSG);
                    }

                }

                // 트랜잭션 커밋
                helper.Commit();

                ShowDialog("정상적으로 등록하였습니다.");
                DoInquire(); // 완료된 내역 재조회.
            }
            catch (Exception ex)
            {
                // 트랜잭션 취소
                helper.Rollback();
            }
            finally
            {
                // 데이터베이스 닫기
                helper.Close();
            }
        }
        #endregion
    }
}
