namespace MyFirstCSharp_01
{
    partial class Chapter12_Quiz3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chapter12_Quiz3));
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCalcFee = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxARideFee = new System.Windows.Forms.TextBox();
            this.textBoxRideAmount = new System.Windows.Forms.TextBox();
            this.textBoxRideNumber = new System.Windows.Forms.TextBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(645, 96);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // buttonCalcFee
            // 
            this.buttonCalcFee.Location = new System.Drawing.Point(31, 163);
            this.buttonCalcFee.Name = "buttonCalcFee";
            this.buttonCalcFee.Size = new System.Drawing.Size(432, 29);
            this.buttonCalcFee.TabIndex = 1;
            this.buttonCalcFee.Text = "부족 금액 계산";
            this.buttonCalcFee.UseVisualStyleBackColor = true;
            this.buttonCalcFee.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = " 놀이기구 이용료";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(185, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "놀이기구 이용 횟수";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(341, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "가진 금액";
            // 
            // textBoxARideFee
            // 
            this.textBoxARideFee.Location = new System.Drawing.Point(31, 136);
            this.textBoxARideFee.Name = "textBoxARideFee";
            this.textBoxARideFee.ReadOnly = true;
            this.textBoxARideFee.Size = new System.Drawing.Size(120, 21);
            this.textBoxARideFee.TabIndex = 5;
            this.textBoxARideFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxRideAmount
            // 
            this.textBoxRideAmount.Location = new System.Drawing.Point(343, 136);
            this.textBoxRideAmount.Name = "textBoxRideAmount";
            this.textBoxRideAmount.ReadOnly = true;
            this.textBoxRideAmount.Size = new System.Drawing.Size(120, 21);
            this.textBoxRideAmount.TabIndex = 6;
            this.textBoxRideAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxRideNumber
            // 
            this.textBoxRideNumber.Location = new System.Drawing.Point(187, 136);
            this.textBoxRideNumber.Name = "textBoxRideNumber";
            this.textBoxRideNumber.ReadOnly = true;
            this.textBoxRideNumber.Size = new System.Drawing.Size(120, 21);
            this.textBoxRideNumber.TabIndex = 7;
            this.textBoxRideNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // buttonReset
            // 
            this.buttonReset.BackColor = System.Drawing.Color.Yellow;
            this.buttonReset.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.buttonReset.Location = new System.Drawing.Point(483, 163);
            this.buttonReset.Margin = new System.Windows.Forms.Padding(0);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(174, 29);
            this.buttonReset.TabIndex = 8;
            this.buttonReset.Text = "☢Reset☢";
            this.buttonReset.UseVisualStyleBackColor = false;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // Chapter12_Quiz3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 198);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.textBoxRideNumber);
            this.Controls.Add(this.textBoxRideAmount);
            this.Controls.Add(this.textBoxARideFee);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCalcFee);
            this.Controls.Add(this.label1);
            this.Name = "Chapter12_Quiz3";
            this.Text = "Chapter12_Quiz3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCalcFee;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxARideFee;
        private System.Windows.Forms.TextBox textBoxRideAmount;
        private System.Windows.Forms.TextBox textBoxRideNumber;
        private System.Windows.Forms.Button buttonReset;
    }
}