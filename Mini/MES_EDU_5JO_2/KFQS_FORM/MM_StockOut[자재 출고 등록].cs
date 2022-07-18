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
using DC00_Component;



/**************************************************************************
 * From ID   : MM_StockOut
 * Form Name : 자재 생산 출고 등록
 * date      : 2022-07-05
 * Mkaer     : 동상현
 * 
 * 수정사항  : 
 * *************************************************************************/
namespace KFQS_Form
{
    public partial class MM_StockOut : DC00_WinForm.BaseMDIChildForm
    {

        #region <  MEMBER AREA  >
        DataTable dtTemp          = new DataTable();
        UltraGridUtil _GridUtil   = new UltraGridUtil();   // 그리드 셋팅 클래스.
        private string sPlantCode = LoginInfo.PlantCode;   // 로그인 한 공장 정보.
        #endregion

        public MM_StockOut()
        {
            InitializeComponent();
        }

        private void MM_StockOut_Load(object sender, EventArgs e)
        {
               // Grid 셋팅. 
            _GridUtil.InitializeGrid(this.grid1);

            _GridUtil.InitColumnUltraGrid(grid1, "CHK",         "선택",         GridColDataType_emu.CheckBox,   80,    HAlign.Center,  true,  true);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",   "공장",         GridColDataType_emu.VarChar,    120,   HAlign.Left,    true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "MATLOTNO",    "LOTNO",        GridColDataType_emu.VarChar,    160,   HAlign.Left,    true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",    "품목코드",     GridColDataType_emu.VarChar,    140,   HAlign.Left,    true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",    "품목명",       GridColDataType_emu.VarChar,    150,   HAlign.Left,    true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPTYPE",    "관리항목구분", GridColDataType_emu.VarChar,    150,   HAlign.Left,    true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPRESULT",  "수입검사결과", GridColDataType_emu.VarChar,    150,   HAlign.Left,    true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "INDATE",      "입고일자",     GridColDataType_emu.VarChar,    120,   HAlign.Left,    true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE",      "창고",         GridColDataType_emu.VarChar,    120,   HAlign.Left,    true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "STOCKQTY",    "재고수량",     GridColDataType_emu.Double,     130,   HAlign.Right,   true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "BASEUNIT",    "단위",         GridColDataType_emu.VarChar,    130,   HAlign.Left,    true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER",       "생성자",       GridColDataType_emu.VarChar,    130,   HAlign.Left,    true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE",    "생성일시",     GridColDataType_emu.DateTime24, 160,   HAlign.Left,    true,  false);

            _GridUtil.SetInitUltraGridBind(grid1);


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

            // 창고 코드 
            dtTemp = Common.StandardCODE("WHCODE");
            UltraGridUtil.SetComboUltraGrid(grid1, "WHCODE", dtTemp);

            // 검사 결과
            dtTemp = Common.StandardCODE("INSPRESULT");
            UltraGridUtil.SetComboUltraGrid(grid1, "INSPRESULT", dtTemp);

            // 관리 항목 구분
            dtTemp = Common.StandardCODE("INSPTYPE");
            UltraGridUtil.SetComboUltraGrid(grid1, "INSPTYPE", dtTemp);

            // 품목 타입
            // FERT :  완제품,    ROH : 원자재,    HALB : 반제품,   OM : 외주가공품.
            dtTemp = Common.Get_ItemCode(new string[] { "ROH" });
            Common.FillComboboxMaster(cboItemCode_H, dtTemp);




            // 공장 로그인 정보로 자동 셋팅.
            cboPlantCode_H.Value = sPlantCode;
            
        }

        #region < ToolBar Area >
        public override void DoInquire()
        {
            // 툴바의 조회 버튼 클릭.
            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode_ = Convert.ToString(cboPlantCode_H.Value);            // 공장
                string sItemCode   = Convert.ToString(cboItemCode_H.Value);             // 품목코드
                string sLotNO      = Convert.ToString(txtLotNO_H.Text);                 // LOTNO
                string sStartdate  = string.Format("{0:yyyy-MM-dd}", dtpStart_H.Value); // 입/출고 시작일시
                string sEnddate    = string.Format("{0:yyyy-MM-dd}", dtpEnd_H.Value);   // 입/출고 종료일시

                dtTemp = helper.FillTable("55MM_StockOut_S", CommandType.StoredProcedure
                                          , helper.CreateParameter("@PLANTCODE",        sPlantCode_)
                                          , helper.CreateParameter("@LOTNO",            sLotNO)
                                          , helper.CreateParameter("@ITEMCODE",         sItemCode)
                                          , helper.CreateParameter("@STARTDATE",        sStartdate)
                                          , helper.CreateParameter("@ENDDATE",          sEnddate)
                                          );

                // 받아온 데이터 그리드 매핑
                if (dtTemp.Rows.Count == 0)
                {
                    // 그리드 초기화.
                    _GridUtil.Grid_Clear(grid1);
                    ShowDialog("조회할 데이터가 없습니다.", DialogForm.DialogType.OK);
                    return;
                }

                this.ClosePrgForm();
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
            base.DoSave();

            // 입고된 순으로 FIFO 되도록 권장하는 메시지 출력.
            // 입고가 가장 빠른 열을 구한다.
            string sDate = string.Empty;
            DateTime dtDate = new DateTime();
            int iRowIndex = -1;

            for (int i = 0; i < grid1.Rows.Count; i++)
            {
                // 최초 값 세팅
                if (sDate == string.Empty || 
                    // 기존 dtDate가 더 크면 현재 Row에 있는 날짜 값으로 업데이트 -> 제일 처음 입고된 날짜를 추리기 위함
                    DateTime.Compare(dtDate, Convert.ToDateTime( grid1.Rows[i].Cells["MAKEDATE"].Value) ) > 0)
                {
                    dtDate = Convert.ToDateTime(grid1.Rows[i].Cells["MAKEDATE"].Value);
                    sDate = Convert.ToString(grid1.Rows[i].Cells["MAKEDATE"].Value);
                    iRowIndex = i;
                }
            }

            


            // 1. 그리드에서 변경된 내역이 있는 행만 추출.
            DataTable dt = grid1.chkChange();
            if (dt == null) return;

            DBHelper helper = new DBHelper("", true);

            // 변경된 행 중 가장 빠른 입고 날짜를 구한다.
            DateTime dtChDate = new DateTime();
            string sChDate = string.Empty;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                // 최초 값 세팅
                if (sChDate == string.Empty ||
                    // 기존 dtDate가 더 크면 현재 Row에 있는 날짜 값으로 업데이트 -> 제일 처음 입고된 날짜를 추리기 위함
                    DateTime.Compare(dtDate, Convert.ToDateTime(dt.Rows[i]["MAKEDATE"])) > 0)
                {
                    dtChDate = Convert.ToDateTime(dt.Rows[i]["MAKEDATE"]);
                }
            }

            // 변경된 행 중 가장 과거의 입고 날짜 vs 전체 행 중 가장 과거의 입고 날짜
            if (DateTime.Compare(dtChDate, dtDate) > 0)
            {
                if (ShowDialog($"가장 빠른 입고일은 {sDate}({iRowIndex + 1}행)입니다.\r\n" +
                    $"입고일 기준 선입선출(FIFO)를 권장합니다.\r\n" +
                    $"현재 선택한 자재를 우선 출고 등록하시겠습니까?") == DialogResult.Cancel)
                {
                    grid1.Rows[iRowIndex].Selected = true;
                    grid1.Rows[iRowIndex].Activated = true;
                    return;
                }
            }

            try
            {
                // 변경 내역을 저장 하시겠습니까 ? 
                if (ShowDialog("변경 내역을 저장 하시겠습니까?") == DialogResult.Cancel)
                {
                    return;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToString(dt.Rows[i]["CHK"]) == "0") continue;

                    helper.ExecuteNoneQuery("55MM_Stockout_I", CommandType.StoredProcedure
                                            , helper.CreateParameter("@PLANTCODE", Convert.ToString(dt.Rows[i]["PLANTCODE"]))
                                            , helper.CreateParameter("@LOTNO",     Convert.ToString(dt.Rows[i]["MATLOTNO"]))
                                            , helper.CreateParameter("@ITEMCODE",  Convert.ToString(dt.Rows[i]["ITEMCODE"]))
                                            , helper.CreateParameter("@QTY",       Convert.ToString(dt.Rows[i]["STOCKQTY"]))
                                            , helper.CreateParameter("@UNITCODE",  Convert.ToString(dt.Rows[i]["UNITCODE"]))
                                            , helper.CreateParameter("@WORKERID",  LoginInfo.UserID)
                                            );

                    if (helper.RSCODE != "S")
                        throw new Exception("생산 출고 등록 중 오류가 발생하였습니다.");
                }
                helper.Commit();
                DoInquire(); // 조회
                this.ClosePrgForm();
                ShowDialog("정상적으로 등록 하였습니다.");
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

        private void grid1_CellChange(object sender, CellEventArgs e)
        {
            if (Convert.ToString(grid1.ActiveRow.Cells["CHK"].Value) == "0")
            {
                // INSPTYPE: 무검사 -> U   / 검사 -> I
                // 무검사 -> 그냥 출고 가능.
                // 검사   -> 수입검사가 통과되어야 출고 가능.
                if (Convert.ToString(grid1.ActiveRow.Cells["INSPTYPE"].Value) == "I")
                {
                    // INSPRESULT: 적격 -> (G)ood   / 부적격 -> (R)eject
                    // INSPTYPE == I 일 때만 확인
                    // INSPRESULT == R 메시지를 띄우고 return;
                    // INSPRESULT == G 그냥 선택되게 하면 됨.
                    if (Convert.ToString(grid1.ActiveRow.Cells["INSPRESULT"].Value) != "G")
                    {
                        grid1.ActiveRow.Cells["CHK"].Value = "0";
                        MessageBox.Show("해당 품목은 수입검사 적격 판정을 받아야 출고 가능합니다.");
                        return;
                    }
                }
            }
        }
    }
}
