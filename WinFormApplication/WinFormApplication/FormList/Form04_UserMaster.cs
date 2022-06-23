using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FormList
{
    public partial class Form04_UserMaster : Assambly.BaseChildForms
    {
        public Form04_UserMaster()
        {
            InitializeComponent();
        }

        public override void Inquire()
        {
            MessageBox.Show("2 조회 버튼 클릭");
        }

        public override void DoNew()
        {
            MessageBox.Show("2 추가 버튼 클릭");
        }

        public override void Delete()
        {
            MessageBox.Show("2 삭제 버튼 클릭");
        }

        public override void Save()
        {
            MessageBox.Show("2 저장 버튼 클릭");
        }
    }
}
