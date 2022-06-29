using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FormList
{
    public partial class Form03_UserMaster : Assambly.BaseChildForms
    {
        // Overriding
        // 상속받은 클래스가 부모의 클래스의 기능을 재정의하여 사용할 수 있도록 허락하는 기능.
        public Form03_UserMaster()
        {
            InitializeComponent();
        }

        public override void Inquire()
        {
            MessageBox.Show("조회 버튼 클릭");
        }

        public override void DoNew()
        {
            MessageBox.Show("추가 버튼 클릭");
        }

        public override void Delete()
        {
            MessageBox.Show("삭제 버튼 클릭");
        }

        public override void Save()
        {
            MessageBox.Show("저장 버튼 클릭");
        }
    }
}
