namespace MyFirstCSharp_01
{
    partial class Chapter15_Exam02
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
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.buttonChangeString = new System.Windows.Forms.Button();
            this.labelText = new System.Windows.Forms.Label();
            this.labelQuiz = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxResult
            // 
            this.textBoxResult.Location = new System.Drawing.Point(159, 126);
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(537, 21);
            this.textBoxResult.TabIndex = 7;
            // 
            // buttonChangeString
            // 
            this.buttonChangeString.Location = new System.Drawing.Point(226, 75);
            this.buttonChangeString.Name = "buttonChangeString";
            this.buttonChangeString.Size = new System.Drawing.Size(194, 36);
            this.buttonChangeString.TabIndex = 6;
            this.buttonChangeString.Text = "변경하기";
            this.buttonChangeString.UseVisualStyleBackColor = true;
            this.buttonChangeString.Click += new System.EventHandler(this.buttonChangeString_Click);
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.Location = new System.Drawing.Point(167, 43);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(515, 12);
            this.labelText.TabIndex = 5;
            this.labelText.Text = "동해물과?백두산이 마르고닳?도록 하느님이 보우하사?우리 나라만세?무궁화 삼천리? 화려강산";
            // 
            // labelQuiz
            // 
            this.labelQuiz.AutoSize = true;
            this.labelQuiz.Location = new System.Drawing.Point(12, 9);
            this.labelQuiz.Name = "labelQuiz";
            this.labelQuiz.Size = new System.Drawing.Size(821, 12);
            this.labelQuiz.TabIndex = 4;
            this.labelQuiz.Text = "아래의 문자열 중 첫번째 ? 와 세번째 ? 의 Index를 찾아 각 Index의 합의 Index에 있는 문자열 3자리를 구하고 xxx로 변경 후 " +
    "텍스트박스에 표현하세요.";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(426, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 36);
            this.button1.TabIndex = 8;
            this.button1.Text = "변경하기";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Chapter15_Exam02
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 169);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.buttonChangeString);
            this.Controls.Add(this.labelText);
            this.Controls.Add(this.labelQuiz);
            this.Name = "Chapter15_Exam02";
            this.Text = "Chapter15_Exam02";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.Button buttonChangeString;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.Label labelQuiz;
        private System.Windows.Forms.Button button1;
    }
}