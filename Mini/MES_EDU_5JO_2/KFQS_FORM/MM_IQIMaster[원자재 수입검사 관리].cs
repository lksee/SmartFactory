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
using Infragistics.Win.UltraWinGrid;


namespace KFQS_Form
{
    /// <summary>
    /// From ID   : MM_IQIMaster
    /// Form Name : 원자재 수입검사 관리
    /// Date      : 2022-07-12
    /// Maker     : 김유진
    /// </summary>
    public partial class MM_IQIMaster : DC00_WinForm.BaseMDIChildForm
    {

        #region <  MEMBER AREA  >
        DataTable dtTemp          = new DataTable();
        UltraGridUtil _GridUtil   = new UltraGridUtil();   // 그리드 셋팅 클래스.
        private string sPlantCode = LoginInfo.PlantCode;   // 로그인 한 공장 정보.
        #endregion

        public MM_IQIMaster()
        {
            InitializeComponent();
        }

        private void MM_IQIMaster_Load(object sender, EventArgs e)
        {
            // Grid 셋팅. 
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
            
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",   "공장 코드",  true,  GridColDataType_emu.VarChar, 130,   100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPCODE",    "검사 코드",  true,  GridColDataType_emu.VarChar, 130,   100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPNAME",    "검사 명칭",  true,  GridColDataType_emu.VarChar, 130,   100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "IQITYPE",     "검사 유형",  true,  GridColDataType_emu.VarChar, 130,   100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "POSpec",      "검사 규격",  true,  GridColDataType_emu.VarChar, 130,   100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "LSL",         "관리하한선", true,  GridColDataType_emu.VarChar, 130,   100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "USL",         "관리상한선", true,  GridColDataType_emu.VarChar, 130,   100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK",      "비고",       true,  GridColDataType_emu.VarChar, 130,   100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG",     "사용여부",   true,  GridColDataType_emu.VarChar, 130,   100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE",    "등록일시",   true,  GridColDataType_emu.VarChar, 130,   100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER",       "등록자",     true,  GridColDataType_emu.VarChar, 130,   100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE",    "수정일시",   true,  GridColDataType_emu.VarChar, 130,   100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR",      "수정자",     true,  GridColDataType_emu.VarChar, 130,   100, Infragistics.Win.HAlign.Left, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);


            // 콤보박스 셋팅.


            #region < 콤보박스 셋팅 설명 >
            // 공장
            // 공장에 대한 시스템 공통 코드 내역을 DB 에서 가져온다. => dtTemp 데이터 테이블에 담는다. 
            dtTemp = Common.StandardCODE("PLANTCODE");
            // 콤보박스 에 받아온 데이터를 밸류멤버와 디스플레이멤버로 표현한다.  
            Common.FillComboboxMaster(this.cboPlantCode_H,dtTemp);
            // 그리드의 컬럼에 받아온 데이터를 콤보박스 형식으로 셋팅한다.
            UltraGridUtil.SetComboUltraGrid(grid1, "PLANTCODE", dtTemp);
            #endregion
            // 사용여부
            dtTemp = Common.StandardCODE("USEFLAG");
            Common.FillComboboxMaster(this.cboUseFlag_H,dtTemp);
            UltraGridUtil.SetComboUltraGrid(grid1, "USEFLAG", dtTemp);
            // 수입검사 구분
            dtTemp = Common.StandardCODE("IQITYPE");
            UltraGridUtil.SetComboUltraGrid(grid1, "IQITYPE", dtTemp);



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
                string sPlantCode_ = Convert.ToString(cboPlantCode_H.Value); // 공장
                string sInspCode = Convert.ToString(txtInspCode_H.Text);   // 거래처 코드
                string sInspName = Convert.ToString(txtInspName_H.Text);   // 거래처 명
                string sUseFlag    = Convert.ToString(cboUseFlag_H.Value);   // 사용여부


                dtTemp = helper.FillTable("55MM_IQIMaster_S", CommandType.StoredProcedure
                                          , helper.CreateParameter("@PLANTCODE", sPlantCode_)
                                          , helper.CreateParameter("@INSPCODE", sInspCode)
                                          , helper.CreateParameter("@INSPNAME", sInspName)
                                          , helper.CreateParameter("@USEFLAG", sUseFlag)

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

                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    if (Convert.ToString(grid1.Rows[i].Cells["IQITYPE"].Value) == "V")
                    {
                        grid1.Rows[i].Cells["LSL"].Value = DBNull.Value;
                        grid1.Rows[i].Cells["USL"].Value = DBNull.Value;
                        grid1.Rows[i].Cells["LSL"].Activation = Activation.Disabled;
                        grid1.Rows[i].Cells["USL"].Activation = Activation.Disabled;
                    }
                    if (Convert.ToString(grid1.Rows[i].Cells["IQITYPE"].Value) == "D")
                    {
                        grid1.Rows[i].Cells["LSL"].Activation = Activation.AllowEdit;
                        grid1.Rows[i].Cells["USL"].Activation = Activation.AllowEdit;
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



        public override void DoNew()
        {
            base.DoNew();

            // 그리드에 새로운 행을 하나 생성한다. 
            this.grid1.InsertRow();

            // 생성된 행에 디폴트 데이터를 입력한다. 
            this.grid1.ActiveRow.Cells["PLANTCODE"].Value = sPlantCode;
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

                // 갱신 이력이 담긴 데이터테이블 에서 한 행씩 뽑아와서 처리한다. 
                foreach (DataRow dr in dt.Rows)
                {
                    // 추출한 행의 상태가
                    switch (dr.RowState)
                    {
                        // 삭제 된 상태 이면.
                        case DataRowState.Deleted:
                            dr.RejectChanges();

                            helper.ExecuteNoneQuery("55MM_IQIMaster_D", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE",Convert.ToString(dr["PLANTCODE"]))
                                                    , helper.CreateParameter("INSPCODE", Convert.ToString(dr["INSPCODE"])));


                            break;
                        // 추가 된 상태 이면.
                        case DataRowState.Added:

                            if (Convert.ToString(dr["INSPCODE"]) == "")
                            {
                                throw new Exception("검사 코드 를 입력하지 않았습니다.");
                            }

                            if (Convert.ToString(grid1.ActiveRow.Cells["IQITYPE"].Value) == "D")
                            {
                                if (dr["LSL"] != DBNull.Value && dr["USL"] != DBNull.Value)
                                {
                                    if (Convert.ToInt32(dr["LSL"]) > Convert.ToInt32(dr["USL"]))
                                    {
                                        throw new Exception("관리 하한선이 관리 상한선보다 큽니다.");
                                    }
                                }
                            }

                            //if ((Convert.ToString(grid1.ActiveRow.Cells["IQITYPE"].Value) == "V") & ((Convert.ToString(dr["LSL"]) != "") || (Convert.ToString(dr["USL"]) != "")))
                            //{
                            //    throw new Exception("육안 검사 시 관리 상하한선 입력이 불가합니다.");
                            //}


                            helper.ExecuteNoneQuery("55MM_IQIMaster_I", CommandType.StoredProcedure
                                                    , helper.CreateParameter("@PLANTCODE", Convert.ToString(dr["PLANTCODE"]))
                                                    , helper.CreateParameter("@INSPCODE", Convert.ToString(dr["INSPCODE"]))
                                                    , helper.CreateParameter("@INSPNAME", Convert.ToString(dr["INSPNAME"]))
                                                    , helper.CreateParameter("@IQITYPE", Convert.ToString(dr["IQITYPE"]))
                                                    , helper.CreateParameter("@POSpec", Convert.ToString(dr["POSpec"]))
                                                    , helper.CreateParameter("@LSL", Convert.ToString((dr["LSL"])))
                                                    , helper.CreateParameter("@USL", Convert.ToString(dr["USL"]))
                                                    , helper.CreateParameter("@REMARK", Convert.ToString(dr["REMARK"]))
                                                    , helper.CreateParameter("@USEFLAG", Convert.ToString(dr["USEFLAG"]))
                                                    , helper.CreateParameter("@MAKEDATE", Convert.ToString(dr["MAKEDATE"]))
                                                    , helper.CreateParameter("@MAKER", LoginInfo.UserID));
                            break;
                        // 수정 된 상태이면
                        case DataRowState.Modified:

                            if (Convert.ToString(dr["INSPCODE"]) == "")
                            {
                                throw new Exception("검사 코드 를 입력하지 않았습니다.");
                            }

                            if (Convert.ToString(grid1.ActiveRow.Cells["IQITYPE"].Value) == "D")
                            {
                                if (dr["LSL"] != DBNull.Value && dr["USL"] != DBNull.Value)
                                {
                                    if (Convert.ToInt32(dr["LSL"]) > Convert.ToInt32(dr["USL"]))
                                    {
                                        throw new Exception("관리 하한선이 관리 상한선보다 큽니다.");
                                    }
                                }
                            }

                            //if ((Convert.ToString(grid1.ActiveRow.Cells["IQITYPE"].Value) == "V") & ((Convert.ToString(dr["LSL"]) != "") || (Convert.ToString(dr["USL"]) != "")))
                            //{
                            //    throw new Exception("육안 검사 시 관리 상하한선 입력이 불가합니다.");
                            //}

                            helper.ExecuteNoneQuery("55MM_IQIMaster_U", CommandType.StoredProcedure
                                                    , helper.CreateParameter("@PLANTCODE", Convert.ToString(dr["PLANTCODE"]))
                                                    , helper.CreateParameter("@INSPCODE", Convert.ToString(dr["INSPCODE"]))
                                                    , helper.CreateParameter("@INSPNAME", Convert.ToString(dr["INSPNAME"]))
                                                    , helper.CreateParameter("@IQITYPE", Convert.ToString(dr["IQITYPE"]))
                                                    , helper.CreateParameter("@POSpec", Convert.ToString(dr["POSpec"]))
                                                    , helper.CreateParameter("@LSL", Convert.ToString(dr["LSL"]))
                                                    , helper.CreateParameter("@USL", Convert.ToString(dr["USL"]))
                                                    , helper.CreateParameter("@REMARK", Convert.ToString(dr["REMARK"]))
                                                    , helper.CreateParameter("@USEFLAG", Convert.ToString(dr["USEFLAG"]))
                                                    , helper.CreateParameter("@EDITDATE", Convert.ToString(dr["EDITDATE"]))
                                                    , helper.CreateParameter("@EDITOR", LoginInfo.UserID));
                            break;
                    }
                    if (helper.RSCODE != "S")
                    {
                        throw new Exception(helper.RSMSG);
                    }
                }

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

        private void grid1_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            grid1.UpdateData();
            if (Convert.ToString(grid1.ActiveRow.Cells["IQITYPE"].Value) == "V")
            {
                grid1.ActiveRow.Cells["LSL"].Value = DBNull.Value;
                grid1.ActiveRow.Cells["USL"].Value = DBNull.Value;
                grid1.ActiveRow.Cells["LSL"].Activation = Activation.Disabled;
                grid1.ActiveRow.Cells["USL"].Activation = Activation.Disabled;
            }
            if (Convert.ToString(grid1.ActiveRow.Cells["IQITYPE"].Value) == "D")
            {
                grid1.ActiveRow.Cells["LSL"].Activation = Activation.AllowEdit;
                grid1.ActiveRow.Cells["USL"].Activation = Activation.AllowEdit;
            }



        }
    }
}
