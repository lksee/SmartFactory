namespace MyFirstCSharp_01
{
    partial class Chapter12_Quiz2
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
            this.labelNotice = new System.Windows.Forms.Label();
            this.labelText = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelNotice
            // 
            this.labelNotice.AutoSize = true;
            this.labelNotice.Location = new System.Drawing.Point(12, 9);
            this.labelNotice.Name = "labelNotice";
            this.labelNotice.Size = new System.Drawing.Size(665, 24);
            this.labelNotice.TabIndex = 0;
            this.labelNotice.Text = "다음 문자열에 포함된 수를 정수 배열로 만들고 낮은 수부터 중복되는 첫 번째 값과 세 번째 값을 메시지박스로 나타내세요.\r\n      * 라벨에 " +
    "입력된 문자열을 받아 정수 배열로 만드는 로직을 작성할 것";
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.Location = new System.Drawing.Point(238, 53);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(241, 12);
            this.labelText.TabIndex = 1;
            this.labelText.Text = "{ 1, 2, 13, 8, 15, 17, 23, 8, 15, 19, 3, 8, 13 }";
            this.labelText.Click += new System.EventHandler(this.labelText_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(269, 84);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "중복 값 찾기";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Chapter12_Quiz2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelText);
            this.Controls.Add(this.labelNotice);
            this.Name = "Chapter12_Quiz2";
            this.Text = "Chapter12_Quiz2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNotice;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.Button button1;
    }
}