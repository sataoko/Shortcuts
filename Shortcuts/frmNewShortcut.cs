using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Shortcuts
{
    public partial class frmNewShortcut : FormBase
    {
        public string Alias=string.Empty;
        public string Path=string.Empty;
        public frmNewShortcut()
        {
            this.FormBorderStyle = FormBorderStyle.None;

            int x = Screen.GetWorkingArea(this).Width;
            int y = Screen.GetWorkingArea(this).Height;
            this.Location = new Point(x - this.Width - 100, y - this.Height - 100);

            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAlias.Text))
            {
                MessageBox.Show("veri gir.");
            }
            else
            {
                Alias = txtAlias.Text;
                Path = txtPath.Text;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void frmNewShortcut_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Path))
            {
                txtPath.Text = Path;
                int i = Path.LastIndexOf('\\');
                txtAlias.Text = Path.Substring(i + 1, Path.Length - i - 1);
            }

            int x = Screen.GetWorkingArea(this).Width;
            int y = Screen.GetWorkingArea(this).Height;
            this.Location = new Point(x - this.Width - 100, y - this.Height - 100);
        }

        private void frmNewShortcut_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#8888cd");

            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                c, 2, ButtonBorderStyle.Solid,
                c, 2, ButtonBorderStyle.Solid,
                c, 2, ButtonBorderStyle.Solid,
                c, 2, ButtonBorderStyle.Solid);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
