namespace Shortcuts
{
    partial class frmRemoveTextFormat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRemoveTextFormat));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnGetClipboardText = new System.Windows.Forms.Button();
            this.btnCopyToClipboard = new System.Windows.Forms.Button();
            this.chkCloseAfterCopyToClipboard = new System.Windows.Forms.CheckBox();
            this.lnkClearTextbox = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(662, 385);
            this.textBox1.TabIndex = 0;
            // 
            // btnGetClipboardText
            // 
            this.btnGetClipboardText.Location = new System.Drawing.Point(12, 391);
            this.btnGetClipboardText.Name = "btnGetClipboardText";
            this.btnGetClipboardText.Size = new System.Drawing.Size(120, 23);
            this.btnGetClipboardText.TabIndex = 1;
            this.btnGetClipboardText.Text = "Get Clipboard Text";
            this.btnGetClipboardText.UseVisualStyleBackColor = true;
            this.btnGetClipboardText.Click += new System.EventHandler(this.btnGetClipboardText_Click);
            // 
            // btnCopyToClipboard
            // 
            this.btnCopyToClipboard.Location = new System.Drawing.Point(138, 391);
            this.btnCopyToClipboard.Name = "btnCopyToClipboard";
            this.btnCopyToClipboard.Size = new System.Drawing.Size(121, 23);
            this.btnCopyToClipboard.TabIndex = 1;
            this.btnCopyToClipboard.Text = "Copy To Clipboard";
            this.btnCopyToClipboard.UseVisualStyleBackColor = true;
            this.btnCopyToClipboard.Click += new System.EventHandler(this.btnCopyToClipboard_Click);
            // 
            // chkCloseAfterCopyToClipboard
            // 
            this.chkCloseAfterCopyToClipboard.AutoSize = true;
            this.chkCloseAfterCopyToClipboard.Checked = true;
            this.chkCloseAfterCopyToClipboard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCloseAfterCopyToClipboard.Location = new System.Drawing.Point(281, 395);
            this.chkCloseAfterCopyToClipboard.Name = "chkCloseAfterCopyToClipboard";
            this.chkCloseAfterCopyToClipboard.Size = new System.Drawing.Size(181, 17);
            this.chkCloseAfterCopyToClipboard.TabIndex = 2;
            this.chkCloseAfterCopyToClipboard.Text = "Close After Copying To Clipboard";
            this.chkCloseAfterCopyToClipboard.UseVisualStyleBackColor = true;
            // 
            // lnkClearTextbox
            // 
            this.lnkClearTextbox.AutoSize = true;
            this.lnkClearTextbox.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkClearTextbox.Location = new System.Drawing.Point(578, 396);
            this.lnkClearTextbox.Name = "lnkClearTextbox";
            this.lnkClearTextbox.Size = new System.Drawing.Size(72, 13);
            this.lnkClearTextbox.TabIndex = 3;
            this.lnkClearTextbox.TabStop = true;
            this.lnkClearTextbox.Text = "Clear Textbox";
            this.lnkClearTextbox.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkClearTextbox_LinkClicked);
            // 
            // frmRemoveTextFormat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 419);
            this.Controls.Add(this.lnkClearTextbox);
            this.Controls.Add(this.chkCloseAfterCopyToClipboard);
            this.Controls.Add(this.btnCopyToClipboard);
            this.Controls.Add(this.btnGetClipboardText);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRemoveTextFormat";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remove Text Format";
            this.Load += new System.EventHandler(this.frmRemoveTextFormat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnGetClipboardText;
        private System.Windows.Forms.Button btnCopyToClipboard;
        private System.Windows.Forms.CheckBox chkCloseAfterCopyToClipboard;
        private System.Windows.Forms.LinkLabel lnkClearTextbox;
    }
}