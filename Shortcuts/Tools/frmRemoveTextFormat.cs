using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Shortcuts
{

    public partial class frmRemoveTextFormat : Form
    {
        private void GetClipboardText()
        {
            if (Clipboard.ContainsText(TextDataFormat.Text))
            {
                textBox1.Text = Clipboard.GetText(TextDataFormat.Text);
            }
        }
        public frmRemoveTextFormat()
        {
            InitializeComponent();
        }

        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text, TextDataFormat.Text);
            if(chkCloseAfterCopyToClipboard.Checked)
            this.Close();
        }

        private void btnGetClipboardText_Click(object sender, EventArgs e)
        {
            GetClipboardText();
        }

        private void frmRemoveTextFormat_Load(object sender, EventArgs e)
        {
            GetClipboardText();

        }

        private void lnkClearTextbox_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBox1.Clear();
        }
    }
}
