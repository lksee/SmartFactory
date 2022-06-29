namespace MainForms
{
    partial class M02_ChangePassword
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
            this.labelUserID = new System.Windows.Forms.Label();
            this.labelOldPW = new System.Windows.Forms.Label();
            this.labelNewPW = new System.Windows.Forms.Label();
            this.textBoxUserID = new System.Windows.Forms.TextBox();
            this.textBoxOldPW = new System.Windows.Forms.TextBox();
            this.textBoxNewPW = new System.Windows.Forms.TextBox();
            this.buttonChgPW = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelUserID
            // 
            this.labelUserID.AutoSize = true;
            this.labelUserID.Location = new System.Drawing.Point(12, 34);
            this.labelUserID.Name = "labelUserID";
            this.labelUserID.Size = new System.Drawing.Size(81, 12);
            this.labelUserID.TabIndex = 0;
            this.labelUserID.Text = "사용자 아이디";
            // 
            // labelOldPW
            // 
            this.labelOldPW.AutoSize = true;
            this.labelOldPW.Location = new System.Drawing.Point(12, 63);
            this.labelOldPW.Name = "labelOldPW";
            this.labelOldPW.Size = new System.Drawing.Size(81, 12);
            this.labelOldPW.TabIndex = 1;
            this.labelOldPW.Text = "기존 비밀번호";
            // 
            // labelNewPW
            // 
            this.labelNewPW.AutoSize = true;
            this.labelNewPW.Location = new System.Drawing.Point(12, 90);
            this.labelNewPW.Name = "labelNewPW";
            this.labelNewPW.Size = new System.Drawing.Size(81, 12);
            this.labelNewPW.TabIndex = 2;
            this.labelNewPW.Text = "변경 비밀번호";
            // 
            // textBoxUserID
            // 
            this.textBoxUserID.Location = new System.Drawing.Point(117, 31);
            this.textBoxUserID.Name = "textBoxUserID";
            this.textBoxUserID.Size = new System.Drawing.Size(141, 21);
            this.textBoxUserID.TabIndex = 3;
            // 
            // textBoxOldPW
            // 
            this.textBoxOldPW.Location = new System.Drawing.Point(117, 60);
            this.textBoxOldPW.Name = "textBoxOldPW";
            this.textBoxOldPW.Size = new System.Drawing.Size(141, 21);
            this.textBoxOldPW.TabIndex = 4;
            // 
            // textBoxNewPW
            // 
            this.textBoxNewPW.Location = new System.Drawing.Point(117, 87);
            this.textBoxNewPW.Name = "textBoxNewPW";
            this.textBoxNewPW.Size = new System.Drawing.Size(141, 21);
            this.textBoxNewPW.TabIndex = 5;
            // 
            // buttonChgPW
            // 
            this.buttonChgPW.Location = new System.Drawing.Point(117, 114);
            this.buttonChgPW.Name = "buttonChgPW";
            this.buttonChgPW.Size = new System.Drawing.Size(141, 23);
            this.buttonChgPW.TabIndex = 6;
            this.buttonChgPW.Text = "비밀번호 변경";
            this.buttonChgPW.UseVisualStyleBackColor = true;
            this.buttonChgPW.Click += new System.EventHandler(this.buttonChgPW_Click);
            // 
            // M02_ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 164);
            this.Controls.Add(this.buttonChgPW);
            this.Controls.Add(this.textBoxNewPW);
            this.Controls.Add(this.textBoxOldPW);
            this.Controls.Add(this.textBoxUserID);
            this.Controls.Add(this.labelNewPW);
            this.Controls.Add(this.labelOldPW);
            this.Controls.Add(this.labelUserID);
            this.Name = "M02_ChangePassword";
            this.Text = "비밀번호 변경";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUserID;
        private System.Windows.Forms.Label labelOldPW;
        private System.Windows.Forms.Label labelNewPW;
        private System.Windows.Forms.TextBox textBoxUserID;
        private System.Windows.Forms.TextBox textBoxOldPW;
        private System.Windows.Forms.TextBox textBoxNewPW;
        private System.Windows.Forms.Button buttonChgPW;
    }
}