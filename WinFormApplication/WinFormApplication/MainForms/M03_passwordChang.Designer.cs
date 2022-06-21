namespace MainForms
{
    partial class M03_passwordChang
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
            this.buttonChgPW = new System.Windows.Forms.Button();
            this.textBoxNewPW = new System.Windows.Forms.TextBox();
            this.textBoxOldPW = new System.Windows.Forms.TextBox();
            this.textBoxUserID = new System.Windows.Forms.TextBox();
            this.labelNewPW = new System.Windows.Forms.Label();
            this.labelOldPW = new System.Windows.Forms.Label();
            this.labelUserID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonChgPW
            // 
            this.buttonChgPW.Location = new System.Drawing.Point(182, 148);
            this.buttonChgPW.Name = "buttonChgPW";
            this.buttonChgPW.Size = new System.Drawing.Size(141, 23);
            this.buttonChgPW.TabIndex = 13;
            this.buttonChgPW.Text = "비밀번호 변경";
            this.buttonChgPW.UseVisualStyleBackColor = true;
            this.buttonChgPW.Click += new System.EventHandler(this.buttonChgPW_Click);
            // 
            // textBoxNewPW
            // 
            this.textBoxNewPW.Location = new System.Drawing.Point(182, 121);
            this.textBoxNewPW.Name = "textBoxNewPW";
            this.textBoxNewPW.Size = new System.Drawing.Size(141, 21);
            this.textBoxNewPW.TabIndex = 12;
            this.textBoxNewPW.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxNewPW_KeyDown);
            // 
            // textBoxOldPW
            // 
            this.textBoxOldPW.Location = new System.Drawing.Point(182, 94);
            this.textBoxOldPW.Name = "textBoxOldPW";
            this.textBoxOldPW.Size = new System.Drawing.Size(141, 21);
            this.textBoxOldPW.TabIndex = 11;
            // 
            // textBoxUserID
            // 
            this.textBoxUserID.Location = new System.Drawing.Point(182, 65);
            this.textBoxUserID.Name = "textBoxUserID";
            this.textBoxUserID.Size = new System.Drawing.Size(141, 21);
            this.textBoxUserID.TabIndex = 10;
            // 
            // labelNewPW
            // 
            this.labelNewPW.AutoSize = true;
            this.labelNewPW.Location = new System.Drawing.Point(77, 124);
            this.labelNewPW.Name = "labelNewPW";
            this.labelNewPW.Size = new System.Drawing.Size(81, 12);
            this.labelNewPW.TabIndex = 9;
            this.labelNewPW.Text = "변경 비밀번호";
            // 
            // labelOldPW
            // 
            this.labelOldPW.AutoSize = true;
            this.labelOldPW.Location = new System.Drawing.Point(77, 97);
            this.labelOldPW.Name = "labelOldPW";
            this.labelOldPW.Size = new System.Drawing.Size(81, 12);
            this.labelOldPW.TabIndex = 8;
            this.labelOldPW.Text = "기존 비밀번호";
            // 
            // labelUserID
            // 
            this.labelUserID.AutoSize = true;
            this.labelUserID.Location = new System.Drawing.Point(77, 68);
            this.labelUserID.Name = "labelUserID";
            this.labelUserID.Size = new System.Drawing.Size(81, 12);
            this.labelUserID.TabIndex = 7;
            this.labelUserID.Text = "사용자 아이디";
            // 
            // M03_passwordChang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 236);
            this.Controls.Add(this.buttonChgPW);
            this.Controls.Add(this.textBoxNewPW);
            this.Controls.Add(this.textBoxOldPW);
            this.Controls.Add(this.textBoxUserID);
            this.Controls.Add(this.labelNewPW);
            this.Controls.Add(this.labelOldPW);
            this.Controls.Add(this.labelUserID);
            this.Name = "M03_passwordChang";
            this.Text = "비밀번호 변경";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonChgPW;
        private System.Windows.Forms.TextBox textBoxNewPW;
        private System.Windows.Forms.TextBox textBoxOldPW;
        private System.Windows.Forms.TextBox textBoxUserID;
        private System.Windows.Forms.Label labelNewPW;
        private System.Windows.Forms.Label labelOldPW;
        private System.Windows.Forms.Label labelUserID;
    }
}