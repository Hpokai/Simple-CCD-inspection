using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using JGP_Splash;//載入JGP_Splash

namespace N58
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Splasher mysplash = new Splasher();//宣告一個Splasher
            mysplash.Show("程式開啟中...");//更改Splasher顯示的字串
            Form_MainPage frm = new Form_MainPage();//宣告一個新的Form的名稱為frm
            frm.ReadToolBlock();//讀取ToolBlock
            mysplash.Close();//初始化後將Splasher關閉
            Application.Run(frm);
        }
    }
}
