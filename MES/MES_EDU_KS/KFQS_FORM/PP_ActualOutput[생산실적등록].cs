using System;
using System.Data;
using System.Windows.Forms;
using DC00_assm;
using DC00_WinForm;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using DC00_PuMan;
using DC_POPUP;
using System.Drawing;

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
            _GridUtil.InitColumnUltraGrid(grid1, "STARTDATE",            "지시 시작 일시",   GridColDataType_emu.DateTime24,      130, HAlign.Left,   true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "ENDDATE",              "지시 종료 일시",   GridColDataType_emu.DateTime24,      130, HAlign.Left,   true,  false);

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

        #region < 작업장 조회 (현재 상태 및 작업 지시 내역 포함) >
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

        private void cboWorkCenter_H_ValueChanged(object sender, EventArgs e)
        {
            // 작업자 콤보박스 변경 시 해당 작업장 내역만 조회되도록 설정.
            SetWorkCenter();
        }
        #endregion

        /// <summary>
        /// grid 값이 존재하는 지, 또 grid의 row를 선택했는 지 검사한다.
        /// </summary>
        private void checkGridValidation()
        {
            if (grid1.Rows.Count == 0) return;
            if (grid1.ActiveRow is null)
            {
                ShowDialog("아래의 표의 작업장을 선택 후 진행하세요.");
                return;
            }

        }

    #region < 작업자 등록 >
    private void btnWorkerReg_Click(object sender, EventArgs e)
        {
            // 1. 작업장 선택 여부 확인
            checkGridValidation();

            string sWorkerID = txtWorkerID_H.Text; // textBox의 작업자 ID Text를 가져온다.
            if (sWorkerID == "")
            {
                ShowDialog("작업자를 선택 후 진행하세요.");
                return;
            }

            string sPlantCode      = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);        // 공장
            string sWorkCenterCode = Convert.ToString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);   // 작업장


            DBHelper helper = new DBHelper("", true);

            try
            {
                // 선택한 작업장에 작업자를 등록
                helper.ExecuteNoneQuery("13PP_ActualOutput_I1", CommandType.StoredProcedure
                    , helper.CreateParameter("@PLANTCODE", sPlantCode)
                    , helper.CreateParameter("@WORKCENTERCODE", sWorkCenterCode)
                    , helper.CreateParameter("@WORKERID", sWorkerID)
                    );

                if (helper.RSCODE != "S") throw new Exception($"작업자 등록 중 오류가 발생하였습니다.\r\n{helper.RSMSG}");

                helper.Commit();
                ShowDialog("정상적으로 등록을 완료하였습니다.");
                SetWorkCenter(); // 정상 완료 후 재조회
            }
            catch (Exception ex)
            {
                helper.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region < 3. 작업 지시 선택 및 등록 >
        private void btnWorkOrderReg_Click(object sender, EventArgs e)
        {
            checkGridValidation();

            // 작업장에 등록된 작업자가 있는가?
            string sWorkerID = Convert.ToString(grid1.ActiveRow.Cells["WORKER"].Value);
            if (sWorkerID == "")
            {
                ShowDialog("현재 작업장에 등록된 작업자 내역이 없습니다.\r\n작업자 등록 후 진행하세요.");
                return;
            }

            // 작업장이 비가동 상태인가?
            string sRunStopFlag = Convert.ToString(grid1.ActiveRow.Cells["WORKSTATUSCODE"].Value);
            if (sRunStopFlag != "S")
            {
                ShowDialog("현재 작업장이 가동 상태입니다.\r\n비가동 등록 후 진항하세요.");
                return;
            }

            // 투입된 LOT가 있는가?
            string sMatLotNo = Convert.ToString(grid1.ActiveRow.Cells["MATLOTNO"].Value).Trim();
            if (sMatLotNo != "")
            {
                ShowDialog("현재 투입된 LOT가 있습니다.\r\n투입 LOT를 투입 취소 후 진항하세요.");
                return;
            }

            // 작업장에 동일한 작업지시를 선택하였는가?
            string sWorkCenterCode = Convert.ToString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value).Trim();
            string sWorkCenterName = Convert.ToString(grid1.ActiveRow.Cells["WORKCENTERNAME"].Value).Trim();

            POP_WOKRORDER pop_workOrder = new POP_WOKRORDER(sWorkCenterCode, sWorkCenterName);
            pop_workOrder.ShowDialog();

            // OrderNo를 선택하지 않고 Pop up을 닫았을 경우
            if (pop_workOrder.Tag is null) return;
            
            string sOrderNo = Convert.ToString(pop_workOrder.Tag);
            
            if (sOrderNo.Trim() == Convert.ToString(grid1.ActiveRow.Cells["ORDERNO"].Value).Trim())
            {
                MessageBox.Show("작업장에 동일한 작업 지시가 선택되었습니다.");
                return;
            }

            grid1.ActiveRow.Cells["ORDERNO"].Value = sOrderNo;

            DBHelper helper = new DBHelper("", true);

            try
            {
                // 선택한 작업장에 작업자를 등록
                helper.ExecuteNoneQuery("13PP_ActualOutput_I2", CommandType.StoredProcedure
                    , helper.CreateParameter("@PLANTCODE", sPlantCode)
                    , helper.CreateParameter("@WORKCENTERCODE", sWorkCenterCode)
                    , helper.CreateParameter("@ORDERNO", sOrderNo)
                    , helper.CreateParameter("@WORKERID", sWorkerID)
                    );

                if (helper.RSCODE != "S") throw new Exception($"작업자 등록 중 오류가 발생하였습니다.\r\n{helper.RSMSG}");

                helper.Commit();
                ShowDialog("정상적으로 등록을 완료하였습니다.");
                SetWorkCenter(); // 정상 완료 후 재조회
            }
            catch (Exception ex)
            {
                helper.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        private void grid1_AfterRowActivate(object sender, EventArgs e)
        {
            // 그리드의 행을 선택 후 일어나는 이벤트
            // 1. 등록된 작업자를 작업자 텍스트박스에 표시.
            txtWorkerID_H.Text = Convert.ToString(grid1.ActiveRow.Cells["WORKER"].Value);
            txtWorkerName_H.Text = Convert.ToString(grid1.ActiveRow.Cells["WORKERNAME"].Value);

            // 2. 투입된 원자재 LOT가 있을 경우 투입 취소 버튼 이름으로 변경.
            string sMatLotNo = Convert.ToString(grid1.ActiveRow.Cells["MATLOTNO"].Value);
            if (sMatLotNo == "")
            {
                txtROHLotNo_H.Text = "";
                btnROHLotReg.Text = "LOT 투입";
                btnROHLotReg.BackColor = Color.Blue;
                btnROHLotReg.Tag = "IN";
            }
            else
            {
                txtROHLotNo_H.Text = sMatLotNo;
                btnROHLotReg.Text = "LOT 투입 취소";
                btnROHLotReg.BackColor = Color.Red;
                btnROHLotReg.Tag = "CANCEL";
            }

            // 3. 현재 작업장 가동/비가동 상태에 따라 R, S 으로 Button Text 변경
            if (Convert.ToString(grid1.ActiveRow.Cells["WORKSTATUSCODE"].Value) == "R")
            {
                btnRunStop_H.Text = "⛔비가동";
                btnRunStop_H.Tag  = "S";
            }
            else
            {
                btnRunStop_H.Text = "⚙가동";
                btnRunStop_H.Tag = "R";
            }
        }

        private void btnROHLotReg_Click(object sender, EventArgs e)
        {
            // 원자재 LOT 투입
            checkGridValidation();

            string sOrderNo = Convert.ToString(grid1.ActiveRow.Cells["ORDERNO"].Value);
            if (sOrderNo == "")
            {
                ShowDialog("작업장에 작업지시가 선택되지 않았습니다.");
                return;
            }

            string sWorkerID = Convert.ToString(grid1.ActiveRow.Cells["WORKER"].Value);
            if (sWorkerID == "")
            {
                ShowDialog("등록된 작업자가 없습니다. 작업자 선택 후 진행하세요.");
                return;
            }

            DBHelper helper = new DBHelper("", true);

            try
            {
                string sItemCode = Convert.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
                string sLotNo = txtROHLotNo_H.Text;
                string sWorkCenterCode = Convert.ToString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);
                string sUnitCode = Convert.ToString(grid1.ActiveRow.Cells["UNITCODE"].Value);

                // 선택한 작업장에 원자재 LOT 투입/취소
                helper.ExecuteNoneQuery("13PP_ActualOutput_I3", CommandType.StoredProcedure
                    , helper.CreateParameter("@PLANTCODE", sPlantCode)
                    , helper.CreateParameter("@WORKCENTERCODE", sWorkCenterCode)
                    , helper.CreateParameter("@ITEMCODE",       sItemCode)
                    , helper.CreateParameter("@ORDERNO",        sOrderNo)
                    , helper.CreateParameter("@LOTNO",          sLotNo)
                    , helper.CreateParameter("@UNITCODE",       sUnitCode)
                    , helper.CreateParameter("@WORKERID",       sWorkerID)
                    , helper.CreateParameter("@INFLAG",         Convert.ToString(btnROHLotReg.Tag))
                    );

                if (helper.RSCODE != "S") throw new Exception($"LOT 투입/취소 등록 중 오류가 발생하였습니다.\r\n{helper.RSMSG}");

                helper.Commit();
                ShowDialog("정상적으로 등록을 완료하였습니다.");
                SetWorkCenter(); // 정상 완료 후 재조회
            }
            catch (Exception ex)
            {
                helper.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }

        #region < 5. 가동/비가동 클릭 >
        private void btnRunStop_Click(object sender, EventArgs e)
        {
            checkGridValidation();

            DBHelper helper = new DBHelper("", true);

            try
            {
                string sItemCode =       Convert.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
                string sWorkCenterCode = Convert.ToString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);
                string sOrderNo =        Convert.ToString(grid1.ActiveRow.Cells["ORDERNO"].Value);

                // 선택한 작업장에 원자재 LOT 투입/취소
                helper.ExecuteNoneQuery("13PP_ActualOutput_I4", CommandType.StoredProcedure
                    , helper.CreateParameter("@PLANTCODE",      sPlantCode)
                    , helper.CreateParameter("@WORKCENTERCODE", sWorkCenterCode)
                    , helper.CreateParameter("@ITEMCODE",       sItemCode)
                    , helper.CreateParameter("@ORDERNO",        sOrderNo)
                    , helper.CreateParameter("@STATUS",         Convert.ToString(btnRunStop_H.Tag))
                    );

                if (helper.RSCODE != "S") throw new Exception($"작업장 가동/비가동 등록 중 오류가 발생하였습니다.\r\n{helper.RSMSG}");

                helper.Commit();
                ShowDialog("정상적으로 등록을 완료하였습니다.");
                SetWorkCenter(); // 정상 완료 후 재조회
            }
            catch (Exception ex)
            {
                helper.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion


        #region < 6. 생산 실적 등록 >
        private void btnProductReg_Click(object sender, EventArgs e)
        {
            checkGridValidation();

            // 작업 지시 수량 대비 양품/불량 수량 입력 가능 여부 체크
            double dProdQty     = 0; // 누적 양품 수량
            double dBadQty      = 0; // 누적 불량 수량
            double dTextProdQty = 0; // 입력한 양품 수량
            double dTextBadQty  = 0; // 입력한 불량 수량
            double dOrderQty    = 0; // 작업시지 수량

            string sValidMsg = "";

            // 그리드의 누적 양품 수량
            string sProdQty = Convert.ToString(grid1.ActiveRow.Cells["PRODQTY"].Value).Replace(",", "");
            if (!double.TryParse(sProdQty, out dProdQty)) sValidMsg += "양품 수량, ";

            // 그리드의 총 누적 불량 수량
            string sBadQty = Convert.ToString(grid1.ActiveRow.Cells["BADQTY"].Value).Replace(",", "");
            if (!double.TryParse(sBadQty, out dBadQty)) sValidMsg += "불량 수량, ";

            // 입력한 양품 수량
            string sTextProdQty = Convert.ToString(txtProductQty_H.Text);
            if (!double.TryParse(sTextProdQty, out dTextProdQty)) sValidMsg += "입력한 양품 수량, ";

            // 입력한 불량 수량
            string sTextBadQty = Convert.ToString(txtBadQty_H.Text);
            if (!double.TryParse(sTextBadQty, out dTextBadQty)) sValidMsg += "입력한 불량 수량, ";

            // 작업 지시 수량
            string sOrderQty = Convert.ToString(grid1.ActiveRow.Cells["ORDERQTY"].Value).Replace(",", "");
            if (!double.TryParse(sOrderQty, out dOrderQty)) sValidMsg += "작업 지시 수량, ";

            // string -> double 변환 오류 체크
            if (sValidMsg != "")
            {
                ShowDialog($"{sValidMsg.Trim(',', ' ')}의 값을 숫자로 변경하는 도중 오류가 발생했습니다.");
            }

            // 투입된 원자재 LOT가 존재하는 지 확인.
            string sMatLotNo = Convert.ToString(grid1.ActiveRow.Cells["MATLOTNO"].Value);
            if (sMatLotNo == "")
            {
                ShowDialog("투입한 원자재 LOT가 없습니다. LOT 투입 후 진행하세요.");
                return;
            }

            // 양품 또는 불량 수량을 하나도 입력하지 않은 경우
            if (dTextProdQty + dTextBadQty == 0)
            {
                ShowDialog("실적 수량을 입력하세요.");
                return;
            }
            
            // 지시 수량보다 양품 수량이 많은 경우
            if (dOrderQty < dTextProdQty)
            {
                ShowDialog("총 생산 수량이 지시 수량보다 많습니다.");
                return;
            }

            // 생산 실적 등록
            DBHelper helper = new DBHelper("", true);

            try
            {
                string sItemCode = Convert.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
                string sWorkCenterCode = Convert.ToString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);
                string sOrderNo = Convert.ToString(grid1.ActiveRow.Cells["ORDERNO"].Value);
                string sUnitCode = Convert.ToString(grid1.ActiveRow.Cells["UNITCODE"].Value);

                // 생산 실적 등록을 위한 프로시저
                helper.ExecuteNoneQuery("13PP_ActualOutput_I5", CommandType.StoredProcedure
                    , helper.CreateParameter("@PLANTCODE",      sPlantCode)
                    , helper.CreateParameter("@WORKCENTERCODE", sWorkCenterCode)
                    , helper.CreateParameter("@ITEMCODE",       sItemCode)
                    , helper.CreateParameter("@ORDERNO",        sOrderNo)
                    , helper.CreateParameter("@UNITCODE",       sUnitCode)
                    , helper.CreateParameter("@PRODQTY",        sTextProdQty)
                    , helper.CreateParameter("@BADQTY",         sTextBadQty)
                    , helper.CreateParameter("@MATLOTNO",       sMatLotNo)


                    );

                if (helper.RSCODE != "S") throw new Exception($"생산 실적 등록 중 오류가 발생하였습니다.\r\n{helper.RSMSG}");

                helper.Commit();
                ShowDialog("정상적으로 등록을 완료하였습니다.");
                SetWorkCenter(); // 정상 완료 후 재조회

                txtProductQty_H.Text = "";
                txtBadQty_H.Text = "";
            }
            catch (Exception ex)
            {
                helper.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }

        }
        #endregion
    }
}
