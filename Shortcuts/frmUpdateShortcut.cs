using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Shortcuts
{
    public partial class frmUpdateShortcut : Form
    {
        public string ShortcutAlias;
        public string ShortcutPath;

        public frmUpdateShortcut()
        {
            InitializeComponent();
        }

        private void frmUpdateShortcut_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            
            int x = Screen.GetWorkingArea(this).Width;
            int y = Screen.GetWorkingArea(this).Height;
            this.Location = new Point(x - this.Width - 100, y - this.Height - 100);

            txtNewAlias.Text = ShortcutAlias;
            txtNewPath.Text = ShortcutPath;
        }

        private void frmUpdateShortcut_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#8888cd");

            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                c, 2, ButtonBorderStyle.Solid,
                c, 2, ButtonBorderStyle.Solid,
                c, 2, ButtonBorderStyle.Solid,
                c, 2, ButtonBorderStyle.Solid);
        }

        private void lnkOK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShortcutAlias = txtNewAlias.Text;
            ShortcutPath = txtNewPath.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void lnkCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }
    }
}
