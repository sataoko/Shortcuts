using LiteDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shortcuts.WorkHours
{
    public partial class frmWorkHours : Form
    {
        public frmWorkHours()
        {
            InitializeComponent();
        }

        private void LoadAll()
        {
            using (var db = new LiteDatabase(Application.StartupPath + "\\Data.db"))
            {
                var col = db.GetCollection<WorkBlock>("WorkBlock");
                IEnumerable<WorkBlock> results = col.FindAll();

                foreach (var item in results)
                {
                    dgvWorkHours.Rows.Add(item.BlockStartTime, item.BlockEndTime, item.BlockNo, item.BlockGroup, item.BlockNote);
                }
            }
        }

        private void DeleteAll()
        {
            using (var db = new LiteDatabase(Application.StartupPath + "\\Data.db"))
            {
                var col = db.GetCollection<WorkBlock>("WorkBlock");
                col.Delete(x => x.BlockStartTime < DateTime.Now);
            }
        }

        private void frmWorkHours_Load(object sender, EventArgs e)
        {
            LoadAll();
        }

        private void tsbDeleteAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("All records will be deleted.", "Delete all?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DeleteAll();
                dgvWorkHours.Rows.Clear();
                LoadAll();
            }
        }

        private void tsbExportToCSV_Click(object sender, EventArgs e)
        {
            try
            {
                System.IO.TextWriter tw = new System.IO.StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\WorkHours.csv",false);
                foreach (DataGridViewRow r in dgvWorkHours.Rows)
                {
                    if(r.Cells[0].Value!=null)
                    {
                        string a = r.Cells[0].Value.ToString() ?? string.Empty;
                        string b = r.Cells[1].Value.ToString() ?? string.Empty;
                        string c = r.Cells[2].Value.ToString() ?? string.Empty;
                        string d = r.Cells[3].Value.ToString() ?? string.Empty;
                        string f = r.Cells[4].Value.ToString() ?? string.Empty;

                        tw.WriteLine(a + "," + b + "," + c + "," + d + "," + f);
                    }
                }
                tw.Close();
                MessageBox.Show("CSV is created. Check the desktop.");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
           
        }
    }
}
