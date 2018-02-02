namespace Shortcuts
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.picClose = new System.Windows.Forms.PictureBox();
            this.chkRunAtStartUp = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.SuspendLayout();
            // 
            // picClose
            // 
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Image = ((System.Drawing.Image)(resources.GetObject("picClose.Image")));
            this.picClose.Location = new System.Drawing.Point(423, 2);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(17, 16);
            this.picClose.TabIndex = 1;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // chkRunAtStartUp
            // 
            this.chkRunAtStartUp.AutoSize = true;
            this.chkRunAtStartUp.Location = new System.Drawing.Point(31, 37);
            this.chkRunAtStartUp.Name = "chkRunAtStartUp";
            this.chkRunAtStartUp.Size = new System.Drawing.Size(95, 17);
            this.chkRunAtStartUp.TabIndex = 0;
            this.chkRunAtStartUp.Text = "Run at Startup";
            this.chkRunAtStartUp.UseVisualStyleBackColor = true;
            this.chkRunAtStartUp.CheckedChanged += new System.EventHandler(this.chkRunAtStartUp_CheckedChanged);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(442, 92);
            this.Controls.Add(this.picClose);
            this.Controls.Add(this.chkRunAtStartUp);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmSettings_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkRunAtStartUp;
        private System.Windows.Forms.PictureBox picClose;
    }
}