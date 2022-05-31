using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstCSharp_01
{
    internal static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        { // 프로그램 실행 범위 시작
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new Form1());
            // Application.Run(new Chapter03_Class());
            // Application.Run(new Chapter03_Class_Test());
            //Application.Run(new Chapter03_Static_Const());
            // Application.Run(new Chapter04_DataChange());
            //Application.Run(new Chapter05_StringChange());
            //Application.Run(new Chapter05_StringFind());
            //Application.Run(new Chapter05_StringSplit());
            //Application.Run(new Chapter05_practice());
            //Application.Run(new Chapter06_Null());
            //Application.Run(new Chapter07_Operator());
            //Application.Run(new Chapter08_Method_Return());
            //Application.Run(new Chapter09_If_BranchingStatement());
            //Application.Run(new Chapter09_If_BranchingStatement_Test());
            //Application.Run(new Chapter09_Switch_BranchingStatement());
            //Application.Run(new Chapter09_Switch_BranchingStatement_Test());
            Application.Run(new Chapter10_Loop01_For());
        } // 프로그램 실행 범위 끝
    }
}
