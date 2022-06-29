namespace FormList
{
    partial class Form05_Standard
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelMajorCode = new System.Windows.Forms.Label();
            this.labelMinorCode = new System.Windows.Forms.Label();
            this.textBoxMajorCode = new System.Windows.Forms.TextBox();
            this.textBoxMinorCode = new System.Windows.Forms.TextBox();
            this.dataGridViewStandard = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStandard)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxMinorCode);
            this.groupBox1.Controls.Add(this.textBoxMajorCode);
            this.groupBox1.Controls.Add(this.labelMinorCode);
            this.groupBox1.Controls.Add(this.labelMajorCode);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewStandard);
            // 
            // labelMajorCode
            // 
            this.labelMajorCode.AutoSize = true;
            this.labelMajorCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelMajorCode.Location = new System.Drawing.Point(78, 42);
            this.labelMajorCode.Name = "labelMajorCode";
            this.labelMajorCode.Size = new System.Drawing.Size(66, 25);
            this.labelMajorCode.TabIndex = 0;
            this.labelMajorCode.Text = "주코드";
            // 
            // labelMinorCode
            // 
            this.labelMinorCode.AutoSize = true;
            this.labelMinorCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelMinorCode.Location = new System.Drawing.Point(372, 42);
            this.labelMinorCode.Name = "labelMinorCode";
            this.labelMinorCode.Size = new System.Drawing.Size(66, 25);
            this.labelMinorCode.TabIndex = 1;
            this.labelMinorCode.Text = "부코드";
            // 
            // textBoxMajorCode
            // 
            this.textBoxMajorCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBoxMajorCode.Location = new System.Drawing.Point(146, 39);
            this.textBoxMajorCode.Name = "textBoxMajorCode";
            this.textBoxMajorCode.Size = new System.Drawing.Size(200, 31);
            this.textBoxMajorCode.TabIndex = 2;
            // 
            // textBoxMinorCode
            // 
            this.textBoxMinorCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBoxMinorCode.Location = new System.Drawing.Point(440, 39);
            this.textBoxMinorCode.Name = "textBoxMinorCode";
            this.textBoxMinorCode.Size = new System.Drawing.Size(200, 31);
            this.textBoxMinorCode.TabIndex = 3;
            // 
            // dataGridViewStandard
            // 
            this.dataGridViewStandard.AllowUserToAddRows = false;
            this.dataGridViewStandard.AllowUserToDeleteRows = false;
            this.dataGridViewStandard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStandard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewStandard.Location = new System.Drawing.Point(3, 24);
            this.dataGridViewStandard.Name = "dataGridViewStandard";
            this.dataGridViewStandard.RowHeadersWidth = 62;
            this.dataGridViewStandard.RowTemplate.Height = 30;
            this.dataGridViewStandard.Size = new System.Drawing.Size(1914, 953);
            this.dataGridViewStandard.TabIndex = 0;
            // 
            // Form05_Standard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "Form05_Standard";
            this.Text = "공통코드 마스터";
            this.Load += new System.EventHandler(this.Form05_Standard_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStandard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelMajorCode;
        private System.Windows.Forms.Label labelMinorCode;
        private System.Windows.Forms.TextBox textBoxMinorCode;
        private System.Windows.Forms.TextBox textBoxMajorCode;
        private System.Windows.Forms.DataGridView dataGridViewStandard;
    }
}
