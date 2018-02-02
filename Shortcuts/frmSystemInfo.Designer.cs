namespace Shortcuts
{
    partial class frmSystemInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSystemInfo));
            this.btnShowSystemInfo = new System.Windows.Forms.Button();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.btnSaveSystemInfo = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // btnShowSystemInfo
            // 
            this.btnShowSystemInfo.Location = new System.Drawing.Point(574, 12);
            this.btnShowSystemInfo.Name = "btnShowSystemInfo";
            this.btnShowSystemInfo.Size = new System.Drawing.Size(145, 23);
            this.btnShowSystemInfo.TabIndex = 0;
            this.btnShowSystemInfo.Text = "Show System Info";
            this.btnShowSystemInfo.UseVisualStyleBackColor = true;
            this.btnShowSystemInfo.Click += new System.EventHandler(this.btnShowSystemInfo_Click);
            // 
            // txtConsole
            // 
            this.txtConsole.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtConsole.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtConsole.Location = new System.Drawing.Point(0, 0);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConsole.Size = new System.Drawing.Size(559, 484);
            this.txtConsole.TabIndex = 1;
            // 
            // btnSaveSystemInfo
            // 
            this.btnSaveSystemInfo.Location = new System.Drawing.Point(574, 41);
            this.btnSaveSystemInfo.Name = "btnSaveSystemInfo";
            this.btnSaveSystemInfo.Size = new System.Drawing.Size(145, 23);
            this.btnSaveSystemInfo.TabIndex = 0;
            this.btnSaveSystemInfo.Text = "Save System Info";
            this.btnSaveSystemInfo.UseVisualStyleBackColor = true;
            this.btnSaveSystemInfo.Click += new System.EventHandler(this.btnSaveSystemInfo_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "*.txt";
            this.saveFileDialog1.FileName = "SystemInfo.txt";
            this.saveFileDialog1.InitialDirectory = "C:\\";
            // 
            // frmSystemInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 484);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.btnSaveSystemInfo);
            this.Controls.Add(this.btnShowSystemInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSystemInfo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "System Info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShowSystemInfo;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.Button btnSaveSystemInfo;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}