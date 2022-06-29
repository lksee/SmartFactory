namespace MyFirstCSharp_01
{
    partial class Test_Array_RandomValues
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
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.buttonSumValues = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelQuiz
            // 
            this.labelQuiz.AutoSize = true;
            this.labelQuiz.Location = new System.Drawing.Point(12, 9);
            this.labelQuiz.Name = "labelQuiz";
            this.labelQuiz.Size = new System.Drawing.Size(551, 24);
            this.labelQuiz.TabIndex = 0;
            this.labelQuiz.Text = "랜덤함수로 0부터 20까지의 수를 20개 받아 배열에 담아 오름차순으로 정렬하여 텍스트박스에 표현 후\r\n0부터 20까지 수 중 없는 수를 모두 합" +
    "한 결과를 메시지로 표현하시오.";
            // 
            // textBoxResult
            // 
            this.textBoxResult.Location = new System.Drawing.Point(12, 47);
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(551, 21);
            this.textBoxResult.TabIndex = 1;
            // 
            // buttonSumValues
            // 
            this.buttonSumValues.Location = new System.Drawing.Point(12, 84);
            this.buttonSumValues.Name = "buttonSumValues";
            this.buttonSumValues.Size = new System.Drawing.Size(551, 23);
            this.buttonSumValues.TabIndex = 2;
            this.buttonSumValues.Text = "없는 수 합하기";
            this.buttonSumValues.UseVisualStyleBackColor = true;
            this.buttonSumValues.Click += new System.EventHandler(this.buttonSumValues_Click);
            // 
            // Test_Array_RandomValues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 133);
            this.Controls.Add(this.buttonSumValues);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.labelQuiz);
            this.Name = "Test_Array_RandomValues";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelQuiz;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.Button buttonSumValues;
    }
}