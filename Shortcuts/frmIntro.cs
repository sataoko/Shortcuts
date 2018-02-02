using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Shortcuts
{
    public partial class frmIntro : FormBase
    {
        public frmIntro()
        {
            InitializeComponent();
        }

        private void frmIntro_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void frmIntro_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#8888cd");

            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                c, 2, ButtonBorderStyle.Solid,
                c, 2, ButtonBorderStyle.Solid,
                c, 2, ButtonBorderStyle.Solid,
                c, 2, ButtonBorderStyle.Solid);

        }

        private void chkRunAtStartUp_CheckedChanged(object sender, EventArgs e)
        {
            const string userRoot = "HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Run";
            string path = Application.ExecutablePath.ToString();

            if (chkRunAtStartUp.Checked)
                Registry.SetValue(userRoot, "Shortcuts", path);
            else
            {
                RegistryKey reg = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                //this.Text = reg.GetValue("Avkomix").ToString();
                reg.DeleteValue("Shortcuts");
                reg.Close();
                //Registry.CurrentUser.DeleteSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\Avkomix");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
