namespace MyFirstCSharp_01
{
    partial class Chapter15_Exam01
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
            this.buttonSumOddEven = new System.Windows.Forms.Button();
            this.labelQuiz = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonSumOddEven
            // 
            this.buttonSumOddEven.Location = new System.Drawing.Point(14, 63);
            this.buttonSumOddEven.Name = "buttonSumOddEven";
            this.buttonSumOddEven.Size = new System.Drawing.Size(259, 23);
            this.buttonSumOddEven.TabIndex = 3;
            this.buttonSumOddEven.Text = "짝수 홀수 합 구하기";
            this.buttonSumOddEven.UseVisualStyleBackColor = true;
            this.buttonSumOddEven.Click += new System.EventHandler(this.buttonSumOddEven_Click);
            // 
            // labelQuiz
            // 
            this.labelQuiz.AutoSize = true;
            this.labelQuiz.Location = new System.Drawing.Point(12, 9);
            this.labelQuiz.Name = "labelQuiz";
            this.labelQuiz.Size = new System.Drawing.Size(261, 24);
            this.labelQuiz.TabIndex = 2;
            this.labelQuiz.Text = "1부터 100까지의 수 중 짝수의 합과 홀수의 합을\r\n메시지 박스로 표현하세요.";
            // 
            // Chapter15_Exam01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 107);
            this.Controls.Add(this.buttonSumOddEven);
            this.Controls.Add(this.labelQuiz);
            this.Name = "Chapter15_Exam01";
            this.Text = "Chapter15_Exam01";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSumOddEven;
        private System.Windows.Forms.Label labelQuiz;
    }
}