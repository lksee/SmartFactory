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
    /// Form ID   : BM_CustMaster
    /// Form Name : 거래처 관리 마스터
    /// Date      : 2022-06-30
    /// Maker     : 이기수
    /// </summary>
    public partial class BM_CustMaster : DC00_WinForm.BaseMDIChildForm
    {
        #region < Member Area >
        DataTable dtTemp = new DataTable();
        UltraGridUtil _GridUtil = new UltraGridUtil();   // 그리드 세팅 클래스.
        private string sPlantCode = LoginInfo.PlantCode; // 로그인한 공장 정보.

        #endregion

        public BM_CustMaster()
        {
            InitializeComponent();
        }

        private void BM_CustMaster_Load(object sender, EventArgs e)
        {
            // Grid 세팅.
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",  "공장",        true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE",   "거래처 코드", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTTYPE",   "거래처 타입", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME",   "거래처 명",   true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "ADDRESS",    "주소",        true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "PHONE",      "연락처",      true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG",    "사용여부",    true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER",      "생성자",      true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE",   "생성일자",    true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR",     "수정자",      true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE",   "수정일자",    true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);

            #region < 콤보박스 세팅 설명 >
            // 콤보박스 세팅.
            // 공장 : 공장에 대한 시스템 공통 코드 내역을 DB에서 가여온다. dtTemp 데이터테이블에 담는다.
            dtTemp = Common.StandardCODE("PLANTCODE");
            // 콤보박스에 받아온 데이터를 벨류멤버와 디스플레이멤버로 표현한다.
            Common.FillComboboxMaster(this.cboPlantCode_H, dtTemp, dtTemp.Columns["CODE_ID"].ColumnName, dtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            // 그리드의 컬럼에 받아온 데이터를 콤보박스 형식으로 세팅한다.
            UltraGridUtil.SetComboUltraGrid(grid1, "PLANTCODE", dtTemp, "CODE_ID", "CODE_NAME");

            // 사용여부
            dtTemp = Common.StandardCODE("USEFLAG");
            Common.FillComboboxMaster(this.cboUseFlag_H, dtTemp, dtTemp.Columns["CODE_ID"].ColumnName, dtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(grid1, "USEFLAG", dtTemp, "CODE_ID", "CODE_NAME");

            // 거래처 타입
            dtTemp = Common.StandardCODE("CUSTTYPE");
            Common.FillComboboxMaster(this.cboCustType_H, dtTemp, dtTemp.Columns["CODE_ID"].ColumnName, dtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(grid1, "CUSTTYPE", dtTemp, "CODE_ID", "CODE_NAME");
            #endregion


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
                string sCustCode   = Convert.ToString(txtCustCode_H.Value);   // 거래처 코드
                string sCustType   = Convert.ToString(cboCustType_H.Value);   // 거래처 구분
                string sCustName   = Convert.ToString(txtCustName_H.Value);   // 거래처 명
                string sUseFlag    = Convert.ToString(cboUseFlag_H.Value);    // 사용여부

                dtTemp = helper.FillTable("13BM_CustMaster_S", CommandType.StoredProcedure
                                          , helper.CreateParameter("PLANTCODE",   sPlantCode_)
                                          , helper.CreateParameter("CUSTCODE",    sCustCode)
                                          , helper.CreateParameter("CUSTTYPE",    sCustType)
                                          , helper.CreateParameter("CUSTNAME",    sCustName)
                                          , helper.CreateParameter("USEFLAG",     sUseFlag)
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
            this.grid1.ActiveRow.Cells["CUSTTYPE"].Value = "C";
            this.grid1.ActiveRow.Cells["USEFLAG"].Value   = "Y";
        }

        public override void DoDelete()
        {
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
                            if (Convert.ToString(dr["CUSTCODE"]) == "") return;
                            helper.ExecuteNoneQuery("13BM_CustMaster_I", CommandType.StoredProcedure
                                , helper.CreateParameter("PLANTCODE",  Convert.ToString(dr["PLANTCODE"]))
                                , helper.CreateParameter("CUSTCODE",   Convert.ToString(dr["CUSTCODE"]))
                                , helper.CreateParameter("CUSTTYPE",   Convert.ToString(dr["CUSTTYPE"]))
                                , helper.CreateParameter("CUSTNAME",   Convert.ToString(dr["CUSTNAME"]))
                                , helper.CreateParameter("ADDRESS",    Convert.ToString(dr["ADDRESS"]))
                                , helper.CreateParameter("PHONE",      Convert.ToString(dr["PHONE"]))
                                , helper.CreateParameter("USEFLAG",    Convert.ToString(dr["USEFLAG"]))
                                , helper.CreateParameter("MAKER",      LoginInfo.UserID)
                               );
                            break;
                        // 삭제된 상태이면
                        case DataRowState.Deleted:
                            dr.RejectChanges();

                            helper.ExecuteNoneQuery("13BM_CustMaster_D", CommandType.StoredProcedure, helper.CreateParameter("PLANTCODE", Convert.ToString(dr["PLANTCODE"]))
                                                                                                    , helper.CreateParameter("CUSTCODE",  Convert.ToString(dr["CUSTCODE"])));
                            break;
                        // 수정된 상태이면
                        case DataRowState.Modified:
                            if (Convert.ToString(dr["CUSTCODE"]) == "") return;
                            helper.ExecuteNoneQuery("13BM_CustMaster_U", CommandType.StoredProcedure
                                , helper.CreateParameter("PLANTCODE", Convert.ToString(dr["PLANTCODE"]))
                                , helper.CreateParameter("CUSTCODE",  Convert.ToString(dr["CUSTCODE"]))
                                , helper.CreateParameter("CUSTTYPE",  Convert.ToString(dr["CUSTTYPE"]))
                                , helper.CreateParameter("CUSTNAME",  Convert.ToString(dr["CUSTNAME"]))
                                , helper.CreateParameter("ADDRESS",   Convert.ToString(dr["ADDRESS"]))
                                , helper.CreateParameter("PHONE",     Convert.ToString(dr["PHONE"]))
                                , helper.CreateParameter("USEFLAG",   Convert.ToString(dr["USEFLAG"]))
                                , helper.CreateParameter("EDITOR",    LoginInfo.UserID)
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
