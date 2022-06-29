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

namespace KFQS_Form
{
    /// <summary>
    /// Form ID   : BM_WorkerMaster
    /// Form Name : 작업자 마스터
    /// Date      : 2022-06-29
    /// Maker     : 이기수
    /// </summary>
    public partial class BM_WorkerMaster : DC00_WinForm.BaseMDIChildForm
    {
        #region < Member Area >
        DataTable dtTemp = new DataTable();
        UltraGridUtil _GridUtil = new UltraGridUtil();   // 그리드 세팅 클래스.
        private string sPlantCode = LoginInfo.PlantCode; // 로그인한 공장 정보.

        #endregion

        public BM_WorkerMaster()
        {
            InitializeComponent();
        }

        private void BM_WorkerMaster_Load(object sender, EventArgs e)
        {
            // Grid 세팅.
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",  "공장",     true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKERID",   "작업자ID", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKERNAME", "작업자명", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "BANCODE",    "작업반",   true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "GRPID",      "그룹",     true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "DEPTCODE",   "부서",     true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "PHONENO",    "연락처",   true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "INDATE",     "입사일",   true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "OUTDATE",    "퇴사일",   true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG",    "사용여부", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER",      "등록자",   true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE",   "등록일시", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR",     "수정자",   true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE",   "수정일시", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);

            // 콤보박스 세팅.
            dtTemp = Common.StandardCODE("PLANTCODE");
            Common.FillComboboxMaster(this.cboPlantCode_H, dtTemp, dtTemp.Columns["CODE_ID"].ColumnName, dtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            dtTemp = Common.StandardCODE("BANCODE");
            Common.FillComboboxMaster(this.cboBanCode_H, dtTemp, dtTemp.Columns["CODE_ID"].ColumnName, dtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            dtTemp = Common.StandardCODE("USEFLAG");
            Common.FillComboboxMaster(this.cboUseFlag_H, dtTemp, dtTemp.Columns["CODE_ID"].ColumnName, dtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            cboPlantCode_H.Value = sPlantCode;
        }

        #region < ToolBar Area >
        public override void DoInquire()
        {
            // 툴바의 조회 버튼 클릭.
            base.DoInquire();
            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode_ = Convert.ToString(cboPlantCode_H.Value);  // 공장
                string sBanCode    = Convert.ToString(cboBanCode_H.Value);    // 작업반
                string sWorkerID   = Convert.ToString(txtWorkerID_H.Value);   // 작업자ID
                string sWorkerName = Convert.ToString(txtWorkerName_H.Value); // 작업자명
                string sUseFlag    = Convert.ToString(cboUseFlag_H.Value);    // 사용여부

                dtTemp = helper.FillTable("13BM_WorkerMaster_S", CommandType.StoredProcedure
                                          , helper.CreateParameter("PLANTCODE",   sPlantCode_, DbType.String, ParameterDirection.Input)
                                          , helper.CreateParameter("BANCODE",     sBanCode,    DbType.String, ParameterDirection.Input)
                                          , helper.CreateParameter("WORKERID",    sWorkerID,   DbType.String, ParameterDirection.Input)
                                          , helper.CreateParameter("WORKDERNAME", sWorkerName, DbType.String, ParameterDirection.Input)
                                          , helper.CreateParameter("USEFLAG",     sUseFlag,    DbType.String, ParameterDirection.Input)
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
    }
}
