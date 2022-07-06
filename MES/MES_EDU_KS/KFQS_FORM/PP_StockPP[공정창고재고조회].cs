using System;
using System.Data;
using DC00_assm;
using DC00_WinForm;
using Infragistics.Win;
using DC_POPUP;
using DC00_PuMan;
using System.Windows.Forms;

namespace KFQS_Form
{
    /// <summary>
    /// Form ID   : PP_StockPP
    /// Form Name : 공정 재고 조회 및 원자재 입고 등록 취소.
    /// Date      : 2022-07-06
    /// Maker     : 이기수
    /// </summary>
    public partial class PP_StockPP : DC00_WinForm.BaseMDIChildForm
    {
        #region < Member Area >
        DataTable dtTemp = new DataTable();
        UltraGridUtil _GridUtil = new UltraGridUtil();   // 그리드 세팅 클래스.
        private string sPlantCode = LoginInfo.PlantCode; // 로그인한 공장 정보.

        #endregion

        public PP_StockPP()
        {
            InitializeComponent();
        }

        private void PP_StockPP_Load(object sender, EventArgs e)
        {
            // Grid 세팅.
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);

            // 자재 발주 부분
            _GridUtil.InitColumnUltraGrid(grid1, "CHK",            "자재출고취소", GridColDataType_emu.CheckBox,     100, HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",      "공장",         GridColDataType_emu.VarChar,      130, HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",       "품목",         GridColDataType_emu.VarChar,      180, HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",       "품목 명",      GridColDataType_emu.VarChar,      130, HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMTYPE",       "품목 구분",    GridColDataType_emu.VarChar,      130, HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO",          "LOTNO",        GridColDataType_emu.VarChar,      180, HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE",         "입고창고",     GridColDataType_emu.VarChar,      130, HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCCODE", "저장위치",     GridColDataType_emu.VarChar,      130, HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STOCKQTY",       "재고 수량",    GridColDataType_emu.Double,       130, HAlign.Right,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "NOWQTY",         "현 재고량",    GridColDataType_emu.Double,       130, HAlign.Right,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE",       "단위",         GridColDataType_emu.VarChar,      100, HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INDATE",         "입고 일자",    GridColDataType_emu.YearMonthDay, 130, HAlign.Left,   true, false);
                          
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER",          "생성자",       GridColDataType_emu.VarChar,      130, HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE",       "생성일자",     GridColDataType_emu.DateTime24,   130, HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR",         "수정자",       GridColDataType_emu.VarChar,      130, HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE",       "수정일자",     GridColDataType_emu.DateTime24,   130, HAlign.Left,   true, false);
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

            // 창고 코드
            dtTemp = Common.StandardCODE("WHCODE");
            UltraGridUtil.SetComboUltraGrid(grid1, "WHCODE", dtTemp);

            // 거래처 코드
            dtTemp = Common.GET_Cust_Code("V"); // V == 협력업체(VENDER), C == 고객사(CUSTOMER)
            //UltraGridUtil.SetComboUltraGrid(grid1, "CUSTCODE", dtTemp);

            // 품목코드
            // FERT: 완제품 / ROH: 원자재 / HALB: 반제품 / OM: 외주가공품
            //dtTemp = Common.Get_ItemCode(new string[] { "ROH" }); // 현 시스템은 원자재만 발주한다고 가정
            //Common.FillComboboxMaster(this.cboItemType_H, dtTemp);

            // 품목 타입
            dtTemp = Common.StandardCODE("ITEMTYPE");
            Common.FillComboboxMaster(cboItemType_H, dtTemp);
            UltraGridUtil.SetComboUltraGrid(grid1, "ITEMTYPE", dtTemp);

            // Pop Up
            BizTextBoxManager txtPopMan = new BizTextBoxManager();
            txtPopMan.PopUpAdd(txtItemCode_H, txtItemName_H, "ITEM_MASTER");
            #endregion

            // 공장 로그인 정보로 자동 세팅
            cboPlantCode_H.Value = sPlantCode;

            dtTemp = Common.StandardCODE("WHCODE");
            UltraGridUtil.SetComboUltraGrid(grid1, "WHCODE", dtTemp);
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
                string sLotNo          = Convert.ToString(txtLotNo_H.Text);                     // LOT NO
                string sItemCode       = Convert.ToString(txtItemCode_H.Text);                  // 품목 코드
                string sItemName       = Convert.ToString(txtItemName_H.Text);                  // 품목 명
                string sItemType       = Convert.ToString(cboItemType_H.Value);                 // 품목 구분

                dtTemp = helper.FillTable("13PP_StockPP_S", CommandType.StoredProcedure
                                          , helper.CreateParameter("@PLANTCODE", sPlantCode_)
                                          , helper.CreateParameter("@LOTNO",     sLotNo)
                                          , helper.CreateParameter("@ITEMCODE",  sItemCode)
                                          , helper.CreateParameter("@ITEMNAME",  sItemName)
                                          , helper.CreateParameter("@ITEMTYPE",  sItemType)
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

        public override void DoSave()
        {
                        base.DoSave();

            // 1. 그리드에서 변경된 내역이 있는 행만 추출.
            DataTable dt = grid1.chkChange();
            if (dt is null) return;


            DBHelper helper = new DBHelper("", true);

            try
            {
                // 변경 내역을 저장하시겠습니까?
                if (ShowDialog("변경 내역을 저장하시겠습니까?") == DialogResult.Cancel) return;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToString(dt.Rows[i]["CHK"]) == "0") continue;
                    if (Convert.ToString(dt.Rows[i]["ITEMTYPE"]) != "ROH")
                    {
                        MessageBox.Show("원자재가 아닌 LOT는 원자재 출고 취소/환입을 할 수 없습니다.");
                    }

                    helper.ExecuteNoneQuery("13PP_StockPP_U", CommandType.StoredProcedure
                        , helper.CreateParameter("PLANTCODE", Convert.ToString(dt.Rows[i]["PLANTCODE"]))
                        , helper.CreateParameter("LOTNO",     Convert.ToString(dt.Rows[i]["LOTNO"]))
                        , helper.CreateParameter("ITEMCODE",  Convert.ToString(dt.Rows[i]["ITEMCODE"]))
                        , helper.CreateParameter("QTY",       Convert.ToString(dt.Rows[i]["STOCKQTY"]))
                        , helper.CreateParameter("UNITCODE",  Convert.ToString(dt.Rows[i]["UNITCODE"]))
                        , helper.CreateParameter("WORKERID",  LoginInfo.UserID)
                        );
                    if (helper.RSCODE != "S") throw new Exception("생산 출고 등록 중 오류가 발생하였습니다.");
                }

                helper.Commit();

                DoInquire();
                ShowDialog("정상적으로 등록했습니다.");
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

        //private void btnLabelPrint_Click(object sender, EventArgs e)
        //{
        //    // 자재 식별표 출력.
        //    // 1. 식별표에 전달할 데이터 등록.
        //    if (grid1.Rows.Count == 0) return;

        //    // 그리드의 컬럼을 그대로 가지고 있는 빈 깡통 데이터행 생성.
        //    DataRow drRow = ((DataTable)grid1.DataSource).NewRow();
        //    drRow["ITEMCODE"] = Convert.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
        //    drRow["ITEMNAME"] = Convert.ToString(grid1.ActiveRow.Cells["ITEMNAME"].Value);
        //    drRow["STOCKQTY"] = Convert.ToString(grid1.ActiveRow.Cells["STOCKQTY"].Value);
        //    drRow["MATLOTNO"] = Convert.ToString(grid1.ActiveRow.Cells["MATLOTNO"].Value);
        //    drRow["UNITCODE"] = Convert.ToString(grid1.ActiveRow.Cells["UNITCODE"].Value);

        //    // 바코드 디자인 객체 선언.
        //    Report_LotBacode LotBarcode = new Report_LotBacode();

        //    // 바코드 디자인을 담을 레포트 북 객체 선언.
        //    Telerik.Reporting.ReportBook reportBook = new Telerik.Reporting.ReportBook();

        //    // 바코드 디자인에 데이터 바인딩.
        //    LotBarcode.DataSource = drRow;

        //    // 데이터가 바인딩된 레포트 디자인 레포트 북에 담기.
        //    reportBook.Reports.Add(LotBarcode);

        //    // 레포트 뷰어에 레포트 북 추가하여 미리보기 창 활성화.
        //    ReportViewer reportViewer = new ReportViewer(reportBook, 1);
        //    reportViewer.ShowDialog();
        //}
    }
}
