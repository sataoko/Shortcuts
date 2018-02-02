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
    public partial class frmSettings : FormBase
    {

        public frmSettings()
        {
            InitializeComponent();
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

        private void frmSettings_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;

            int x = Screen.GetWorkingArea(this).Width;
            int y = Screen.GetWorkingArea(this).Height;
            this.Location = new Point(x - this.Width - 100, y - this.Height - 100);
            
            object o = Registry.GetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Run", "Shortcuts", null);
            if (o == null) chkRunAtStartUp.Checked = false; else chkRunAtStartUp.Checked = true;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSettings_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#8888cd");

            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                c, 2, ButtonBorderStyle.Solid,
                c, 2, ButtonBorderStyle.Solid,
                c, 2, ButtonBorderStyle.Solid,
                c, 2, ButtonBorderStyle.Solid);
        }
    }
}
