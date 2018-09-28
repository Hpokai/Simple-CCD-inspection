using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cognex.VisionPro;
using Cognex.VisionPro.ToolBlock;
using Cognex.VisionPro.Display;

namespace N58
{
    public partial class Form_MainPage : Form
    {
        //private string vpp_path = "D:\\N58_CCDProgram\\VproToolBlock\\20140706.vpp";
        private string vpp_path = "D:\\N58_CCDProgram\\VproToolBlock\\N58.vpp";

        CogToolBlock MyCogToolBlock = new CogToolBlock();
        CogAcqFifoTool myCogAcqFifoTool = new CogAcqFifoTool();
        string MyToolBlockPath;
        //Form_DisplayPage m_FormDisplay = new Form_DisplayPage();
        //Form_ToolBlockPage m_FormToolBlock = new Form_ToolBlockPage();

        public Form_MainPage()
        {
            InitializeComponent();

            //設定主畫面風格、位置
            this.StartPosition = FormStartPosition.Manual;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Location = new Point(0, 0);

            //MDI
            this.IsMdiContainer = true;
        }

        #region Button

        private void toolStripbtn_Main_Click(object sender, EventArgs e)
        {
            FormHide();
            Class_Adjudgment.m_FormDisplay.Show();
            //m_FormDisplay.Show();
        }

        private void toolStripbtn_Edit_Click(object sender, EventArgs e)
        {
            FormHide();
            Class_Adjudgment.m_FormToolBlock.ToolBlockTransfer(MyCogToolBlock, MyToolBlockPath);
            Class_Adjudgment.m_FormToolBlock.Show();
            //m_FormToolBlock.ToolBlockTransfer(MyCogToolBlock, MyToolBlockPath);
            //m_FormToolBlock.Show();
        }

        private void toolStripbtn_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region FormEvent

        private CogToolBlock showToolBlock = new CogToolBlock();
        public void ReadToolBlock()
        {
            MyToolBlockPath = string.Concat(this.vpp_path);    // 讀取檔案路徑
            try
            {
                MyCogToolBlock = (CogToolBlock)CogSerializer.LoadObjectFromFile(MyToolBlockPath);     //讀取ToolBlock
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            string showToolBlockPath = string.Concat("D:\\N58_CCDProgram\\VproToolBlock\\show.vpp");    // 讀取檔案路徑
            try
            {
                showToolBlock = (CogToolBlock)CogSerializer.LoadObjectFromFile(showToolBlockPath);     //讀取ToolBlock
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void FormHide()
        {
            Class_Adjudgment.m_FormDisplay.Hide();
            Class_Adjudgment.m_FormToolBlock.Hide();
            //m_FormDisplay.Hide();
            //m_FormToolBlock.Hide();
        }

        private void FormShow()
        {
            Class_Adjudgment.m_FormDisplay.Show();
            Class_Adjudgment.m_FormToolBlock.Show();
            //m_FormDisplay.Show();
            //m_FormToolBlock.Show();
        }

        private void Init_Form()
        {
            Class_Adjudgment.m_FormDisplay.MdiParent = this;           //主選單
            Class_Adjudgment.m_FormToolBlock.MdiParent = this;         //ToolBlock
            //m_FormDisplay.MdiParent = this;           //主選單
            //m_FormToolBlock.MdiParent = this;         //ToolBlock
        }

        private void Form_MainPage_Load(object sender, EventArgs e)
        {
            Init_Form();
            Class_Adjudgment.m_FormDisplay.ToolBlockLoadiing(this.MyCogToolBlock, this.showToolBlock);
            Class_Adjudgment.m_FormDisplay.Show();
            //m_FormDisplay.Show();
        }

        private void Form_MainPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.WindowsShutDown)   //避免關機跳出提示而中斷電腦關機
            {
                if (MessageBox.Show("Please Check Exit?", "Check", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void Form_MainPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormHide();
        }

        #endregion

    }
}
