﻿namespace MyFirstCSharp_01
{
    partial class Chapter12_Quiz
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonMakeRandomValue = new System.Windows.Forms.Button();
            this.textBoxRandomValue1 = new System.Windows.Forms.TextBox();
            this.textBoxRandomValue2 = new System.Windows.Forms.TextBox();
            this.textBoxRandomValue3 = new System.Windows.Forms.TextBox();
            this.buttonResult = new System.Windows.Forms.Button();
            this.groupBoxRandom = new System.Windows.Forms.GroupBox();
            this.groupBoxRandom.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(583, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "버튼을 클릭하여 0부터 100까지의 임의의 수를 3번 받아 각각 텍스트박스에 표현하고 결과 버튼을 눌렀을 때\r\n3 수의 합이 100미만일 경우 최" +
    "소값 * 최대값을 메시지로\r\n3 수의 합이 100이상 200미만일 때 최소값 + 최대값을 메시지로\r\n3 수의 합이 200이상일 경우 \"세 수의 " +
    "합이 200이 넘습니다.\"를 메시지로 표현하세요.\r\n";
            // 
            // buttonMakeRandomValue
            // 
            this.buttonMakeRandomValue.Location = new System.Drawing.Point(6, 20);
            this.buttonMakeRandomValue.Name = "buttonMakeRandomValue";
            this.buttonMakeRandomValue.Size = new System.Drawing.Size(75, 23);
            this.buttonMakeRandomValue.TabIndex = 1;
            this.buttonMakeRandomValue.Text = "난수 생성";
            this.buttonMakeRandomValue.UseVisualStyleBackColor = true;
            this.buttonMakeRandomValue.Click += new System.EventHandler(this.buttonMakeRandomValue_Click);
            // 
            // textBoxRandomValue1
            // 
            this.textBoxRandomValue1.Location = new System.Drawing.Point(87, 20);
            this.textBoxRandomValue1.Name = "textBoxRandomValue1";
            this.textBoxRandomValue1.Size = new System.Drawing.Size(100, 21);
            this.textBoxRandomValue1.TabIndex = 2;
            // 
            // textBoxRandomValue2
            // 
            this.textBoxRandomValue2.Location = new System.Drawing.Point(193, 20);
            this.textBoxRandomValue2.Name = "textBoxRandomValue2";
            this.textBoxRandomValue2.Size = new System.Drawing.Size(100, 21);
            this.textBoxRandomValue2.TabIndex = 3;
            // 
            // textBoxRandomValue3
            // 
            this.textBoxRandomValue3.Location = new System.Drawing.Point(299, 20);
            this.textBoxRandomValue3.Name = "textBoxRandomValue3";
            this.textBoxRandomValue3.Size = new System.Drawing.Size(100, 21);
            this.textBoxRandomValue3.TabIndex = 4;
            // 
            // buttonResult
            // 
            this.buttonResult.Location = new System.Drawing.Point(405, 20);
            this.buttonResult.Name = "buttonResult";
            this.buttonResult.Size = new System.Drawing.Size(75, 23);
            this.buttonResult.TabIndex = 5;
            this.buttonResult.Text = "결과";
            this.buttonResult.UseVisualStyleBackColor = true;
            this.buttonResult.Click += new System.EventHandler(this.buttonResult_Click);
            // 
            // groupBoxRandom
            // 
            this.groupBoxRandom.Controls.Add(this.buttonMakeRandomValue);
            this.groupBoxRandom.Controls.Add(this.buttonResult);
            this.groupBoxRandom.Controls.Add(this.textBoxRandomValue1);
            this.groupBoxRandom.Controls.Add(this.textBoxRandomValue3);
            this.groupBoxRandom.Controls.Add(this.textBoxRandomValue2);
            this.groupBoxRandom.Location = new System.Drawing.Point(12, 73);
            this.groupBoxRandom.Name = "groupBoxRandom";
            this.groupBoxRandom.Size = new System.Drawing.Size(489, 62);
            this.groupBoxRandom.TabIndex = 6;
            this.groupBoxRandom.TabStop = false;
            this.groupBoxRandom.Text = "난수 생성하기";
            // 
            // Chapter12_Quiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxRandom);
            this.Controls.Add(this.label1);
            this.Name = "Chapter12_Quiz";
            this.Text = "Chapter12_Quiz";
            this.groupBoxRandom.ResumeLayout(false);
            this.groupBoxRandom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonMakeRandomValue;
        private System.Windows.Forms.TextBox textBoxRandomValue1;
        private System.Windows.Forms.TextBox textBoxRandomValue2;
        private System.Windows.Forms.TextBox textBoxRandomValue3;
        private System.Windows.Forms.Button buttonResult;
        private System.Windows.Forms.GroupBox groupBoxRandom;
    }
}