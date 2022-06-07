namespace MyFirstCSharp_01
{
    partial class Chapter12_TestCode
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
            this.groupBoxClient = new System.Windows.Forms.GroupBox();
            this.buttonMakePayment = new System.Windows.Forms.Button();
            this.buttonCancelOrder = new System.Windows.Forms.Button();
            this.buttonToTalPayment = new System.Windows.Forms.Button();
            this.labelClientBalance = new System.Windows.Forms.Label();
            this.groupBoxItem3 = new System.Windows.Forms.GroupBox();
            this.buttonOrderItem3 = new System.Windows.Forms.Button();
            this.labelQuantity3 = new System.Windows.Forms.Label();
            this.labelPrice3 = new System.Windows.Forms.Label();
            this.groupBoxItem2 = new System.Windows.Forms.GroupBox();
            this.buttonOrderItem2 = new System.Windows.Forms.Button();
            this.labelQuantity2 = new System.Windows.Forms.Label();
            this.labelPrice2 = new System.Windows.Forms.Label();
            this.groupBoxItem1 = new System.Windows.Forms.GroupBox();
            this.buttonOrderItem1 = new System.Windows.Forms.Button();
            this.labelQuantity1 = new System.Windows.Forms.Label();
            this.labelPrice1 = new System.Windows.Forms.Label();
            this.groupBoxManager = new System.Windows.Forms.GroupBox();
            this.groupBoxMargin = new System.Windows.Forms.GroupBox();
            this.buttonItemRadio3 = new System.Windows.Forms.RadioButton();
            this.buttonItemRadio2 = new System.Windows.Forms.RadioButton();
            this.buttonTotalMargin = new System.Windows.Forms.Button();
            this.buttonItemMargin = new System.Windows.Forms.Button();
            this.buttonItemRadio1 = new System.Windows.Forms.RadioButton();
            this.groupBoxOrder = new System.Windows.Forms.GroupBox();
            this.buttonResetOrder = new System.Windows.Forms.Button();
            this.buttonPlaceAOrder = new System.Windows.Forms.Button();
            this.labelOrderItem3 = new System.Windows.Forms.Label();
            this.labelOrderItem2 = new System.Windows.Forms.Label();
            this.labelOrderItem1 = new System.Windows.Forms.Label();
            this.textBoxOderItem3 = new System.Windows.Forms.TextBox();
            this.textBoxOderItem2 = new System.Windows.Forms.TextBox();
            this.textBoxOderItem1 = new System.Windows.Forms.TextBox();
            this.labelItem3 = new System.Windows.Forms.Label();
            this.labelItem2 = new System.Windows.Forms.Label();
            this.labelItem1 = new System.Windows.Forms.Label();
            this.groupBoxTransactionDetail = new System.Windows.Forms.GroupBox();
            this.textBoxTransactionDetail1 = new System.Windows.Forms.TextBox();
            this.labelManagerBalance = new System.Windows.Forms.Label();
            this.groupBoxClient.SuspendLayout();
            this.groupBoxItem3.SuspendLayout();
            this.groupBoxItem2.SuspendLayout();
            this.groupBoxItem1.SuspendLayout();
            this.groupBoxManager.SuspendLayout();
            this.groupBoxMargin.SuspendLayout();
            this.groupBoxOrder.SuspendLayout();
            this.groupBoxTransactionDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxClient
            // 
            this.groupBoxClient.Controls.Add(this.buttonMakePayment);
            this.groupBoxClient.Controls.Add(this.buttonCancelOrder);
            this.groupBoxClient.Controls.Add(this.buttonToTalPayment);
            this.groupBoxClient.Controls.Add(this.labelClientBalance);
            this.groupBoxClient.Controls.Add(this.groupBoxItem3);
            this.groupBoxClient.Controls.Add(this.groupBoxItem2);
            this.groupBoxClient.Controls.Add(this.groupBoxItem1);
            this.groupBoxClient.Location = new System.Drawing.Point(12, 12);
            this.groupBoxClient.Name = "groupBoxClient";
            this.groupBoxClient.Size = new System.Drawing.Size(776, 193);
            this.groupBoxClient.TabIndex = 0;
            this.groupBoxClient.TabStop = false;
            this.groupBoxClient.Text = "고객 매뉴";
            // 
            // buttonMakePayment
            // 
            this.buttonMakePayment.Location = new System.Drawing.Point(626, 149);
            this.buttonMakePayment.Name = "buttonMakePayment";
            this.buttonMakePayment.Size = new System.Drawing.Size(138, 23);
            this.buttonMakePayment.TabIndex = 8;
            this.buttonMakePayment.Text = "결제하기";
            this.buttonMakePayment.UseVisualStyleBackColor = true;
            this.buttonMakePayment.Click += new System.EventHandler(this.buttonMakePayment_Click);
            // 
            // buttonCancelOrder
            // 
            this.buttonCancelOrder.Location = new System.Drawing.Point(458, 149);
            this.buttonCancelOrder.Name = "buttonCancelOrder";
            this.buttonCancelOrder.Size = new System.Drawing.Size(138, 23);
            this.buttonCancelOrder.TabIndex = 7;
            this.buttonCancelOrder.Text = "주문 취소하기";
            this.buttonCancelOrder.UseVisualStyleBackColor = true;
            this.buttonCancelOrder.Click += new System.EventHandler(this.buttonCancelOrder_Click);
            // 
            // buttonToTalPayment
            // 
            this.buttonToTalPayment.Location = new System.Drawing.Point(290, 149);
            this.buttonToTalPayment.Name = "buttonToTalPayment";
            this.buttonToTalPayment.Size = new System.Drawing.Size(138, 23);
            this.buttonToTalPayment.TabIndex = 6;
            this.buttonToTalPayment.Text = "총 결제금액 보기";
            this.buttonToTalPayment.UseVisualStyleBackColor = true;
            this.buttonToTalPayment.Click += new System.EventHandler(this.buttonToTalPayment_Click);
            // 
            // labelClientBalance
            // 
            this.labelClientBalance.AutoSize = true;
            this.labelClientBalance.Location = new System.Drawing.Point(12, 149);
            this.labelClientBalance.Name = "labelClientBalance";
            this.labelClientBalance.Size = new System.Drawing.Size(110, 12);
            this.labelClientBalance.TabIndex = 6;
            this.labelClientBalance.Text = "labelClientBalance";
            // 
            // groupBoxItem3
            // 
            this.groupBoxItem3.Controls.Add(this.buttonOrderItem3);
            this.groupBoxItem3.Controls.Add(this.labelQuantity3);
            this.groupBoxItem3.Controls.Add(this.labelPrice3);
            this.groupBoxItem3.Location = new System.Drawing.Point(558, 32);
            this.groupBoxItem3.Name = "groupBoxItem3";
            this.groupBoxItem3.Size = new System.Drawing.Size(212, 86);
            this.groupBoxItem3.TabIndex = 3;
            this.groupBoxItem3.TabStop = false;
            this.groupBoxItem3.Text = "groupBoxItem3";
            // 
            // buttonOrderItem3
            // 
            this.buttonOrderItem3.Location = new System.Drawing.Point(8, 57);
            this.buttonOrderItem3.Name = "buttonOrderItem3";
            this.buttonOrderItem3.Size = new System.Drawing.Size(198, 23);
            this.buttonOrderItem3.TabIndex = 7;
            this.buttonOrderItem3.Text = "button3";
            this.buttonOrderItem3.UseVisualStyleBackColor = true;
            this.buttonOrderItem3.Click += new System.EventHandler(this.buttonOrderItem3_Click);
            // 
            // labelQuantity3
            // 
            this.labelQuantity3.AutoSize = true;
            this.labelQuantity3.Location = new System.Drawing.Point(120, 28);
            this.labelQuantity3.Name = "labelQuantity3";
            this.labelQuantity3.Size = new System.Drawing.Size(84, 12);
            this.labelQuantity3.TabIndex = 7;
            this.labelQuantity3.Text = "labelQuantity3";
            // 
            // labelPrice3
            // 
            this.labelPrice3.AutoSize = true;
            this.labelPrice3.Location = new System.Drawing.Point(6, 28);
            this.labelPrice3.Name = "labelPrice3";
            this.labelPrice3.Size = new System.Drawing.Size(67, 12);
            this.labelPrice3.TabIndex = 6;
            this.labelPrice3.Text = "labelPrice3";
            // 
            // groupBoxItem2
            // 
            this.groupBoxItem2.Controls.Add(this.buttonOrderItem2);
            this.groupBoxItem2.Controls.Add(this.labelQuantity2);
            this.groupBoxItem2.Controls.Add(this.labelPrice2);
            this.groupBoxItem2.Location = new System.Drawing.Point(282, 32);
            this.groupBoxItem2.Name = "groupBoxItem2";
            this.groupBoxItem2.Size = new System.Drawing.Size(212, 86);
            this.groupBoxItem2.TabIndex = 2;
            this.groupBoxItem2.TabStop = false;
            this.groupBoxItem2.Text = "groupBoxItem2";
            // 
            // buttonOrderItem2
            // 
            this.buttonOrderItem2.Location = new System.Drawing.Point(8, 57);
            this.buttonOrderItem2.Name = "buttonOrderItem2";
            this.buttonOrderItem2.Size = new System.Drawing.Size(198, 23);
            this.buttonOrderItem2.TabIndex = 6;
            this.buttonOrderItem2.Text = "button2";
            this.buttonOrderItem2.UseVisualStyleBackColor = true;
            this.buttonOrderItem2.Click += new System.EventHandler(this.buttonOrderItem2_Click);
            // 
            // labelQuantity2
            // 
            this.labelQuantity2.AutoSize = true;
            this.labelQuantity2.Location = new System.Drawing.Point(120, 28);
            this.labelQuantity2.Name = "labelQuantity2";
            this.labelQuantity2.Size = new System.Drawing.Size(84, 12);
            this.labelQuantity2.TabIndex = 6;
            this.labelQuantity2.Text = "labelQuantity2";
            // 
            // labelPrice2
            // 
            this.labelPrice2.AutoSize = true;
            this.labelPrice2.Location = new System.Drawing.Point(6, 28);
            this.labelPrice2.Name = "labelPrice2";
            this.labelPrice2.Size = new System.Drawing.Size(67, 12);
            this.labelPrice2.TabIndex = 5;
            this.labelPrice2.Text = "labelPrice2";
            // 
            // groupBoxItem1
            // 
            this.groupBoxItem1.Controls.Add(this.buttonOrderItem1);
            this.groupBoxItem1.Controls.Add(this.labelQuantity1);
            this.groupBoxItem1.Controls.Add(this.labelPrice1);
            this.groupBoxItem1.Location = new System.Drawing.Point(6, 32);
            this.groupBoxItem1.Name = "groupBoxItem1";
            this.groupBoxItem1.Size = new System.Drawing.Size(212, 86);
            this.groupBoxItem1.TabIndex = 1;
            this.groupBoxItem1.TabStop = false;
            this.groupBoxItem1.Text = "groupBoxItem1";
            // 
            // buttonOrderItem1
            // 
            this.buttonOrderItem1.Location = new System.Drawing.Point(6, 57);
            this.buttonOrderItem1.Name = "buttonOrderItem1";
            this.buttonOrderItem1.Size = new System.Drawing.Size(198, 23);
            this.buttonOrderItem1.TabIndex = 4;
            this.buttonOrderItem1.Text = "button1";
            this.buttonOrderItem1.UseVisualStyleBackColor = true;
            this.buttonOrderItem1.Click += new System.EventHandler(this.buttonOrderItem1_Click);
            // 
            // labelQuantity1
            // 
            this.labelQuantity1.AutoSize = true;
            this.labelQuantity1.Location = new System.Drawing.Point(120, 28);
            this.labelQuantity1.Name = "labelQuantity1";
            this.labelQuantity1.Size = new System.Drawing.Size(84, 12);
            this.labelQuantity1.TabIndex = 5;
            this.labelQuantity1.Text = "labelQuantity1";
            // 
            // labelPrice1
            // 
            this.labelPrice1.AutoSize = true;
            this.labelPrice1.Location = new System.Drawing.Point(6, 28);
            this.labelPrice1.Name = "labelPrice1";
            this.labelPrice1.Size = new System.Drawing.Size(67, 12);
            this.labelPrice1.TabIndex = 4;
            this.labelPrice1.Text = "labelPrice1";
            // 
            // groupBoxManager
            // 
            this.groupBoxManager.Controls.Add(this.groupBoxMargin);
            this.groupBoxManager.Controls.Add(this.groupBoxOrder);
            this.groupBoxManager.Controls.Add(this.groupBoxTransactionDetail);
            this.groupBoxManager.Controls.Add(this.labelManagerBalance);
            this.groupBoxManager.Location = new System.Drawing.Point(12, 211);
            this.groupBoxManager.Name = "groupBoxManager";
            this.groupBoxManager.Size = new System.Drawing.Size(776, 227);
            this.groupBoxManager.TabIndex = 1;
            this.groupBoxManager.TabStop = false;
            this.groupBoxManager.Text = "관리자";
            // 
            // groupBoxMargin
            // 
            this.groupBoxMargin.Controls.Add(this.buttonItemRadio3);
            this.groupBoxMargin.Controls.Add(this.buttonItemRadio2);
            this.groupBoxMargin.Controls.Add(this.buttonTotalMargin);
            this.groupBoxMargin.Controls.Add(this.buttonItemMargin);
            this.groupBoxMargin.Controls.Add(this.buttonItemRadio1);
            this.groupBoxMargin.Location = new System.Drawing.Point(337, 121);
            this.groupBoxMargin.Name = "groupBoxMargin";
            this.groupBoxMargin.Size = new System.Drawing.Size(433, 100);
            this.groupBoxMargin.TabIndex = 13;
            this.groupBoxMargin.TabStop = false;
            this.groupBoxMargin.Text = "마진 확인";
            // 
            // buttonItemRadio3
            // 
            this.buttonItemRadio3.AutoSize = true;
            this.buttonItemRadio3.Location = new System.Drawing.Point(306, 20);
            this.buttonItemRadio3.Name = "buttonItemRadio3";
            this.buttonItemRadio3.Size = new System.Drawing.Size(119, 16);
            this.buttonItemRadio3.TabIndex = 14;
            this.buttonItemRadio3.Text = "buttonItemRadio3";
            this.buttonItemRadio3.UseVisualStyleBackColor = true;
            // 
            // buttonItemRadio2
            // 
            this.buttonItemRadio2.AutoSize = true;
            this.buttonItemRadio2.Location = new System.Drawing.Point(157, 20);
            this.buttonItemRadio2.Name = "buttonItemRadio2";
            this.buttonItemRadio2.Size = new System.Drawing.Size(119, 16);
            this.buttonItemRadio2.TabIndex = 13;
            this.buttonItemRadio2.Text = "buttonItemRadio2";
            this.buttonItemRadio2.UseVisualStyleBackColor = true;
            // 
            // buttonTotalMargin
            // 
            this.buttonTotalMargin.Location = new System.Drawing.Point(8, 70);
            this.buttonTotalMargin.Name = "buttonTotalMargin";
            this.buttonTotalMargin.Size = new System.Drawing.Size(419, 24);
            this.buttonTotalMargin.TabIndex = 12;
            this.buttonTotalMargin.Text = "총 마진 보기";
            this.buttonTotalMargin.UseVisualStyleBackColor = true;
            this.buttonTotalMargin.Click += new System.EventHandler(this.buttonTotalMargin_Click);
            // 
            // buttonItemMargin
            // 
            this.buttonItemMargin.Location = new System.Drawing.Point(8, 42);
            this.buttonItemMargin.Name = "buttonItemMargin";
            this.buttonItemMargin.Size = new System.Drawing.Size(419, 24);
            this.buttonItemMargin.TabIndex = 11;
            this.buttonItemMargin.Text = "개별 마진 보기";
            this.buttonItemMargin.UseVisualStyleBackColor = true;
            this.buttonItemMargin.Click += new System.EventHandler(this.buttonItemMargin_Click);
            // 
            // buttonItemRadio1
            // 
            this.buttonItemRadio1.AutoSize = true;
            this.buttonItemRadio1.Checked = true;
            this.buttonItemRadio1.Location = new System.Drawing.Point(8, 20);
            this.buttonItemRadio1.Name = "buttonItemRadio1";
            this.buttonItemRadio1.Size = new System.Drawing.Size(119, 16);
            this.buttonItemRadio1.TabIndex = 11;
            this.buttonItemRadio1.TabStop = true;
            this.buttonItemRadio1.Text = "buttonItemRadio1";
            this.buttonItemRadio1.UseVisualStyleBackColor = true;
            // 
            // groupBoxOrder
            // 
            this.groupBoxOrder.Controls.Add(this.buttonResetOrder);
            this.groupBoxOrder.Controls.Add(this.buttonPlaceAOrder);
            this.groupBoxOrder.Controls.Add(this.labelOrderItem3);
            this.groupBoxOrder.Controls.Add(this.labelOrderItem2);
            this.groupBoxOrder.Controls.Add(this.labelOrderItem1);
            this.groupBoxOrder.Controls.Add(this.textBoxOderItem3);
            this.groupBoxOrder.Controls.Add(this.textBoxOderItem2);
            this.groupBoxOrder.Controls.Add(this.textBoxOderItem1);
            this.groupBoxOrder.Controls.Add(this.labelItem3);
            this.groupBoxOrder.Controls.Add(this.labelItem2);
            this.groupBoxOrder.Controls.Add(this.labelItem1);
            this.groupBoxOrder.Location = new System.Drawing.Point(337, 17);
            this.groupBoxOrder.Name = "groupBoxOrder";
            this.groupBoxOrder.Size = new System.Drawing.Size(433, 100);
            this.groupBoxOrder.TabIndex = 12;
            this.groupBoxOrder.TabStop = false;
            this.groupBoxOrder.Text = "발주";
            // 
            // buttonResetOrder
            // 
            this.buttonResetOrder.Location = new System.Drawing.Point(289, 58);
            this.buttonResetOrder.Name = "buttonResetOrder";
            this.buttonResetOrder.Size = new System.Drawing.Size(138, 36);
            this.buttonResetOrder.TabIndex = 10;
            this.buttonResetOrder.Text = "전체 삭제";
            this.buttonResetOrder.UseVisualStyleBackColor = true;
            this.buttonResetOrder.Click += new System.EventHandler(this.buttonResetOrder_Click);
            // 
            // buttonPlaceAOrder
            // 
            this.buttonPlaceAOrder.Location = new System.Drawing.Point(289, 13);
            this.buttonPlaceAOrder.Name = "buttonPlaceAOrder";
            this.buttonPlaceAOrder.Size = new System.Drawing.Size(138, 36);
            this.buttonPlaceAOrder.TabIndex = 9;
            this.buttonPlaceAOrder.Text = "발주 입고";
            this.buttonPlaceAOrder.UseVisualStyleBackColor = true;
            this.buttonPlaceAOrder.Click += new System.EventHandler(this.buttonPlaceAOrder_Click);
            // 
            // labelOrderItem3
            // 
            this.labelOrderItem3.AutoSize = true;
            this.labelOrderItem3.Location = new System.Drawing.Point(219, 74);
            this.labelOrderItem3.Name = "labelOrderItem3";
            this.labelOrderItem3.Size = new System.Drawing.Size(17, 12);
            this.labelOrderItem3.TabIndex = 8;
            this.labelOrderItem3.Text = "개";
            // 
            // labelOrderItem2
            // 
            this.labelOrderItem2.AutoSize = true;
            this.labelOrderItem2.Location = new System.Drawing.Point(219, 45);
            this.labelOrderItem2.Name = "labelOrderItem2";
            this.labelOrderItem2.Size = new System.Drawing.Size(17, 12);
            this.labelOrderItem2.TabIndex = 7;
            this.labelOrderItem2.Text = "개";
            // 
            // labelOrderItem1
            // 
            this.labelOrderItem1.AutoSize = true;
            this.labelOrderItem1.Location = new System.Drawing.Point(219, 17);
            this.labelOrderItem1.Name = "labelOrderItem1";
            this.labelOrderItem1.Size = new System.Drawing.Size(17, 12);
            this.labelOrderItem1.TabIndex = 6;
            this.labelOrderItem1.Text = "개";
            // 
            // textBoxOderItem3
            // 
            this.textBoxOderItem3.Location = new System.Drawing.Point(113, 70);
            this.textBoxOderItem3.Name = "textBoxOderItem3";
            this.textBoxOderItem3.Size = new System.Drawing.Size(100, 21);
            this.textBoxOderItem3.TabIndex = 5;
            // 
            // textBoxOderItem2
            // 
            this.textBoxOderItem2.Location = new System.Drawing.Point(113, 42);
            this.textBoxOderItem2.Name = "textBoxOderItem2";
            this.textBoxOderItem2.Size = new System.Drawing.Size(100, 21);
            this.textBoxOderItem2.TabIndex = 4;
            // 
            // textBoxOderItem1
            // 
            this.textBoxOderItem1.Location = new System.Drawing.Point(113, 14);
            this.textBoxOderItem1.Name = "textBoxOderItem1";
            this.textBoxOderItem1.Size = new System.Drawing.Size(100, 21);
            this.textBoxOderItem1.TabIndex = 3;
            // 
            // labelItem3
            // 
            this.labelItem3.AutoSize = true;
            this.labelItem3.Location = new System.Drawing.Point(41, 73);
            this.labelItem3.Name = "labelItem3";
            this.labelItem3.Size = new System.Drawing.Size(62, 12);
            this.labelItem3.TabIndex = 2;
            this.labelItem3.Text = "labelItem3";
            // 
            // labelItem2
            // 
            this.labelItem2.AutoSize = true;
            this.labelItem2.Location = new System.Drawing.Point(41, 45);
            this.labelItem2.Name = "labelItem2";
            this.labelItem2.Size = new System.Drawing.Size(62, 12);
            this.labelItem2.TabIndex = 1;
            this.labelItem2.Text = "labelItem2";
            // 
            // labelItem1
            // 
            this.labelItem1.AutoSize = true;
            this.labelItem1.Location = new System.Drawing.Point(41, 17);
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Size = new System.Drawing.Size(62, 12);
            this.labelItem1.TabIndex = 0;
            this.labelItem1.Text = "labelItem1";
            // 
            // groupBoxTransactionDetail
            // 
            this.groupBoxTransactionDetail.Controls.Add(this.textBoxTransactionDetail1);
            this.groupBoxTransactionDetail.Location = new System.Drawing.Point(6, 44);
            this.groupBoxTransactionDetail.Name = "groupBoxTransactionDetail";
            this.groupBoxTransactionDetail.Size = new System.Drawing.Size(325, 177);
            this.groupBoxTransactionDetail.TabIndex = 10;
            this.groupBoxTransactionDetail.TabStop = false;
            this.groupBoxTransactionDetail.Text = "거래 내역";
            // 
            // textBoxTransactionDetail1
            // 
            this.textBoxTransactionDetail1.Location = new System.Drawing.Point(6, 20);
            this.textBoxTransactionDetail1.Multiline = true;
            this.textBoxTransactionDetail1.Name = "textBoxTransactionDetail1";
            this.textBoxTransactionDetail1.Size = new System.Drawing.Size(311, 151);
            this.textBoxTransactionDetail1.TabIndex = 11;
            // 
            // labelManagerBalance
            // 
            this.labelManagerBalance.AutoSize = true;
            this.labelManagerBalance.Location = new System.Drawing.Point(12, 17);
            this.labelManagerBalance.Name = "labelManagerBalance";
            this.labelManagerBalance.Size = new System.Drawing.Size(128, 12);
            this.labelManagerBalance.TabIndex = 9;
            this.labelManagerBalance.Text = "labelManagerBalance";
            // 
            // Chapter12_TestCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxManager);
            this.Controls.Add(this.groupBoxClient);
            this.Name = "Chapter12_TestCode";
            this.Text = "과일 가게 관리 프로그램";
            this.groupBoxClient.ResumeLayout(false);
            this.groupBoxClient.PerformLayout();
            this.groupBoxItem3.ResumeLayout(false);
            this.groupBoxItem3.PerformLayout();
            this.groupBoxItem2.ResumeLayout(false);
            this.groupBoxItem2.PerformLayout();
            this.groupBoxItem1.ResumeLayout(false);
            this.groupBoxItem1.PerformLayout();
            this.groupBoxManager.ResumeLayout(false);
            this.groupBoxManager.PerformLayout();
            this.groupBoxMargin.ResumeLayout(false);
            this.groupBoxMargin.PerformLayout();
            this.groupBoxOrder.ResumeLayout(false);
            this.groupBoxOrder.PerformLayout();
            this.groupBoxTransactionDetail.ResumeLayout(false);
            this.groupBoxTransactionDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxClient;
        private System.Windows.Forms.GroupBox groupBoxItem3;
        private System.Windows.Forms.Label labelQuantity3;
        private System.Windows.Forms.Label labelPrice3;
        private System.Windows.Forms.GroupBox groupBoxItem2;
        private System.Windows.Forms.Label labelQuantity2;
        private System.Windows.Forms.Label labelPrice2;
        private System.Windows.Forms.GroupBox groupBoxItem1;
        private System.Windows.Forms.Label labelQuantity1;
        private System.Windows.Forms.Label labelPrice1;
        private System.Windows.Forms.GroupBox groupBoxManager;
        private System.Windows.Forms.Button buttonOrderItem3;
        private System.Windows.Forms.Button buttonOrderItem2;
        private System.Windows.Forms.Button buttonOrderItem1;
        private System.Windows.Forms.Button buttonMakePayment;
        private System.Windows.Forms.Button buttonCancelOrder;
        private System.Windows.Forms.Button buttonToTalPayment;
        private System.Windows.Forms.Label labelClientBalance;
        private System.Windows.Forms.GroupBox groupBoxMargin;
        private System.Windows.Forms.GroupBox groupBoxOrder;
        private System.Windows.Forms.GroupBox groupBoxTransactionDetail;
        private System.Windows.Forms.TextBox textBoxTransactionDetail1;
        private System.Windows.Forms.Label labelManagerBalance;
        private System.Windows.Forms.RadioButton buttonItemRadio3;
        private System.Windows.Forms.RadioButton buttonItemRadio2;
        private System.Windows.Forms.Button buttonTotalMargin;
        private System.Windows.Forms.Button buttonItemMargin;
        private System.Windows.Forms.RadioButton buttonItemRadio1;
        private System.Windows.Forms.Button buttonResetOrder;
        private System.Windows.Forms.Button buttonPlaceAOrder;
        private System.Windows.Forms.Label labelOrderItem3;
        private System.Windows.Forms.Label labelOrderItem2;
        private System.Windows.Forms.Label labelOrderItem1;
        private System.Windows.Forms.TextBox textBoxOderItem3;
        private System.Windows.Forms.TextBox textBoxOderItem2;
        private System.Windows.Forms.TextBox textBoxOderItem1;
        private System.Windows.Forms.Label labelItem3;
        private System.Windows.Forms.Label labelItem2;
        private System.Windows.Forms.Label labelItem1;
    }
}