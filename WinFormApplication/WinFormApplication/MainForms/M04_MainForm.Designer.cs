namespace MainForms
{
    partial class M04_MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.M_Test = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonInsert = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonExit = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelFormName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelEmptySpace = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelNowDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Form01_MDI_TEST = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.M_Test});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1038, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "Test Menu";
            // 
            // M_Test
            // 
            this.M_Test.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Form01_MDI_TEST});
            this.M_Test.Name = "M_Test";
            this.M_Test.Size = new System.Drawing.Size(75, 20);
            this.M_Test.Text = "Test Menu";
            this.M_Test.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.M_Test_DropDownItemClicked);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSearch,
            this.toolStripButtonInsert,
            this.toolStripButtonDelete,
            this.toolStripButtonSave,
            this.toolStripSeparator1,
            this.toolStripButtonClose,
            this.toolStripButtonExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1038, 100);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonSearch
            // 
            this.toolStripButtonSearch.Image = global::MainForms.Properties.Resources.BtnSearch;
            this.toolStripButtonSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSearch.Name = "toolStripButtonSearch";
            this.toolStripButtonSearch.Size = new System.Drawing.Size(54, 97);
            this.toolStripButtonSearch.Text = "조회";
            this.toolStripButtonSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripButtonSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButtonInsert
            // 
            this.toolStripButtonInsert.Image = global::MainForms.Properties.Resources.BtnAdd;
            this.toolStripButtonInsert.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonInsert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonInsert.Name = "toolStripButtonInsert";
            this.toolStripButtonInsert.Size = new System.Drawing.Size(54, 97);
            this.toolStripButtonInsert.Text = "추가";
            this.toolStripButtonInsert.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripButtonInsert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButtonDelete
            // 
            this.toolStripButtonDelete.Image = global::MainForms.Properties.Resources.BtnDelete;
            this.toolStripButtonDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(54, 97);
            this.toolStripButtonDelete.Text = "삭제";
            this.toolStripButtonDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripButtonDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.Image = global::MainForms.Properties.Resources.BtnSaveB;
            this.toolStripButtonSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(54, 97);
            this.toolStripButtonSave.Text = "저장";
            this.toolStripButtonSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripButtonSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 100);
            // 
            // toolStripButtonClose
            // 
            this.toolStripButtonClose.Image = global::MainForms.Properties.Resources.BtnClose;
            this.toolStripButtonClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClose.Name = "toolStripButtonClose";
            this.toolStripButtonClose.Size = new System.Drawing.Size(54, 97);
            this.toolStripButtonClose.Text = "닫기";
            this.toolStripButtonClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripButtonClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButtonExit
            // 
            this.toolStripButtonExit.Image = global::MainForms.Properties.Resources.BtcExit;
            this.toolStripButtonExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExit.Name = "toolStripButtonExit";
            this.toolStripButtonExit.Size = new System.Drawing.Size(54, 97);
            this.toolStripButtonExit.Text = "종료";
            this.toolStripButtonExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripButtonExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonExit.Click += new System.EventHandler(this.toolStripButtonExit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelFormName,
            this.toolStripStatusLabelEmptySpace,
            this.toolStripStatusLabelUserName,
            this.toolStripStatusLabelNowDate});
            this.statusStrip1.Location = new System.Drawing.Point(0, 547);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1038, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelFormName
            // 
            this.toolStripStatusLabelFormName.AutoSize = false;
            this.toolStripStatusLabelFormName.Name = "toolStripStatusLabelFormName";
            this.toolStripStatusLabelFormName.Size = new System.Drawing.Size(200, 17);
            this.toolStripStatusLabelFormName.Text = "Form Name";
            // 
            // toolStripStatusLabelEmptySpace
            // 
            this.toolStripStatusLabelEmptySpace.AutoSize = false;
            this.toolStripStatusLabelEmptySpace.Name = "toolStripStatusLabelEmptySpace";
            this.toolStripStatusLabelEmptySpace.Size = new System.Drawing.Size(473, 17);
            this.toolStripStatusLabelEmptySpace.Spring = true;
            // 
            // toolStripStatusLabelUserName
            // 
            this.toolStripStatusLabelUserName.AutoSize = false;
            this.toolStripStatusLabelUserName.Name = "toolStripStatusLabelUserName";
            this.toolStripStatusLabelUserName.Size = new System.Drawing.Size(150, 17);
            this.toolStripStatusLabelUserName.Text = "User Name";
            // 
            // toolStripStatusLabelNowDate
            // 
            this.toolStripStatusLabelNowDate.AutoSize = false;
            this.toolStripStatusLabelNowDate.Name = "toolStripStatusLabelNowDate";
            this.toolStripStatusLabelNowDate.Size = new System.Drawing.Size(200, 17);
            this.toolStripStatusLabelNowDate.Text = "Now Date";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // Form01_MDI_TEST
            // 
            this.Form01_MDI_TEST.Name = "Form01_MDI_TEST";
            this.Form01_MDI_TEST.Size = new System.Drawing.Size(180, 22);
            this.Form01_MDI_TEST.Text = "MDI 테스트 1";
            // 
            // M04_MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 569);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "M04_MainForm";
            this.Text = "EZ_Dev 1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.M04_MainForm_FormClosed);
            this.Load += new System.EventHandler(this.M04_MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSearch;
        private System.Windows.Forms.ToolStripButton toolStripButtonInsert;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.ToolStripButton toolStripButtonExit;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelFormName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelEmptySpace;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelUserName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelNowDate;
        private System.Windows.Forms.ToolStripMenuItem M_Test;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem Form01_MDI_TEST;
    }
}