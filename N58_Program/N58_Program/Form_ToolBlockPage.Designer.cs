namespace N58
{
    partial class Form_ToolBlockPage
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
            this.cogToolBlockEditV21 = new Cognex.VisionPro.ToolBlock.CogToolBlockEditV2();
            this.btn_Save = new System.Windows.Forms.Button();
            this.unlockTextBox = new System.Windows.Forms.TextBox();
            this.unlockButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cogToolBlockEditV21)).BeginInit();
            this.SuspendLayout();
            // 
            // cogToolBlockEditV21
            // 
            this.cogToolBlockEditV21.AllowDrop = true;
            this.cogToolBlockEditV21.ContextMenuCustomizer = null;
            this.cogToolBlockEditV21.Enabled = false;
            this.cogToolBlockEditV21.Location = new System.Drawing.Point(13, 13);
            this.cogToolBlockEditV21.MinimumSize = new System.Drawing.Size(489, 0);
            this.cogToolBlockEditV21.Name = "cogToolBlockEditV21";
            this.cogToolBlockEditV21.ShowNodeToolTips = true;
            this.cogToolBlockEditV21.Size = new System.Drawing.Size(905, 530);
            this.cogToolBlockEditV21.SuspendElectricRuns = false;
            this.cogToolBlockEditV21.TabIndex = 0;
            // 
            // btn_Save
            // 
            this.btn_Save.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_Save.Location = new System.Drawing.Point(813, 555);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(105, 43);
            this.btn_Save.TabIndex = 2;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // unlockTextBox
            // 
            this.unlockTextBox.Location = new System.Drawing.Point(13, 555);
            this.unlockTextBox.Name = "unlockTextBox";
            this.unlockTextBox.PasswordChar = '*';
            this.unlockTextBox.Size = new System.Drawing.Size(100, 21);
            this.unlockTextBox.TabIndex = 6;
            this.unlockTextBox.Text = "12345";
            // 
            // unlockButton
            // 
            this.unlockButton.Location = new System.Drawing.Point(119, 555);
            this.unlockButton.Name = "unlockButton";
            this.unlockButton.Size = new System.Drawing.Size(75, 23);
            this.unlockButton.TabIndex = 5;
            this.unlockButton.Text = "Unlock";
            this.unlockButton.UseVisualStyleBackColor = true;
            this.unlockButton.Click += new System.EventHandler(this.unlockButton_Click);
            // 
            // Form_ToolBlockPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 610);
            this.ControlBox = false;
            this.Controls.Add(this.unlockTextBox);
            this.Controls.Add(this.unlockButton);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.cogToolBlockEditV21);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_ToolBlockPage";
            this.Text = "Form_ToolBlock";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_ToolBlockPage_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.cogToolBlockEditV21)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Cognex.VisionPro.ToolBlock.CogToolBlockEditV2 cogToolBlockEditV21;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.TextBox unlockTextBox;
        private System.Windows.Forms.Button unlockButton;
    }
}