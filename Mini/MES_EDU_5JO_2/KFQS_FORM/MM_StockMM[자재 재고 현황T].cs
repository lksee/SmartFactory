using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DC00_assm;
using DC00_WinForm;
using DC00_PuMan;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using DC_POPUP;

/**************************************************************************
 * From ID   : MM_StockMM
 * Form Name : 자재 재고 현황
 * date      : 2022-07-04
 * Mkaer     : 최종현
 * 
 * 수정사항  : 
 * *************************************************************************/
namespace KFQS_Form
{
    public partial class MM_StockMM : DC00_WinForm.BaseMDIChildForm
    {

        #region <  MEMBER AREA  >
        DataTable dtTemp = new DataTable();
        UltraGridUtil _GridUtil = new UltraGridUtil();   // 그리드 셋팅 클래스.
        private string sPlantCode = LoginInfo.PlantCode; // 로그인 한 공장 정보.
        string sY = string.Empty;
        string sN = string.Empty;
        #endregion

        public MM_StockMM()
        {
            InitializeComponent();
        }

        private void MM_StockMM_Load(object sender, EventArgs e)
        {
            // Grid 셋팅. 
            _GridUtil.InitializeGrid(this.grid1);

            // 자재 발주 부분
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",   "공장",       GridColDataType_emu.VarChar, 130, HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",    "품목코드 ",  GridColDataType_emu.VarChar, 130, HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",    "품목명",     GridColDataType_emu.VarChar, 130, HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPTYPE",    "검사구분", GridColDataType_emu.VarChar, 130, HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MATLOTNO",    "LOTNO",      GridColDataType_emu.VarChar, 130, HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE",      "창고",       GridColDataType_emu.VarChar, 130, HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STOCKQTY",    "재고수량",   GridColDataType_emu.VarChar, 130, HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE",    "단위",       GridColDataType_emu.VarChar,    130, HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE",    "거래처코드",   GridColDataType_emu.VarChar,    130, HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME",    "거래처명",    GridColDataType_emu.VarChar,    130, HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INDATE",      "입고일자",   GridColDataType_emu.VarChar,    130, HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER",       "생성자",     GridColDataType_emu.VarChar,    130, HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE",    "생성일시",   GridColDataType_emu.DateTime24, 130, HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPSTATE",   "검사요청 여부", GridColDataType_emu.Button, 130, HAlign.Center, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);


            // 콤보박스 셋팅.


            #region < 콤보박스 셋팅 설명 >
            // 공장

            // 공장에 대한 시스템 공통 코드 내역을 DB 에서 가져온다. => dtTemp 데이터 테이블에 담는다. 
            dtTemp = Common.StandardCODE("PLANTCODE");

            // 콤보박스 에 받아온 데이터를 밸류멤버와 디스플레이멤버로 표현한다.  
            Common.FillComboboxMaster(this.cboPlantCode_H, dtTemp);

            // 그리드의 컬럼에 받아온 데이터를 콤보박스 형식으로 셋팅한다.
            UltraGridUtil.SetComboUltraGrid(grid1, "PLANTCODE", dtTemp);

            #endregion

            // 단위
            dtTemp = Common.StandardCODE("UNITCODE");
            UltraGridUtil.SetComboUltraGrid(grid1, "UNITCODE", dtTemp);

            // 검사 구분
            dtTemp = Common.StandardCODE("INSPTYPE");
            UltraGridUtil.SetComboUltraGrid(grid1, "INSPTYPE", dtTemp);

            // 검사 요청 여부
            // CODE_ID, CODE_NAME, CODE_NAME_ORG, RELCODE1, 2, 3, 4, 5, DISPLAYNO
            dtTemp = Common.StandardCODE("INSPSTATE");

            sY = dtTemp.Rows[0]["CODE_NAME"].ToString();
            sN = dtTemp.Rows[1]["CODE_NAME"].ToString();


            // 창고 코드
            dtTemp = Common.StandardCODE("WHCODE");
            UltraGridUtil.SetComboUltraGrid(grid1, "WHCODE", dtTemp);

            // 품목 타입:
            // FERT : 완제품 , ROH :원자재 ,   HALB : 반제품 ,   OM : 외주가공품.
            dtTemp = Common.Get_ItemCode(new string[] { "ROH" });
            Common.FillComboboxMaster(cboItemCode_H, dtTemp);


            // 공장 로그인 정보로 자동 셋팅.
            cboPlantCode_H.Value = sPlantCode;

            // 발주 시작일자 설정.

        }

        #region < ToolBar Area >
        public override void DoInquire()
        {
            // 툴바의 조회 버튼 클릭.
            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode_ = Convert.ToString(cboPlantCode_H.Value);                // 공장
                string sItemCode = Convert.ToString(cboItemCode_H.Value);                   // 품목코드
                string sLotNO = Convert.ToString(txtPoNO_H.Text);                           // LOTNO.


                dtTemp = helper.FillTable("55MM_StockMM_S", CommandType.StoredProcedure
                                          , helper.CreateParameter("@PLANTCODE", sPlantCode_)
                                          , helper.CreateParameter("@LOTNO", sLotNO)
                                          , helper.CreateParameter("@ITEMCODE", sItemCode));

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

                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    if (Convert.ToString(grid1.Rows[i].Cells["INSPSTATE"].Value) == "Y")
                        grid1.Rows[i].Cells["INSPSTATE"].Value = sY;
                    else grid1.Rows[i].Cells["INSPSTATE"].Value = sN;
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

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            // 자재 식별표 출력.

            // 1.식별표에 전달할 데이터 등록.
            if (grid1.Rows.Count == 0) return;
            // 그리드 의 컬럼을 그대로 가지고 있는 빈깡통 데이터 행 생성
            DataRow drRow = ((DataTable)grid1.DataSource).NewRow();
            // 선택한 행에 있는 데이터를 빈깡통 행에 등록
            drRow["ITEMCODE"] = Convert.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
            drRow["ITEMNAME"] = Convert.ToString(grid1.ActiveRow.Cells["ITEMNAME"].Value);
            drRow["STOCKQTY"] = Convert.ToString(grid1.ActiveRow.Cells["STOCKQTY"].Value);
            drRow["MATLOTNO"] = Convert.ToString(grid1.ActiveRow.Cells["MATLOTNO"].Value);
            drRow["UNITCODE"] = Convert.ToString(grid1.ActiveRow.Cells["UNITCODE"].Value);

            // 바코드 디자인 객체 선언
            Report_LotBacode LotBacode = new Report_LotBacode();
            // 바코드 디자인을 담을 레포트 북 객체 선언.
            Telerik.Reporting.ReportBook reportBook = new Telerik.Reporting.ReportBook();
            // 바코드 디자인에 데이터 바인딩.
            LotBacode.DataSource = drRow;
            // 데이터가 바인딩 된 레프트 디자인 레프트 북에 담기.
            reportBook.Reports.Add(LotBacode);


            // 레포트 뷰어에 레포트 북 추가하여 미리보기 창 활성화
            ReportViewer reportView = new ReportViewer(reportBook, 1);
            reportView.ShowDialog();
        }

        private void btnReqROHIQI_Click(object sender, EventArgs e)
        {
            // 1. 그리드에서 선택된 Row에 대해 수입검사 요청
            if (grid1.ActiveRow == null)
            {
                ShowDialog("아래의 표에서 수입검사를 요청할 행을 선택해주세요.");
                return;
            }

            DBHelper helper = new DBHelper("", true);

            try
            {
                // 변경 내역을 저장 하시겠습니까?
                if (ShowDialog($"{grid1.ActiveRow.Cells["MATLOTNO"].Value}에 대해 수입검사를 요청하시겠습니까?") == DialogResult.Cancel)
                {
                    return;
                }
                
                helper.ExecuteNoneQuery("55MM_StockMM_I", CommandType.StoredProcedure
                                        , helper.CreateParameter("@PLANTCODE", Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value))
                                        , helper.CreateParameter("@LOTNO", Convert.ToString(grid1.ActiveRow.Cells["MATLOTNO"].Value))
                                        , helper.CreateParameter("@REQUESTER", LoginInfo.UserID) 
                                        , helper.CreateParameter("@ITEMCODE", Convert.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value))
                                        , helper.CreateParameter("@INSPQTY", Convert.ToString(grid1.ActiveRow.Cells["STOCKQTY"].Value))
                                        );

                if (helper.RSCODE != "S")
                    throw new Exception("수입검사 요청 등록 중 오류가 발생하였습니다.");

                helper.Commit();
                DoInquire(); //조회
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

        private void grid1_AfterRowActivate(object sender, EventArgs e)
        {
            if (grid1.ActiveRow == null) return;
            if (Convert.ToString(grid1.ActiveRow.Cells["INSPTYPE"].Value) == "I")
            {
                if (Convert.ToString(grid1.ActiveRow.Cells["INSPSTATE"].Value) == sY)
                {
                    btnReqROHIQI.Enabled = false;
                    return;
                }
                btnReqROHIQI.Enabled = true;
            }
            else
            {
                btnReqROHIQI.Enabled = false;
            }
        }

        private void grid1_ClickCellButton(object sender, CellEventArgs e)
        {
            if (Convert.ToString(grid1.ActiveRow.Cells["INSPSTATE"].Value) == sN) return;
            POP_INSPSTATE pop_inspstate = new POP_INSPSTATE(Convert.ToString(grid1.ActiveRow.Cells["MATLOTNO"].Value));
            pop_inspstate.ShowDialog();
        }
    }
}