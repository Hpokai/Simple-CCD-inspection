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

namespace N58
{
    public partial class Form_ToolBlockPage : Form
    {
        CogToolBlock formTB = new CogToolBlock();//宣告元件
        string strPath;

        public Form_ToolBlockPage()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = new Point(0, 0);

            //formTB = TB;
            //cogToolBlockEditV21.Subject = TB;//指定ToolBlock工具來源
        }

        private void Form_ToolBlockPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cognex.VisionPro.CogFrameGrabbers framegrabbers = new Cognex.VisionPro.CogFrameGrabbers();
            foreach (Cognex.VisionPro.ICogFrameGrabber fg in framegrabbers)
                fg.Disconnect(false);
        }

        public void ToolBlockTransfer(CogToolBlock TB, string Path)
        {
            formTB = TB;
            strPath = Path;
            cogToolBlockEditV21.Subject = TB;//指定ToolBlock工具來源
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            formTB = cogToolBlockEditV21.Subject;//宣告ToolBlock
            CogSerializer.SaveObjectToFile(formTB, strPath);//儲存變更
        }

        private void unlockButton_Click(object sender, EventArgs e)
        {
            if (this.cogToolBlockEditV21.Enabled == false)
            {
                if (0 == string.Compare(this.unlockTextBox.Text, "pokai"))
                {
                    this.cogToolBlockEditV21.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Password Error!");
                }
            }
            else
            {
                this.unlockTextBox.Text = "12345";
                this.cogToolBlockEditV21.Enabled = false;
            }
        }

    }
}
