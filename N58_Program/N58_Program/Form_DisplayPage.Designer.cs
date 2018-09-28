namespace N58
{
    partial class Form_DisplayPage
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_DisplayPage));
            this.cogRecordDisplay1 = new Cognex.VisionPro.CogRecordDisplay();
            this.btn_Live = new System.Windows.Forms.Button();
            this.btn_Trigger = new System.Windows.Forms.Button();
            this.PicBox_Status = new System.Windows.Forms.PictureBox();
            this.minAreaTopBottomTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.minAreaLeftRightTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.editButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_Status)).BeginInit();
            this.SuspendLayout();
            // 
            // cogRecordDisplay1
            // 
            this.cogRecordDisplay1.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay1.ColorMapLowerRoiLimit = 0D;
            this.cogRecordDisplay1.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogRecordDisplay1.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay1.ColorMapUpperRoiLimit = 1D;
            this.cogRecordDisplay1.Location = new System.Drawing.Point(6, 5);
            this.cogRecordDisplay1.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogRecordDisplay1.MouseWheelSensitivity = 1D;
            this.cogRecordDisplay1.Name = "cogRecordDisplay1";
            this.cogRecordDisplay1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogRecordDisplay1.OcxState")));
            this.cogRecordDisplay1.Size = new System.Drawing.Size(800, 600);
            this.cogRecordDisplay1.TabIndex = 1;
            // 
            // btn_Live
            // 
            this.btn_Live.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_Live.Location = new System.Drawing.Point(812, 61);
            this.btn_Live.Name = "btn_Live";
            this.btn_Live.Size = new System.Drawing.Size(105, 43);
            this.btn_Live.TabIndex = 3;
            this.btn_Live.Text = "Online";
            this.btn_Live.UseVisualStyleBackColor = true;
            this.btn_Live.Click += new System.EventHandler(this.btn_Live_Click);
            // 
            // btn_Trigger
            // 
            this.btn_Trigger.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_Trigger.Location = new System.Drawing.Point(812, 12);
            this.btn_Trigger.Name = "btn_Trigger";
            this.btn_Trigger.Size = new System.Drawing.Size(105, 43);
            this.btn_Trigger.TabIndex = 2;
            this.btn_Trigger.Text = "Trigger";
            this.btn_Trigger.UseVisualStyleBackColor = true;
            this.btn_Trigger.Click += new System.EventHandler(this.btn_Trigger_Click);
            this.btn_Trigger.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btn_Trigger_KeyUp);
            // 
            // PicBox_Status
            // 
            this.PicBox_Status.Location = new System.Drawing.Point(812, 110);
            this.PicBox_Status.Name = "PicBox_Status";
            this.PicBox_Status.Size = new System.Drawing.Size(105, 105);
            this.PicBox_Status.TabIndex = 5;
            this.PicBox_Status.TabStop = false;
            this.PicBox_Status.Paint += new System.Windows.Forms.PaintEventHandler(this.PicBox_Status_Paint);
            // 
            // minAreaTopBottomTextBox
            // 
            this.minAreaTopBottomTextBox.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.minAreaTopBottomTextBox.Location = new System.Drawing.Point(814, 282);
            this.minAreaTopBottomTextBox.MaxLength = 5;
            this.minAreaTopBottomTextBox.Name = "minAreaTopBottomTextBox";
            this.minAreaTopBottomTextBox.Size = new System.Drawing.Size(100, 23);
            this.minAreaTopBottomTextBox.TabIndex = 6;
            this.minAreaTopBottomTextBox.Text = "0.65";
            this.minAreaTopBottomTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.label1.Location = new System.Drawing.Point(820, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 30);
            this.label1.TabIndex = 7;
            this.label1.Text = "Top and Bottom\r\nmin area";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // minAreaLeftRightTextBox
            // 
            this.minAreaLeftRightTextBox.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.minAreaLeftRightTextBox.Location = new System.Drawing.Point(814, 338);
            this.minAreaLeftRightTextBox.MaxLength = 5;
            this.minAreaLeftRightTextBox.Name = "minAreaLeftRightTextBox";
            this.minAreaLeftRightTextBox.Size = new System.Drawing.Size(100, 23);
            this.minAreaLeftRightTextBox.TabIndex = 6;
            this.minAreaLeftRightTextBox.Text = "0.75";
            this.minAreaLeftRightTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(820, 309);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Left and Right\r\nmin area";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 400;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // editButton
            // 
            this.editButton.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.editButton.Location = new System.Drawing.Point(814, 367);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(100, 46);
            this.editButton.TabIndex = 18;
            this.editButton.Text = "edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // Form_DisplayPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 610);
            this.ControlBox = false;
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.minAreaLeftRightTextBox);
            this.Controls.Add(this.minAreaTopBottomTextBox);
            this.Controls.Add(this.PicBox_Status);
            this.Controls.Add(this.btn_Live);
            this.Controls.Add(this.btn_Trigger);
            this.Controls.Add(this.cogRecordDisplay1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_DisplayPage";
            this.Text = "Form_Display";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_DisplayPage_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_DisplayPage_FormClosed);
            this.Load += new System.EventHandler(this.Form_DisplayPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_Status)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Cognex.VisionPro.CogRecordDisplay cogRecordDisplay1;
        private System.Windows.Forms.Button btn_Live;
        private System.Windows.Forms.Button btn_Trigger;
        private System.Windows.Forms.PictureBox PicBox_Status;
        private System.Windows.Forms.TextBox minAreaTopBottomTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox minAreaLeftRightTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button editButton;
    }
}