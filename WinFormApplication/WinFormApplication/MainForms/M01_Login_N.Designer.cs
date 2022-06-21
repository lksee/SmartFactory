namespace MainForms
{
    partial class M01_Login_N
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
            this.labelID = new System.Windows.Forms.Label();
            this.labelPW = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxPW = new System.Windows.Forms.TextBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonChgPw = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelID.Location = new System.Drawing.Point(99, 102);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(51, 15);
            this.labelID.TabIndex = 0;
            this.labelID.Text = "USER ID";
            // 
            // labelPW
            // 
            this.labelPW.AutoSize = true;
            this.labelPW.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelPW.Location = new System.Drawing.Point(99, 129);
            this.labelPW.Name = "labelPW";
            this.labelPW.Size = new System.Drawing.Size(72, 15);
            this.labelPW.TabIndex = 1;
            this.labelPW.Text = "PASSWORD";
            // 
            // textBoxID
            // 
            this.textBoxID.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBoxID.Location = new System.Drawing.Point(177, 99);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(195, 23);
            this.textBoxID.TabIndex = 2;
            // 
            // textBoxPW
            // 
            this.textBoxPW.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBoxPW.Location = new System.Drawing.Point(177, 126);
            this.textBoxPW.Name = "textBoxPW";
            this.textBoxPW.Size = new System.Drawing.Size(195, 23);
            this.textBoxPW.TabIndex = 3;
            this.textBoxPW.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxPW_KeyDown);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonLogin.Location = new System.Drawing.Point(177, 153);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(75, 39);
            this.buttonLogin.TabIndex = 4;
            this.buttonLogin.Text = "로그인";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // buttonChgPw
            // 
            this.buttonChgPw.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonChgPw.Location = new System.Drawing.Point(297, 153);
            this.buttonChgPw.Name = "buttonChgPw";
            this.buttonChgPw.Size = new System.Drawing.Size(75, 39);
            this.buttonChgPw.TabIndex = 5;
            this.buttonChgPw.Text = "비밀번호 변경";
            this.buttonChgPw.UseVisualStyleBackColor = true;
            this.buttonChgPw.Click += new System.EventHandler(this.buttonChgPw_Click);
            // 
            // M01_Login_N
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 283);
            this.Controls.Add(this.buttonChgPw);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.textBoxPW);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.labelPW);
            this.Controls.Add(this.labelID);
            this.Name = "M01_Login_N";
            this.Text = "LOGIN";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label labelPW;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxPW;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonChgPw;
    }
}

