namespace Shortcuts
{
    partial class frmUpdateShortcut
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
            this.txtNewAlias = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lnkOK = new System.Windows.Forms.LinkLabel();
            this.lnkCancel = new System.Windows.Forms.LinkLabel();
            this.txtNewPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNewAlias
            // 
            this.txtNewAlias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewAlias.Location = new System.Drawing.Point(100, 21);
            this.txtNewAlias.Name = "txtNewAlias";
            this.txtNewAlias.Size = new System.Drawing.Size(350, 20);
            this.txtNewAlias.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Shortcut Alias";
            // 
            // lnkOK
            // 
            this.lnkOK.AutoSize = true;
            this.lnkOK.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkOK.Location = new System.Drawing.Point(360, 86);
            this.lnkOK.Name = "lnkOK";
            this.lnkOK.Size = new System.Drawing.Size(22, 13);
            this.lnkOK.TabIndex = 7;
            this.lnkOK.TabStop = true;
            this.lnkOK.Text = "OK";
            this.lnkOK.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkOK_LinkClicked);
            // 
            // lnkCancel
            // 
            this.lnkCancel.AutoSize = true;
            this.lnkCancel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkCancel.Location = new System.Drawing.Point(410, 86);
            this.lnkCancel.Name = "lnkCancel";
            this.lnkCancel.Size = new System.Drawing.Size(40, 13);
            this.lnkCancel.TabIndex = 7;
            this.lnkCancel.TabStop = true;
            this.lnkCancel.Text = "Cancel";
            this.lnkCancel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCancel_LinkClicked);
            // 
            // txtNewPath
            // 
            this.txtNewPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewPath.Location = new System.Drawing.Point(100, 47);
            this.txtNewPath.Name = "txtNewPath";
            this.txtNewPath.Size = new System.Drawing.Size(350, 20);
            this.txtNewPath.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Shortcut Path";
            // 
            // frmUpdateShortcut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(476, 118);
            this.Controls.Add(this.lnkCancel);
            this.Controls.Add(this.lnkOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNewPath);
            this.Controls.Add(this.txtNewAlias);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUpdateShortcut";
            this.ShowInTaskbar = false;
            this.Text = "frmUpdateShortcut";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmUpdateShortcut_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmUpdateShortcut_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNewAlias;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnkOK;
        private System.Windows.Forms.LinkLabel lnkCancel;
        private System.Windows.Forms.TextBox txtNewPath;
        private System.Windows.Forms.Label label2;
    }
}