namespace MyFirstCSharp_01
{
    partial class Test_Sum_Odd_Even
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
            this.labelQuiz = new System.Windows.Forms.Label();
            this.buttonSumOddEven = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelQuiz
            // 
            this.labelQuiz.AutoSize = true;
            this.labelQuiz.Location = new System.Drawing.Point(31, 28);
            this.labelQuiz.Name = "labelQuiz";
            this.labelQuiz.Size = new System.Drawing.Size(261, 24);
            this.labelQuiz.TabIndex = 0;
            this.labelQuiz.Text = "1부터 100까지의 수 중 짝수의 합과 홀수의 합을\r\n메시지 박스로 표현하세요.";
            // 
            // buttonSumOddEven
            // 
            this.buttonSumOddEven.Location = new System.Drawing.Point(33, 82);
            this.buttonSumOddEven.Name = "buttonSumOddEven";
            this.buttonSumOddEven.Size = new System.Drawing.Size(259, 23);
            this.buttonSumOddEven.TabIndex = 1;
            this.buttonSumOddEven.Text = "짝수 홀수 합 구하기";
            this.buttonSumOddEven.UseVisualStyleBackColor = true;
            this.buttonSumOddEven.Click += new System.EventHandler(this.buttonSumOddEven_Click);
            // 
            // Test_Sum_Odd_Even
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 136);
            this.Controls.Add(this.buttonSumOddEven);
            this.Controls.Add(this.labelQuiz);
            this.Name = "Test_Sum_Odd_Even";
            this.Text = "짝수, 홀수 합 구하기";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelQuiz;
        private System.Windows.Forms.Button buttonSumOddEven;
    }
}