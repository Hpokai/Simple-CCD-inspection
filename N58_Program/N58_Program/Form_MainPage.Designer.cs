namespace N58
{
    partial class Form_MainPage
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_MainPage));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripbtn_Main = new System.Windows.Forms.ToolStripButton();
            this.toolStripbtn_Edit = new System.Windows.Forms.ToolStripButton();
            this.toolStripbtn_Exit = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripbtn_Main,
            this.toolStripbtn_Edit,
            this.toolStripbtn_Exit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(935, 43);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripbtn_Main
            // 
            this.toolStripbtn_Main.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.toolStripbtn_Main.Image = ((System.Drawing.Image)(resources.GetObject("toolStripbtn_Main.Image")));
            this.toolStripbtn_Main.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripbtn_Main.Name = "toolStripbtn_Main";
            this.toolStripbtn_Main.Size = new System.Drawing.Size(59, 40);
            this.toolStripbtn_Main.Text = "Home";
            this.toolStripbtn_Main.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripbtn_Main.Click += new System.EventHandler(this.toolStripbtn_Main_Click);
            // 
            // toolStripbtn_Edit
            // 
            this.toolStripbtn_Edit.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.toolStripbtn_Edit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripbtn_Edit.Image")));
            this.toolStripbtn_Edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripbtn_Edit.Name = "toolStripbtn_Edit";
            this.toolStripbtn_Edit.Size = new System.Drawing.Size(42, 40);
            this.toolStripbtn_Edit.Text = "Edit";
            this.toolStripbtn_Edit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripbtn_Edit.Click += new System.EventHandler(this.toolStripbtn_Edit_Click);
            // 
            // toolStripbtn_Exit
            // 
            this.toolStripbtn_Exit.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.toolStripbtn_Exit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripbtn_Exit.Image")));
            this.toolStripbtn_Exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripbtn_Exit.Name = "toolStripbtn_Exit";
            this.toolStripbtn_Exit.Size = new System.Drawing.Size(40, 40);
            this.toolStripbtn_Exit.Text = "Exit";
            this.toolStripbtn_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripbtn_Exit.Click += new System.EventHandler(this.toolStripbtn_Exit_Click);
            // 
            // Form_MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 658);
            this.ControlBox = false;
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_MainPage";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_MainPage_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_MainPage_FormClosed);
            this.Load += new System.EventHandler(this.Form_MainPage_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripbtn_Main;
        private System.Windows.Forms.ToolStripButton toolStripbtn_Edit;
        private System.Windows.Forms.ToolStripButton toolStripbtn_Exit;

    }
}

