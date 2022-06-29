using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assambly
{
    public partial class BaseChildForms : Form, IChildCommands
    {
        // BaseChildForms의 목적
        // Interface를 상속받아 필수로 입력해야 하는 메서드의 기능을 모두 정의하고
        // ToolStrip의 기능과 연계하여 시스템 개발에 사용되는 기본 Form을 제공한다.
        public BaseChildForms()
        {
            InitializeComponent();
        }

        // virtual
        // 상속받은 클래스에서 해당 메서드를 재정의할 수 있도록 허용
        // BaseChildForm을 상속받아 개발에 사용될 Form에서 기능을 재정의하여
        // 각 화면마다 목적에 맞는 기능을 적용할 수 있도록 함.
        public virtual void Inquire()
        {
            // 일반적으로 해야되는 기능들을 미리 적용시켜놓고 상속해 줄 수 있다.
            
        }

        public virtual void Delete()
        {
            
        }

        public virtual void DoNew()
        {
            
        }

        public virtual void Save()
        {
            
        }
    }
}
