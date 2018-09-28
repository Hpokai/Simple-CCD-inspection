using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Cognex.VisionPro;
using Cognex.VisionPro.ToolBlock;
using Cognex.VisionPro.Display;
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.CalibFix;
using Cognex.VisionPro.Caliper;
using Cognex.VisionPro.PMAlign;
using Cognex.VisionPro.Dimensioning;

namespace N58
{
    public partial class Form_DisplayPage : Form
    {
        #region Fiedls

        CogToolBlock MyCogToolBlock = new CogToolBlock();
        CogAcqFifoTool myCogAcqFifoTool = new CogAcqFifoTool();
        public delegate void UIStauts();
        Thread Trigger;

        double WidthSetting = 0.0, Threshold = 0.0;

        #endregion

        private Color color_NG_background = Color.Red;
        private Color color_OK_background = Color.Lime;
        private SolidBrush color_NG_string = new SolidBrush(Color.White);
        private SolidBrush color_OK_string = new SolidBrush(Color.Maroon);

        public Form_DisplayPage()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = new Point(0, 0);
            
            this.ObjectEnabled(this.isEdit);
            this.CreateTodayFolder();
        }

        #region FormEvent

        private void Form_DisplayPage_Load(object sender, EventArgs e)
        {
            //myCogAcqFifoTool = (CogAcqFifoTool)MyCogToolBlock.Tools["CogAcqFifoTool1"];

        }

        private void Form_DisplayPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (Trigger.IsAlive == true)
                {
                    Trigger.Abort();
                }
            }
            catch
            {
                //MessageBox.Show("ValueRead_Thread執行續關閉錯誤或執行緒未開啟", "發生錯誤!");
            }

            Cognex.VisionPro.CogFrameGrabbers framegrabbers = new Cognex.VisionPro.CogFrameGrabbers();
            foreach (Cognex.VisionPro.ICogFrameGrabber fg in framegrabbers)
                fg.Disconnect(false);
        }

        private void Form_DisplayPage_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        public void ToolBlockLoadiing(CogToolBlock TB, CogToolBlock showTB)
        {
            MyCogToolBlock = TB;
            showToolBlock = showTB;
        }

        #endregion

        #region ButtonEvent

        private void btn_Live_Click(object sender, EventArgs e)
        {
            //myCogAcqFifoTool = (CogAcqFifoTool)MyCogToolBlock.Tools["CogAcqFifoTool1"];

            try
            {
                this.cogRecordDisplay1.Image = myCogAcqFifoTool.OutputImage;
                if (this.cogRecordDisplay1.LiveDisplayRunning)
                {
                    this.cogRecordDisplay1.StopLiveDisplay();
                    this.btn_Live.Text = "Online";
                }
                else
                {
                    cogRecordDisplay1.StartLiveDisplay(myCogAcqFifoTool.Operator);
                    this.btn_Live.Text = "Offline";
                }
            }
            catch
            {
                MessageBox.Show("LiveViewError");
            }
        }

        private void btn_Trigger_Click(object sender, EventArgs e)
        {
            this.PicBox_Status.BackColor = System.Drawing.Color.FromName("Control");

            this.btn_Live.Text = "Online";
            Trigger = new Thread(Run);
            Trigger.Priority = ThreadPriority.AboveNormal;
            Trigger.Start();
            btn_Trigger.Enabled = false;
        }

        #endregion

        #region RunThread

       private CogToolBlock showToolBlock = new CogToolBlock();
       private bool SmallBlob()
       {
           bool result = true;

           bool[] bottom_blob_error = new bool[4];
           bool[] top_blob_error = new bool[4];
           bool[] left_blob_error = new bool[13];
           bool[] right_blob_error = new bool[13];

           for (int i = 0; i < 13; i++)
           {
               if (i < 4)
               {
                   bottom_blob_error[i] = (bool)this.MyCogToolBlock.Outputs["__B_A_" + i.ToString() + "_Bool_Value_System_Boolean_"].Value;
                   top_blob_error[i] = (bool)this.MyCogToolBlock.Outputs["__T_A_" + i.ToString() + "_Bool_Value_System_Boolean_"].Value;
               }
               left_blob_error[i] = (bool)this.MyCogToolBlock.Outputs["__L_A_" + i.ToString() + "_Bool_Value_System_Boolean_"].Value;
               right_blob_error[i] = (bool)this.MyCogToolBlock.Outputs["__R_A_" + i.ToString() + "_Bool_Value_System_Boolean_"].Value;
           }

           double[] bottom_radius = new double[4];
           double[] top_radius = new double[4];
           double[] left_radius = new double[13];
           double[] right_radius = new double[13];
           for (int i = 0; i < 13; i++)
           {
               if (i < 4)
               {
                   if (true == bottom_blob_error[i])
                   {
                       bottom_radius[i] = 0.4;
                       result = false;
                   }
                   else { bottom_radius[i] = 0.00001; }

                   if (true == top_blob_error[i])
                   {
                       top_radius[i] = 0.4;
                       result = false;
                   }
                   else { top_radius[i] = 0.00001; }
               }
               if (true == left_blob_error[i])
               {
                   left_radius[i] = 0.4;
                   result = false;
               }
               else { left_radius[i] = 0.00001; }

               if (true == right_blob_error[i])
               {
                   right_radius[i] = 0.4;
                   result = false;
               }
               else { right_radius[i] = 0.00001; }
           }

           ///////////////////////////
           // this tool block for show
           ///////////////////////////

           this.showToolBlock.Inputs["OutputImage"].Value = (CogImage8Grey)this.MyCogToolBlock.Outputs["OutputImage"].Value;
           this.showToolBlock.Inputs["GetPose"].Value = (CogTransform2DLinear)this.MyCogToolBlock.Outputs["GetPose"].Value;
           this.showToolBlock.Inputs["TranslationX"].Value = (double)this.MyCogToolBlock.Outputs["TranslationX"].Value;
           this.showToolBlock.Inputs["TranslationY"].Value = (double)this.MyCogToolBlock.Outputs["TranslationY"].Value;
           this.showToolBlock.Inputs["Rotation"].Value = (double)this.MyCogToolBlock.Outputs["Rotation"].Value;

           for (int i = 0; i < 13; i++)
           {
               if (i < 4)
               {
                   this.showToolBlock.Inputs["B_" + i.ToString() + "_CenterX"].Value = (double)this.MyCogToolBlock.Outputs["B_" + i.ToString() + "_CenterX"].Value;
                   this.showToolBlock.Inputs["B_" + i.ToString() + "_CenterY"].Value = (double)this.MyCogToolBlock.Outputs["B_" + i.ToString() + "_CenterY"].Value;
                   this.showToolBlock.Inputs["B_" + i.ToString() + "_Radius"].Value = bottom_radius[i];

                   this.showToolBlock.Inputs["T_" + i.ToString() + "_CenterX"].Value = (double)this.MyCogToolBlock.Outputs["T_" + i.ToString() + "_CenterX"].Value;
                   this.showToolBlock.Inputs["T_" + i.ToString() + "_CenterY"].Value = (double)this.MyCogToolBlock.Outputs["T_" + i.ToString() + "_CenterY"].Value;
                   this.showToolBlock.Inputs["T_" + i.ToString() + "_Radius"].Value = top_radius[i];
               }
               this.showToolBlock.Inputs["L_" + i.ToString() + "_CenterX"].Value = (double)this.MyCogToolBlock.Outputs["L_" + i.ToString() + "_CenterX"].Value;
               this.showToolBlock.Inputs["L_" + i.ToString() + "_CenterY"].Value = (double)this.MyCogToolBlock.Outputs["L_" + i.ToString() + "_CenterY"].Value;
               this.showToolBlock.Inputs["L_" + i.ToString() + "_Radius"].Value = left_radius[i];

               this.showToolBlock.Inputs["R_" + i.ToString() + "_CenterX"].Value = (double)this.MyCogToolBlock.Outputs["R_" + i.ToString() + "_CenterX"].Value;
               this.showToolBlock.Inputs["R_" + i.ToString() + "_CenterY"].Value = (double)this.MyCogToolBlock.Outputs["R_" + i.ToString() + "_CenterY"].Value;
               this.showToolBlock.Inputs["R_" + i.ToString() + "_Radius"].Value = right_radius[i];
           }

           this.showToolBlock.Run();

           return result;
       }

        private void Run()
        {
            //bool PMAling, Blob;

            this.WidthSetting = Convert.ToDouble(minAreaLeftRightTextBox.Text);
            //Threshold = Convert.ToDouble(minAreaTopBottomTextBox.Text);

            cogRecordDisplay1.Image = null;
            cogRecordDisplay1.StaticGraphics.Clear();
            cogRecordDisplay1.InteractiveGraphics.Clear();

            MyCogToolBlock.Inputs["top_bottom_min_area"].Value = double.Parse(this.minAreaTopBottomTextBox.Text);
            MyCogToolBlock.Inputs["left_right_min_area"].Value = double.Parse(this.minAreaLeftRightTextBox.Text);
            MyCogToolBlock.Run();
            //cogRecordDisplay1.Record = MyCogToolBlock.CreateLastRunRecord().SubRecords[1];   ///////// not this to show
            //cogRecordDisplay1.Fit(true);
            cogRecordDisplay1.AutoFit = true;

            if (true == PMAlingRun())
            {
                if (true == this.BlobNullCheck())
                {
                    if (false == this.SmallBlob())
                    {
                        cogRecordDisplay1.Record = this.showToolBlock.CreateLastRunRecord().SubRecords["CogFixtureTool1.OutputImage"];
                        if (this.InvokeRequired == true)
                        {
                            this.Invoke(new UIStauts(delegate()
                            {
                                btn_Trigger.Enabled = true;
                                PicBox_Status.BackColor = color_NG_background;
                            }
                                ));
                        }
                        MessageBox.Show("Judge Is Fail!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        cogRecordDisplay1.Record = this.showToolBlock.CreateLastRunRecord().SubRecords["CogFixtureTool1.OutputImage"];
                        if (this.InvokeRequired == true)
                        {
                            this.Invoke(new UIStauts(
                                delegate()
                                {
                                    btn_Trigger.Enabled = true;
                                    PicBox_Status.BackColor = color_OK_background;
                                }
                                ));
                        }
                    }


                    //Blob = BobArea();                
                    //if (Blob)
                    //{
                    //    if (this.InvokeRequired == true)
                    //    {
                    //        this.Invoke(new UIStauts(delegate()
                    //        {
                    //            btn_Trigger.Enabled = true;
                    //            PicBox_Status.BackColor = color_NG_background;
                    //        }
                    //            ));
                    //    }
                    //    MessageBox.Show("Judge Is Fail!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                  
                    //}
                    //else    // area is correct
                    //{
                    //    if (false == this.FindLine())
                    //    {
                    //        if (this.InvokeRequired == true)
                    //        {
                    //            this.Invoke(new UIStauts(delegate()
                    //            {
                    //                btn_Trigger.Enabled = true;
                    //                PicBox_Status.BackColor = color_NG_background;
                    //            }
                    //                ));
                    //        }
                    //        MessageBox.Show("Judge Is Fail!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    }
                    //    else
                    //    {
                    //        if (this.InvokeRequired == true)
                    //        {
                    //            this.Invoke(new UIStauts(
                    //                delegate()
                    //                {
                    //                    btn_Trigger.Enabled = true;
                    //                    PicBox_Status.BackColor = color_OK_background;
                    //                }
                    //                ));
                    //        }
                    //    }
                    //}
                }
                else
                {
                    cogRecordDisplay1.Record = MyCogToolBlock.CreateLastRunRecord().SubRecords[0];
                    if (this.InvokeRequired == true)
                    {
                        this.Invoke(new UIStauts(delegate()
                        {
                            btn_Trigger.Enabled = true;
                            PicBox_Status.BackColor = color_NG_background;
                        }
                            ));
                    }
                    MessageBox.Show("無產品可檢測，請放上產品！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                cogRecordDisplay1.Record = MyCogToolBlock.CreateLastRunRecord().SubRecords[0]; 
                if (this.InvokeRequired == true)
                {
                    this.Invoke(new UIStauts(delegate()
                    {
                        btn_Trigger.Enabled = true;
                        PicBox_Status.BackColor = color_NG_background;
                    }
                        ));
                }
                MessageBox.Show("請將產品位置擺放正確！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.img_num++;
            this.WriteRecordDisplay(this.cogRecordDisplay1, this.img_num.ToString().PadLeft(10, '0'));
        }

        private int img_num = 0;
        private string img_save_dir = @"D:\\N58_GSR_Image" + "\\" + DateTime.Now.ToString("yyyyMMdd");
        private string num_file = @"D:\\N58_GSR_Image" + "\\" + DateTime.Now.ToString("yyyyMMdd") + "\\" + "num.txt";
        private void CreateTodayFolder()
        {
            if (false == System.IO.Directory.Exists(img_save_dir))
            {
                System.IO.Directory.CreateDirectory(img_save_dir);

                this.img_num = 0;
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(this.num_file))
                {
                    file.WriteLine(this.img_num.ToString());
                }
            }
        }
        private void WriteRecordDisplay(Cognex.VisionPro.CogRecordDisplay display, string imagename)
        {
            try
            {
                Image image = display.CreateContentBitmap(Cognex.VisionPro.Display.CogDisplayContentBitmapConstants.Image);

                string savePath = string.Empty;
                if (color_NG_background == PicBox_Status.BackColor)
                {
                    savePath = this.img_save_dir + "\\" + imagename + "_NG" + ".jpg";
                }
                else if (color_OK_background == PicBox_Status.BackColor)
                {
                    savePath = this.img_save_dir + "\\" + imagename + "_OK" + ".jpg";
                }
                else
                {
                    savePath = this.img_save_dir + "\\" + imagename + "_" + ".jpg";
                }
                image.Save(savePath);

                image.Dispose();

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(this.num_file))
                {
                    file.WriteLine(this.img_num.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        #endregion

        #region RunFunction
        private double test_value = 0.0;

        private bool PMAlingRun()
        {
            CogPMAlignTool MyPMAlingToo = (CogPMAlignTool)this.MyCogToolBlock.Tools["CogPMAlignTool1"];
            int Num = MyPMAlingToo.Results.Count;
            bool Result = false;

            if (Num == 1)
            {
                Result = true;
            }
            else
            {
                Result = false;
            }

            return Result;
        }

        private bool BlobNullCheck()
        {
            bool Result = true;

            CogToolBlock myCogToolBlock = new CogToolBlock();
            CogBlobTool myCogBlobTool = new CogBlobTool();

            myCogToolBlock = (CogToolBlock)this.MyCogToolBlock.Tools["CogToolBlock_Bottom"];
            if (true == Result)
            {
                for (int i = 1; i <= 4; i++)
                {
                    myCogBlobTool = (CogBlobTool)myCogToolBlock.Tools["CogBlobTool" + i.ToString()];
                    if (myCogBlobTool.Results.GetBlobs().Count <= 0)
                    {
                        Result = false;
                        i = 5;
                    }

                }
            }
            myCogToolBlock = (CogToolBlock)this.MyCogToolBlock.Tools["CogToolBlock_Top"];
            if (true == Result)
            {
                for (int i = 1; i <= 4; i++)
                {
                    myCogBlobTool = (CogBlobTool)myCogToolBlock.Tools["CogBlobTool" + i.ToString()];
                    if (myCogBlobTool.Results.GetBlobs().Count <= 0)
                    {
                        Result = false;
                        i = 5;
                    }

                }
            } 
            myCogToolBlock = (CogToolBlock)this.MyCogToolBlock.Tools["CogToolBlock_Left"];
            if (true == Result)
            {
                for (int i = 1; i <= 13; i++)
                {
                    myCogBlobTool = (CogBlobTool)myCogToolBlock.Tools["CogBlobTool" + i.ToString()];
                    if (myCogBlobTool.Results.GetBlobs().Count <= 0)
                    {
                        Result = false;
                        i = 14;
                    }

                }
            }
            myCogToolBlock = (CogToolBlock)this.MyCogToolBlock.Tools["CogToolBlock_Right"];
            if (true == Result)
            {
                for (int i = 1; i <= 13; i++)
                {
                    myCogBlobTool = (CogBlobTool)myCogToolBlock.Tools["CogBlobTool" + i.ToString()];
                    if (myCogBlobTool.Results.GetBlobs().Count <= 0)
                    {
                        Result = false;
                        i = 14;
                    }

                }
            }

            return Result;
        }

        private bool BobArea()
        {
            CogBlobTool MyBlobTool = (CogBlobTool)this.MyCogToolBlock.Tools["CogBlobTool1"];
            CogBlobLabelConstants Type, Blob;
            int Num = MyBlobTool.Results.GetBlobs().Count;
            double Value = 0;
            bool Result = false, Hold = false;

            for (int i = 0; i < Num; i++)
            {
                Type = MyBlobTool.Results.GetBlobs()[i].Label;
                Blob = CogBlobLabelConstants.Blob;

                if (!Hold)
                {
                    if (Type == Blob)
                    {
                        Value = MyBlobTool.Results.GetBlobs()[i].Area;
                        Hold = true;
                    }
                }
            }

            this.test_value = Value;
            if (Value > (Threshold - 5))
            {
                Result = false;
                Hold = false;
            }
            else
            {
                Result = true;
                Hold = false;
            }

            return Result;
        }

        private bool FindLine()
        {
            bool result = true;

            const int line_num = 30;
            double[] width_1_Right = new double[line_num];
            double[] width_2_Left = new double[line_num];
            double[] width_3_Top = new double[line_num];
            double[] width_4_Bottom = new double[line_num];
            for (int i = 0; i < line_num; i++)
            {
                width_1_Right[i] = 0.0;
                width_2_Left[i] = 0.0;
                width_3_Top[i] = 0.0;
                width_4_Bottom[i] = 0.0;
            }

            try
            {
                CogFindLineResults MyFindLindResults_1 = (CogFindLineResults)this.MyCogToolBlock.Outputs["CogFindLineResult_1"].Value;
                CogFindLineResults MyFindLindResults_2 = (CogFindLineResults)this.MyCogToolBlock.Outputs["CogFindLineResult_2"].Value;
                CogFindLineResults MyFindLindResults_3 = (CogFindLineResults)this.MyCogToolBlock.Outputs["CogFindLineResult_3"].Value;
                CogFindLineResults MyFindLindResults_4 = (CogFindLineResults)this.MyCogToolBlock.Outputs["CogFindLineResult_4"].Value;

                // double width = MyFindLindResults_1[0].CaliperResults[0].Width;
                double right_width_avg = 0.0, left_width_avg = 0.0, top_width_avg = 0.0, bottom_width_avg = 0.0;
                for (int i = 0; i < line_num; i++)
                {
                    width_1_Right[i] = MyFindLindResults_1[i].CaliperResults[0].Width;
                    width_2_Left[i] = MyFindLindResults_2[i].CaliperResults[0].Width;
                    width_3_Top[i] = MyFindLindResults_3[i].CaliperResults[0].Width;
                    width_4_Bottom[i] = MyFindLindResults_4[i].CaliperResults[0].Width;

                    right_width_avg += width_1_Right[i];
                    left_width_avg += width_2_Left[i];
                    top_width_avg += width_3_Top[i];
                    bottom_width_avg += width_4_Bottom[i];
                }
                this.right_width = right_width_avg / line_num;
                this.left_width = left_width_avg / line_num;
                this.top_width = top_width_avg / line_num;
                this.bottom_width = bottom_width_avg / line_num;


                for (int i = 0; i < line_num; i++)
                {
                    if (this.WidthSetting > width_1_Right[i])
                    {
                        result = false;
                        i = line_num;
                    }
                }
                if (true == result)
                {
                    for (int i = 0; i < line_num; i++)
                    {
                        if (this.WidthSetting > width_2_Left[i])
                        {
                            result = false;
                            i = line_num;
                        }
                    }
                }
                if (true == result)
                {
                    for (int i = 0; i < line_num; i++)
                    {
                        if (this.WidthSetting > width_3_Top[i])
                        {
                            result = false;
                            i = line_num;
                        }
                    }
                }
                if (true == result)
                {
                    for (int i = 0; i < line_num; i++)
                    {
                        if (this.WidthSetting > width_4_Bottom[i])
                        {
                            result = false;
                            i = line_num;
                        }
                    }
                }
            }
            catch //(Exception e)
            {
                result = false;
            }

            return result;
        }

        #endregion


        double right_width = 0.0, left_width = 0.0, top_width = 0.0, bottom_width = 0.0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //this.testLabel.Text = test_value.ToString();

            //this.rightLabel.Text = right_width.ToString();
            //this.leftLabel.Text = left_width.ToString();
            //this.topLabel.Text = top_width.ToString();
            //this.bottomLabel.Text = bottom_width.ToString();

            if (false == this.isEdit)
            {
                this.btn_Trigger.Select();
            }
        }

        private void btn_Trigger_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        //this.PicBox_Status.BackColor = color_NG_background;
                        this.btn_Trigger.PerformClick();
                    }
                    break;
                case Keys.Escape:
                    {
                        //this.PicBox_Status.BackColor = color_OK_background;
                    }
                    break;
                default:
                    break;
            }
        }

        private bool isEdit = false;
        private void editButton_Click(object sender, EventArgs e)
        {
            this.isEdit = !this.isEdit;
            //this.label3.Text = this.isEdit.ToString();
            this.ObjectEnabled(this.isEdit);
        }
        private void ObjectEnabled(bool isEnabled)
        {
            this.btn_Live.Enabled = isEnabled;
            this.minAreaTopBottomTextBox.Enabled = isEnabled;
            this.minAreaLeftRightTextBox.Enabled = isEnabled;
        }

        private void PicBox_Status_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (color_NG_background == PicBox_Status.BackColor)
            {
                g.DrawString("NG", new Font(FontFamily.GenericSerif, 36f, FontStyle.Regular), color_NG_string,
                    new Rectangle(0, 0, ((PictureBox)sender).Width - 2, ((PictureBox)sender).Height - 2),
                    new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            }
            else if (color_OK_background == PicBox_Status.BackColor)
            {
                g.DrawString("OK", new Font(FontFamily.GenericSerif, 36f, FontStyle.Regular), color_OK_string,
                    new Rectangle(0, 0, ((PictureBox)sender).Width - 2, ((PictureBox)sender).Height - 2),
                    new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            }
        }
    }
}
