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
    /// From ID   : MM_ROHIQI
    /// Form Name : 원자재 수입검사
    /// date      : 2022-07-12
    /// Maker     : 이기수
    /// </summary>
    public partial class MM_ROHIQI : DC00_WinForm.BaseMDIChildForm
    {

        #region <  MEMBER AREA  >
        DataTable dtTemp          = new DataTable();
        UltraGridUtil _GridUtil   = new UltraGridUtil();   // 그리드 셋팅 클래스.
        private string sPlantCode = LoginInfo.PlantCode;   // 로그인 한 공장 정보.
        #endregion

        public MM_ROHIQI()
        {
            InitializeComponent();
        }

        private void MM_ROHIQI_Load(object sender, EventArgs e)
        {
            // Grid 셋팅. 
            _GridUtil.InitializeGrid(this.grid1);

            // 원자재 수입검사 요청 내역 조회 
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",    "공장",         GridColDataType_emu.VarChar,       80,   HAlign.Left,    true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPSEQ",      "요청 횟수",    GridColDataType_emu.VarChar,       80,   HAlign.Left,    true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO",        "발주번호",     GridColDataType_emu.VarChar,      180,   HAlign.Left,    true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPRESULT",   "검사 결과",    GridColDataType_emu.VarChar,       80,   HAlign.Left,    true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "REQDATE",      "요청일시",     GridColDataType_emu.YearMonthDay, 130,   HAlign.Center,  true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "REQUESTER",    "요청자",       GridColDataType_emu.VarChar,      100,   HAlign.Center,  true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",     "품명",         GridColDataType_emu.VarChar,      160,   HAlign.Left,    true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPQTY",      "검사 수량",    GridColDataType_emu.Double,        80,   HAlign.Right,   true,  false);

            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2);

            // 원자재 수입검사 항목
            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE",    "공장",           GridColDataType_emu.VarChar,      130,   HAlign.Left, false,  false);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPSEQ",      "수입검사 번호",  GridColDataType_emu.VarChar,      130,   HAlign.Left, false,  false);
            _GridUtil.InitColumnUltraGrid(grid2, "LOTNO",        "발주번호",       GridColDataType_emu.VarChar,      130,   HAlign.Left, false,  false);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPCODE",     "검사 코드",      GridColDataType_emu.VarChar,      130,   HAlign.Left, false,  false);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPNAME",     "검사 명칭",      GridColDataType_emu.VarChar,      130,   HAlign.Left,  true,  false);
            _GridUtil.InitColumnUltraGrid(grid2, "IQITYPE",      "검사유형",       GridColDataType_emu.VarChar,       80,   HAlign.Left,  true,  false);
            _GridUtil.InitColumnUltraGrid(grid2, "POSPEC",       "관련 규정",      GridColDataType_emu.Button,       130,   HAlign.Left,  true,  false);
            _GridUtil.InitColumnUltraGrid(grid2, "LSL",          "관리 하한선",    GridColDataType_emu.VarChar,       80,   HAlign.Right, true,  false);
            _GridUtil.InitColumnUltraGrid(grid2, "INPUTVALUE",   "결과 입력",      GridColDataType_emu.VarChar,      130,   HAlign.Right, true,  true);
            _GridUtil.InitColumnUltraGrid(grid2, "USL",          "관리 상한선",    GridColDataType_emu.VarChar,       80,   HAlign.Right, true,  false);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPRESULT",   "검사 결과",      GridColDataType_emu.VarChar,       80,   HAlign.Center, true,  false);
            _GridUtil.InitColumnUltraGrid(grid2, "REMARK",       "비고",           GridColDataType_emu.VarChar,      240,   HAlign.Left,  true,  true);
            
            _GridUtil.InitColumnUltraGrid(grid2, "MAKER",        "생성자",       GridColDataType_emu.VarChar,    130,   HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKEDATE",     "생성일시",     GridColDataType_emu.DateTime24, 130,   HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITOR",       "수정자",       GridColDataType_emu.VarChar,    130,   HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITDATE",     "수정일시",     GridColDataType_emu.DateTime24, 130,   HAlign.Left, false, false);

            _GridUtil.SetInitUltraGridBind(grid2);
            
            // 콤보박스 셋팅.


            #region < 콤보박스 셋팅 설명 >
            // 공장
            // 공장에 대한 시스템 공통 코드 내역을 DB 에서 가져온다. => dtTemp 데이터 테이블에 담는다. 
            dtTemp = Common.StandardCODE("PLANTCODE");
            // 콤보박스 에 받아온 데이터를 밸류멤버와 디스플레이멤버로 표현한다.  
            Common.FillComboboxMaster(cboPlantCode_H,dtTemp);
            // 그리드의 컬럼에 받아온 데이터를 콤보박스 형식으로 셋팅한다.
            UltraGridUtil.SetComboUltraGrid(grid1, "PLANTCODE", dtTemp);
            #endregion

            // 단위
            dtTemp = Common.StandardCODE("UNITCODE");
            UltraGridUtil.SetComboUltraGrid(grid1, "UNITCODE", dtTemp);

            // 수입검사 결과
            dtTemp = Common.StandardCODE("INSPRESULT");
            UltraGridUtil.SetComboUltraGrid(grid1, "INSPRESULT", dtTemp);
            dtTemp = Common.StandardCODE("INSPRESULT");
            UltraGridUtil.SetComboUltraGrid(grid2, "INSPRESULT", dtTemp);

            // 품목 타입
            // FERT :  완제품,    ROH : 원자재,    HALB : 반제품,   OM : 외주가공품.
            dtTemp = Common.Get_ItemCode(new string[] { "ROH" });
            Common.FillComboboxMaster(cboItemCode_H, dtTemp);
            UltraGridUtil.SetComboUltraGrid(grid1, "ITEMCODE", dtTemp);

            // 수입검사 유형
            dtTemp = Common.StandardCODE("IQITYPE");
            UltraGridUtil.SetComboUltraGrid(grid2, "IQITYPE", dtTemp);

            // 공장 로그인 정보로 자동 셋팅.
            cboPlantCode_H.Value = sPlantCode;
            
            // 발주 시작일자 설정. 
            dtpStart_H.Value = string.Format("{0:yyyy-MM-01}", DateTime.Now);
        }

        #region < ToolBar Area >
        public override void DoInquire()
        {
            // 툴바의 조회 버튼 클릭.
            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode_ = Convert.ToString(cboPlantCode_H.Value);            // 공장
                string sRequester  = Convert.ToString(txtRequester_H.Text);             // 요청자
                string sStartDate  = string.Format("{0:yyyy-MM-dd}", dtpStart_H.Value); // 요청 시작 일자
                string sEndDate    = string.Format("{0:yyyy-MM-dd}", dtpEnd_H.Value);   // 요청 종료 일자
                string sItemCode   = Convert.ToString(cboItemCode_H.Value);             // 품목코드
                string sLotNo      = Convert.ToString(txtLOTNO_H.Text);                 // LOT NO 번호

                dtTemp = helper.FillTable("55MM_ROHIQI_S1", CommandType.StoredProcedure
                                          , helper.CreateParameter("@PLANTCODE",        sPlantCode_)
                                          , helper.CreateParameter("@REQUESTER",        sRequester)
                                          , helper.CreateParameter("@LOTNO",            sLotNo)
                                          , helper.CreateParameter("@ITEMCODE",         sItemCode)
                                          , helper.CreateParameter("@STARTDATE",        sStartDate)
                                          , helper.CreateParameter("@ENDDATE",          sEndDate)
                                          );

                // 받아온 데이터 그리드 매핑
                if (dtTemp.Rows.Count == 0)
                {
                    // 그리드 초기화.
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

        public override void DoSave()
        {
            int iCheckValidation = 0;
            // Check Validation
            for (int i = 0; i < grid2.Rows.Count; i++)
            {
                if (Convert.ToString(grid2.Rows[i].Cells["INPUTVALUE"].Value) == "")
                {
                    iCheckValidation++;
                    grid2.Rows[i].Cells["INPUTVALUE"].Selected = true;
                }
            }

            // Validation에 부합하는 결과가 하나라도 있다면 실행
            if (iCheckValidation > 0)
            {
                ShowDialog("수입검사 결과를 빠짐 없이 모두 기입해주시기 바랍니다.");
                return;
            }

            // 1. 그리드에 있는 갱신 이력이 있는 행들만 추출.
            DataTable dt = grid2.chkChange();
            if (dt == null) return;

            // 데이터베이스 오픈 및 트랜잭션 설정.
            DBHelper helper = new DBHelper("", true);

            try
            {
                // 해당 내역을 저장 하시겠습니까 ? 
                if (ShowDialog("해당 내역을 저장 하시겠습니까?") == DialogResult.Cancel)
                {
                    return;
                }

                // 갱신 이력이 담긴 데이터테이블에서 한 행씩 뽑아와서 처리한다. 
                foreach (DataRow dr in dt.Rows)
                {
                    // 추출한 행의 상태가.
                    switch (dr.RowState)
                    {
                        // 수정 된 상태이면
                        case DataRowState.Modified:
                            // 수입검사 항목별 이력을 저장한다.
                            helper.ExecuteNoneQuery("55MM_ROHIQIREC_I", CommandType.StoredProcedure
                                                    , helper.CreateParameter("@PLANTCODE",  Convert.ToString(dr["PLANTCODE"]))
                                                    , helper.CreateParameter("@INSPSEQ",    Convert.ToString(dr["INSPSEQ"]))
                                                    , helper.CreateParameter("@LOTNO",      Convert.ToString(dr["LOTNO"]))
                                                    , helper.CreateParameter("@INSPCODE",   Convert.ToString(dr["INSPCODE"]))
                                                    , helper.CreateParameter("@INSPNAME",   Convert.ToString(dr["INSPNAME"]))
                                                    , helper.CreateParameter("@IQITYPE",    Convert.ToString(dr["IQITYPE"]))
                                                    , helper.CreateParameter("@INSPECTOR",  LoginInfo.UserID)
                                                    , helper.CreateParameter("@POSPEC",     Convert.ToString(dr["POSPEC"]))
                                                    , helper.CreateParameter("@LSL",        Convert.ToString(dr["LSL"]))
                                                    , helper.CreateParameter("@INPUTVALUE", Convert.ToString(dr["INPUTVALUE"]).Replace(",", "").Trim())
                                                    , helper.CreateParameter("@USL",        Convert.ToString(dr["USL"]))
                                                    , helper.CreateParameter("@REMARK",     Convert.ToString(dr["REMARK"]).Trim()));

                            break;
                    }
                    if (helper.RSCODE != "S")
                    {
                        throw new Exception(helper.RSMSG);
                    }
                }

                //  
                helper.ExecuteNoneQuery("55MM_ROHIQI_U", CommandType.StoredProcedure
                                        , helper.CreateParameter("@PLANTCODE",  Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value))
                                        , helper.CreateParameter("@INSPSEQ",    Convert.ToString(grid1.ActiveRow.Cells["INSPSEQ"].Value))
                                        , helper.CreateParameter("@LOTNO",      Convert.ToString(grid1.ActiveRow.Cells["LOTNO"].Value))
                                        , helper.CreateParameter("@INSPECTOR",  LoginInfo.UserID)
                                        );

                // 데이터 베이스 등록 완료.
                helper.Commit();
                ShowDialog("정상적으로 등록 하였습니다.");
                DoInquire();
            }
            catch (Exception ex)
            {
                // 데이터 등록 복구
                helper.Rollback();
                ShowDialog(ex.ToString());
            }
            finally
            {
                // 데이터 베이스 닫기
                helper.Close();
            }
        }
        #endregion

        private void grid1_AfterRowActivate(object sender, EventArgs e)
        {


            // 수입검사 요청 사항이 표기된 grid 클릭
            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode_ = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value); // 공장
                string sInspSeq    = Convert.ToString(grid1.ActiveRow.Cells["INSPSEQ"].Value);   // 수입검사 번호
                string sLotNo      = Convert.ToString(grid1.ActiveRow.Cells["LOTNO"].Value);     // LOTNO
                string sItemCode   = Convert.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value);  // 품목코드

                dtTemp = helper.FillTable("55MM_ROHIQI_S2", CommandType.StoredProcedure
                                          , helper.CreateParameter("@PLANTCODE", sPlantCode_)
                                          , helper.CreateParameter("@LOTNO",     sLotNo)
                                          , helper.CreateParameter("@ITEMCODE",  sItemCode)
                                          , helper.CreateParameter("@INSPSEQ",   sInspSeq)
                                          );



                // 받아온 데이터 그리드 매핑
                if (dtTemp.Rows.Count == 0)
                {
                    // 그리드 초기화.
                    _GridUtil.Grid_Clear(grid2);
                    ShowDialog("조회할 데이터가 없습니다.", DialogForm.DialogType.OK);
                    return;
                }

                grid2.DataSource = dtTemp;
                grid2.DataBinds(dtTemp);

                if (Convert.ToString(grid1.ActiveRow.Cells["INSPRESULT"].Value) != "")
                {
                    // Grid 셋팅. 
                    for (int i = 0; i < grid2.Rows.Count; i++)
                    {
                        grid2.Rows[i].Cells["INPUTVALUE"].Activation = Activation.Disabled;
                        grid2.Rows[i].Cells["REMARK"].Activation = Activation.Disabled;
                    }
                }

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
    }
}
