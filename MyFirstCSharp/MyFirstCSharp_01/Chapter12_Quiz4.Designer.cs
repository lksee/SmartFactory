namespace MyFirstCSharp_01
{
    partial class Chapter12_Quiz4
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
            this.labelValue = new System.Windows.Forms.Label();
            this.buttonSortDesc = new System.Windows.Forms.Button();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelQuiz
            // 
            this.labelQuiz.AutoSize = true;
            this.labelQuiz.Location = new System.Drawing.Point(12, 9);
            this.labelQuiz.Name = "labelQuiz";
            this.labelQuiz.Size = new System.Drawing.Size(341, 36);
            this.labelQuiz.TabIndex = 0;
            this.labelQuiz.Text = "아래의 수를 내림차순으로 정렬하여 텍스트박스에 표현하세요.\r\n\r\n           * Array.Sort 기능 사용하지 말 것.";
            // 
            // labelValue
            // 
            this.labelValue.AutoSize = true;
            this.labelValue.Location = new System.Drawing.Point(55, 63);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(193, 12);
            this.labelValue.TabIndex = 1;
            this.labelValue.Text = "1, 11, 6, 20, 11, 8, 12, 6, 16, 13, 22";
            // 
            // buttonSortDesc
            // 
            this.buttonSortDesc.Location = new System.Drawing.Point(102, 122);
            this.buttonSortDesc.Name = "buttonSortDesc";
            this.buttonSortDesc.Size = new System.Drawing.Size(131, 35);
            this.buttonSortDesc.TabIndex = 2;
            this.buttonSortDesc.Text = "내림차순 정렬";
            this.buttonSortDesc.UseVisualStyleBackColor = true;
            this.buttonSortDesc.Click += new System.EventHandler(this.buttonSortDesc_Click);
            // 
            // textBoxResult
            // 
            this.textBoxResult.Location = new System.Drawing.Point(14, 95);
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(293, 21);
            this.textBoxResult.TabIndex = 3;
            // 
            // Chapter12_Quiz4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.buttonSortDesc);
            this.Controls.Add(this.labelValue);
            this.Controls.Add(this.labelQuiz);
            this.Name = "Chapter12_Quiz4";
            this.Text = "Chapter12_Quiz4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelQuiz;
        private System.Windows.Forms.Label labelValue;
        private System.Windows.Forms.Button buttonSortDesc;
        private System.Windows.Forms.TextBox textBoxResult;
    }
}