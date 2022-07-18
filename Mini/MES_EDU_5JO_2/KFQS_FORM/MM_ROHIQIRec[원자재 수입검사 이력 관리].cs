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



/**************************************************************************
 * From ID   : MM_ROHIQIRec
 * Form Name : 원자재 수입검사 이력 관리
 * date      : 2022-07-13
 * Mkaer     : 문한석
 * 
 * 수정사항  : 
 * *************************************************************************/
namespace KFQS_Form
{
    public partial class MM_ROHIQIRec : DC00_WinForm.BaseMDIChildForm
    {

        #region <  MEMBER AREA  >
        DataTable dtTemp          = new DataTable();
        UltraGridUtil _GridUtil   = new UltraGridUtil();   // 그리드 셋팅 클래스.
        private string sPlantCode = LoginInfo.PlantCode;   // 로그인 한 공장 정보.
        #endregion

        public MM_ROHIQIRec()
        {
            InitializeComponent();
        }

        private void MM_ROHIQIRec_Load(object sender, EventArgs e)
        {
            // Grid 셋팅. 
            _GridUtil.InitializeGrid(this.grid1);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",     "공장",           GridColDataType_emu.VarChar,    100,   HAlign.Center,  true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO",         "LOTNO",          GridColDataType_emu.VarChar,    180,   HAlign.Left,    true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPSEQ",       "검사 횟수",      GridColDataType_emu.VarChar,     80,   HAlign.Right,   true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "REQDATE",       "요청 일시",      GridColDataType_emu.VarChar,     80,   HAlign.Center,  true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "REQUESTER",     "요청자",      GridColDataType_emu.VarChar,     80,   HAlign.Center,  true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",      "품번",           GridColDataType_emu.VarChar,    150,   HAlign.Left,    true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",      "품명",           GridColDataType_emu.VarChar,    180,   HAlign.Left,    true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPQTY",       "검사 수량",      GridColDataType_emu.Double,      80,   HAlign.Right,   true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPECTOR",     "검사원",      GridColDataType_emu.VarChar,     80,   HAlign.Center,   true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPDATETIME",  "검사 일시",      GridColDataType_emu.VarChar,     80,   HAlign.Center,    true,   true);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPRESULT",    "최종 검사 결과", GridColDataType_emu.VarChar,    100,   HAlign.Center,    true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPCODE",      "검사코드",       GridColDataType_emu.VarChar,     80,   HAlign.Center,    true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPNAME",      "검사명칭",       GridColDataType_emu.VarChar,    120,   HAlign.Center,    true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "POSpec",        "관련 규정",      GridColDataType_emu.VarChar,    150,   HAlign.Center,    true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "LSL",           "관리 하한가",    GridColDataType_emu.VarChar,     80,   HAlign.Right,   true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPVALUE",     "검사 값",        GridColDataType_emu.VarChar,     80,   HAlign.Center,    true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "USL",           "관리 상한가",    GridColDataType_emu.VarChar,     80,   HAlign.Right,   true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPRESULTREC", "항목 검사 결과", GridColDataType_emu.VarChar,     80,   HAlign.Center,   true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK",        "비고",           GridColDataType_emu.VarChar,    200,   HAlign.Left,    true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE",      "등록일시",       GridColDataType_emu.VarChar,    130,   HAlign.Left,    false,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER",         "생성자",         GridColDataType_emu.VarChar,    130,   HAlign.Left,    false,  false);

            _GridUtil.SetInitUltraGridBind(grid1);

            this.grid1.DisplayLayout.Override.MergedCellContentArea = MergedCellContentArea.VisibleRect;
            this.grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellStyle = MergedCellStyle.Always;
            this.grid1.DisplayLayout.Bands[0].Columns["LOTNO"].MergedCellStyle = MergedCellStyle.Always;
            this.grid1.DisplayLayout.Bands[0].Columns["INSPSEQ"].MergedCellStyle = MergedCellStyle.Always;
            this.grid1.DisplayLayout.Bands[0].Columns["REQDATE"].MergedCellStyle = MergedCellStyle.Always;
            this.grid1.DisplayLayout.Bands[0].Columns["REQUESTER"].MergedCellStyle = MergedCellStyle.Always;
            this.grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].MergedCellStyle = MergedCellStyle.Always;
            this.grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].MergedCellStyle = MergedCellStyle.Always;
            this.grid1.DisplayLayout.Bands[0].Columns["INSPQTY"].MergedCellStyle = MergedCellStyle.Always;
            this.grid1.DisplayLayout.Bands[0].Columns["INSPECTOR"].MergedCellStyle = MergedCellStyle.Always;
            this.grid1.DisplayLayout.Bands[0].Columns["INSPDATETIME"].MergedCellStyle = MergedCellStyle.Always;
            this.grid1.DisplayLayout.Bands[0].Columns["INSPRESULT"].MergedCellStyle = MergedCellStyle.Always;


            // 콤보박스 셋팅.


            #region < 콤보박스 셋팅 설명 >
            // 공장
            // 공장에 대한 시스템 공통 코드 내역을 DB 에서 가져온다. => dtTemp 데이터 테이블에 담는다. 
            dtTemp = Common.StandardCODE("PLANTCODE");
            // 콤보박스 에 받아온 데이터를 밸류멤버와 디스플레이멤버로 표현한다.  
            Common.FillComboboxMaster(cboPlantCode_H,dtTemp);
            // 그리드의 컬럼에 받아온 데이터를 콤보박스 형식으로 셋팅한다.
            UltraGridUtil.SetComboUltraGrid(grid1, "PLANTCODE", dtTemp);
            

            // 단위
            dtTemp = Common.StandardCODE("UNITCODE");
            UltraGridUtil.SetComboUltraGrid(grid1, "BASEUNIT", dtTemp);

            // 최종 검사 결과
            dtTemp = Common.StandardCODE("INSPRESULT");
            UltraGridUtil.SetComboUltraGrid(grid1, "INSPRESULT", dtTemp);

            // 항목 검사 결과
            dtTemp = Common.StandardCODE("INSPRESULT");
            UltraGridUtil.SetComboUltraGrid(grid1, "INSPRESULTREC", dtTemp);


            // 창고 코드 
            dtTemp = Common.StandardCODE("WHCODE");
            UltraGridUtil.SetComboUltraGrid(grid1, "WHCODE", dtTemp);

            /* 입출 유형 TB_Standard
            10  원자재 입고
            15  원자재 입고 취소
            20  자재 생산 출고
            25  자재 생산 출고 취소
            30  재공 투입
            35  재공 투입 취소
            40  생산실적등록 차감
            45  생산입고
            50  제품창고 입고
            55  제품창고 입고 취소
            57  상차 등록
            60  제품 출고
            65  제품 출고 취소 */

            dtTemp = Common.StandardCODE("INOUTCODE");
            UltraGridUtil.SetComboUltraGrid(grid1, "INOUTCODE", dtTemp);

            // 입출 구분
            dtTemp = Common.StandardCODE("INOUTFLAG");
            UltraGridUtil.SetComboUltraGrid(grid1, "INOUTFLAG", dtTemp);

            // 품목 타입
            // FERT :  완제품,    ROH : 원자재,    HALB : 반제품,   OM : 외주가공품.
            dtTemp = Common.Get_ItemCode(new string[] { "ROH" });
            Common.FillComboboxMaster(cboItemCode_H, dtTemp);




            // 공장 로그인 정보로 자동 셋팅.
            cboPlantCode_H.Value = sPlantCode;
            
        }
        #endregion

      

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
                string sRequeSter  = Convert.ToString(txtRequeSter_H.Text);             // 요청자
                string sStartdate  = string.Format("{0:yyyy-MM-dd}", dtpStart_H.Value); // 입/출고 시작일시
                string sEnddate    = string.Format("{0:yyyy-MM-dd}", dtpEnd_H.Value);   // 입/출고 종료일시

                dtTemp = helper.FillTable("55MM_ROHIQIRec_S", CommandType.StoredProcedure
                                          , helper.CreateParameter("@PLANTCODE",        sPlantCode_)
                                          , helper.CreateParameter("@LOTNO",            sLotNO)
                                          , helper.CreateParameter("@ITEMCODE",         sItemCode)
                                          , helper.CreateParameter("@REQUESTER",        sRequeSter)
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

                grid1.DataSource = dtTemp;


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

        private void grid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            CustomMergedCellEvalutor CM1 = new CustomMergedCellEvalutor("LOTNO", "INSPSEQ");
            e.Layout.Bands[0].Columns["PLANTCODE"].MergedCellEvaluator    = CM1;
            e.Layout.Bands[0].Columns["LOTNO"].MergedCellEvaluator        = CM1;
            e.Layout.Bands[0].Columns["INSPSEQ"].MergedCellEvaluator      = CM1;
            e.Layout.Bands[0].Columns["REQDATE"].MergedCellEvaluator      = CM1;
            e.Layout.Bands[0].Columns["REQUESTER"].MergedCellEvaluator    = CM1;
            e.Layout.Bands[0].Columns["ITEMCODE"].MergedCellEvaluator     = CM1;
            e.Layout.Bands[0].Columns["ITEMNAME"].MergedCellEvaluator     = CM1;
            e.Layout.Bands[0].Columns["INSPQTY"].MergedCellEvaluator      = CM1;
            e.Layout.Bands[0].Columns["INSPECTOR"].MergedCellEvaluator    = CM1;
            e.Layout.Bands[0].Columns["INSPDATETIME"].MergedCellEvaluator = CM1;
            e.Layout.Bands[0].Columns["INSPRESULT"].MergedCellEvaluator   = CM1;
        }
    }
}
