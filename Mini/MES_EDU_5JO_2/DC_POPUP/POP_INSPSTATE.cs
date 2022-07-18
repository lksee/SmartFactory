using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win;
using DC00_assm;
using DC00_WinForm;


namespace DC_POPUP
{
    public partial class POP_INSPSTATE :BasePopupForm
    {
        #region <  MEMBER AREA  >
        DataTable dtTemp = new DataTable();
        UltraGridUtil _GridUtil = new UltraGridUtil();      // 그리드 셋팅 클래스.
        private string sPlantCode = LoginInfo.PlantCode;    // 로그인 한 공장 정보.
        private string sLotNo = string.Empty;               // 팝업에서 사용할 작업장 명  변수
        #endregion


        public POP_INSPSTATE()
        {
            InitializeComponent();
        }

        public POP_INSPSTATE(string LotNo)
        {
            InitializeComponent();
            sLotNo = LotNo;
        }

        private void POP_WORKORDER_Load(object sender, EventArgs e)
        {
            // Grid 셋팅. 
            _GridUtil.InitializeGrid(this.grid1);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",   "공장코드", GridColDataType_emu.VarChar, 120, HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",    "품번", GridColDataType_emu.VarChar, 120, HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO",       "LOTNO", GridColDataType_emu.VarChar, 300, HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPSEQ",     "검사시퀀스 ", GridColDataType_emu.VarChar, 120, HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "REQDATE",     "요청일시", GridColDataType_emu.VarChar, 120, HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "REQUESTER",   "요청자 ID", GridColDataType_emu.VarChar, 120, HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPQTY",     "검사수량", GridColDataType_emu.VarChar, 120, HAlign.Center, true, false);
    


            _GridUtil.SetInitUltraGridBind(grid1);


            // 콤보박스 셋팅.
            #region < 콤보박스 셋팅 설명 >
            // 공장
            // 공장에 대한 시스템 공통 코드 내역을 DB 에서 가져온다. => dtTemp 데이터 테이블에 담는다. 
            dtTemp = Common.StandardCODE("PLANTCODE");
            // 콤보박스 에 받아온 데이터를 밸류멤버와 디스플레이멤버로 표현한다.  
            // 그리드의 컬럼에 받아온 데이터를 콤보박스 형식으로 셋팅한다.
            UltraGridUtil.SetComboUltraGrid(grid1, "PLANTCODE", dtTemp);
            #endregion

            Search();
        }

        private void Search()
        {

            // 툴바의 조회 버튼 클릭.
            DBHelper helper = new DBHelper(false);

            try
            {
                dtTemp = helper.FillTable("55_POP_INSPSTATE_S", CommandType.StoredProcedure
                                          , helper.CreateParameter("@PLANTCODE", sPlantCode)
                                          , helper.CreateParameter("@LOTNO", sLotNo)
                                          );

                // 받아온 데이터 그리드 매핑
                if (dtTemp.Rows.Count == 0)
                {
                    // 그리드 초기화.
                    _GridUtil.Grid_Clear(grid1);
                    MessageBox.Show("원자재 수입검사를 요청한적이 없습니다.");
                    return;
                }

                grid1.DataSource = dtTemp;

                grid1.DataBinds(dtTemp);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                helper.Close();
            }
        }
    }
}
