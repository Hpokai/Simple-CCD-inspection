using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MySplashTestC//設定名稱
{
    public partial class frmSplash : Form
    {
        private int count = 0;//宣告整數變數
        private String strStatus;//宣告字串
        delegate void delStatus();//宣告委派

        public frmSplash()
        {
            InitializeComponent();//初始化
        }

        public string Status
        {
            get 
            { 
                return strStatus;//回傳strStatus的值
            }
            set
            {
                strStatus = value;//指派值給strStatus
                ChangeText();//呼叫函式
            }
        }

        private void ChangeText()
        {
            if (this.InvokeRequired)
            {
                delStatus ma = new delStatus(ChangeText);//實作委派，指向執行緒中被呼叫的ChangText
                this.Invoke(ma);//在這個From上進行委派
            }
            else
            {
                lblStatus.Text = strStatus;//將lblStatus的text指定為strStatus
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value >= progressBar1.Minimum & progressBar1.Value < progressBar1.Maximum)//Bar的值>=0,<Max執行此程式
            {
                progressBar1.Value = count;//將count的值給Bar
                count = count + 1;//count值+1
            }
            else
            {
                count = 1;//把1的值搬給count
                progressBar1.Value = count;//將count值給Bar
            }
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            this.Text = "";//將Splash的文字清為0
            timer1.Enabled = true;//開啟Timer1
        }

        private void frmSplash_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Enabled = false;//關閉Timer1
        }
    }
}
