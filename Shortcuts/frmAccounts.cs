using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Shortcuts
{
    public partial class frmAccounts : Form
    {
        public static void LoadXmlToGrid(System.Windows.Forms.DataGridView grid, string fileName, string tableName)
        {
            if (System.IO.File.Exists(fileName))
            {
                System.Data.DataSet ds = new System.Data.DataSet("Accounts");
                ds.ReadXml(fileName);
                grid.DataSource = ds;
                grid.DataMember = tableName;
            }
        }

        public static void SaveGridToXml(System.Windows.Forms.DataGridView grid, string fileName)
        {
            string path = System.Windows.Forms.Application.StartupPath + "\\data.xml";
            System.Data.DataSet dataSet = (System.Data.DataSet)grid.DataSource;
            dataSet.WriteXml(fileName);
        }


        public frmAccounts()
        {
            InitializeComponent();
        }
    }
}
