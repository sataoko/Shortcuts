using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace Shortcuts
{
    public partial class frmMain : FormBase
    {
        ShortcutOperations _shortcutOperations1;
        ShortcutOperations _shortcutOperations2;
        ShortcutOperations _shortcutOperations3;
        TreeNode sourceNode;

        int xOffset = 5;
        int yOffset = 5;

        int yCounter = 0;

        bool closeWindow = false;

        public string groupSplitter = "-----------------";

        private void MakeEffect(int period)
        {
            //this.Opacity = 0;
            int x = Screen.GetWorkingArea(this).Width;
            int y = Screen.GetWorkingArea(this).Height;
            this.Location = new Point(x - this.Width - xOffset, y + 10);

            tmrEffect.Interval = period;
            tmrEffect.Enabled = true;
            tmrEffect.Start();
        }

        private void MakeEffect(int period, int yCounterStartValue, bool closeWindowState)
        {
            //this.Opacity = 0;

            yCounter = yCounterStartValue;
            closeWindow = closeWindowState;

            int x = Screen.GetWorkingArea(this).Width;
            int y = Screen.GetWorkingArea(this).Height;

            if (closeWindow)
            {

            }
            else
            {
                this.Location = new Point(x - this.Width - xOffset, y + 10);
            }


            tmrEffect.Interval = period;
            tmrEffect.Enabled = true;
            tmrEffect.Start();
        }

        private void RunProcess(string path, bool hideMainWindow)
        {
            System.Diagnostics.Process.Start(path);
            if (hideMainWindow) this.Hide();
        }

        private void RunProcess(string path, bool hideMainWindow, string parameters)
        {
            System.Diagnostics.Process.Start(path,parameters);
            if (hideMainWindow) this.Hide();
        }


        #region frmMain METHODS

        public frmMain()
        {
            this.ExcludeList += "trvShortcuts";
            this.ExcludeList += "trvShortcuts2";
            this.ExcludeList += "trvShortcuts3";
            InitializeComponent();
        }

        // Form load event or a similar place
        private void frmMain_Load(object sender, EventArgs e)
        {
            // this.Visible = false;
            this.Hide();
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.None;

            int x = Screen.GetWorkingArea(this).Width;
            int y = Screen.GetWorkingArea(this).Height;
            this.Location = new Point(x - this.Width - xOffset, y - this.Height - yOffset);

            Color c = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");// #F4FEFF
            this.BackColor = c;
            this.trvShortcuts.BackColor = c;
            this.trvShortcuts2.BackColor = c;
            this.trvShortcuts3.BackColor = c;

            this.Show();

            // Enable drag and drop for this form
            // (this can also be applied to any controls)
            this.AllowDrop = true;

            // Add event handlers for the drag & drop functionality
            this.DragEnter += new DragEventHandler(frmMain_DragEnter);
            this.DragDrop += new DragEventHandler(frmMain_DragDrop);

            trvShortcuts.AllowDrop = true;
            trvShortcuts.DragEnter += new DragEventHandler(trvShortcuts_DragEnter);
            trvShortcuts.DragDrop += new DragEventHandler(trvShortcuts_DragDrop);

            trvShortcuts2.AllowDrop = true;
            trvShortcuts2.DragEnter += new DragEventHandler(trvShortcuts2_DragEnter);
            trvShortcuts2.DragDrop += new DragEventHandler(trvShortcuts2_DragDrop);


            trvShortcuts3.AllowDrop = true;
            trvShortcuts3.DragEnter += new DragEventHandler(trvShortcuts3_DragEnter);
            trvShortcuts3.DragDrop += new DragEventHandler(trvShortcuts3_DragDrop);

            //ReadXMLShortcuts();

            _shortcutOperations1 = new ShortcutOperations(Application.StartupPath + "\\Shortcuts.xml");
            _shortcutOperations1.ReadXMLShortcuts(trvShortcuts);

            _shortcutOperations2 = new ShortcutOperations(Application.StartupPath + "\\Shortcuts2.xml");
            _shortcutOperations2.ReadXMLShortcuts(trvShortcuts2);

            _shortcutOperations3 = new ShortcutOperations(Application.StartupPath + "\\Shortcuts3.xml");
            _shortcutOperations3.ReadXMLShortcuts(trvShortcuts3);

            /*string bgFile = Application.StartupPath + "\\background.png";
            if (File.Exists(bgFile))
            this.BackgroundImage = Bitmap.FromFile(bgFile);*/


            //SET KEYBOARD HOOK
            //actHook = new UserActivityHook(true, false); // create an instance
            //actHook.OnMouseActivity += new MouseEventHandler(MouseMoved);
            //actHook.KeyDown += new KeyEventHandler(MyKeyDown);
            //actHook.KeyPress += new KeyPressEventHandler(MyKeyPress);
            //actHook.KeyUp += new KeyEventHandler(MyKeyUp);

            //   MakeEffect(50);

            object o = Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Run", "Shortcuts", null);
            if (o == null) 
            {
                frmIntro z = new frmIntro();
                z.ShowDialog();
            }
        }

        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            //System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#424242");

            //ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
            //    c, 1, ButtonBorderStyle.Solid,
            //    c, 1, ButtonBorderStyle.Solid,
            //    c, 1, ButtonBorderStyle.Solid,
            //    c, 1, ButtonBorderStyle.Solid);

         /*   System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#8888cd");

            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                c, 1, ButtonBorderStyle.Solid,
                c, 1, ButtonBorderStyle.Solid,
                c, 1, ButtonBorderStyle.Solid,
                c, 1, ButtonBorderStyle.Solid);*/
        }

        #endregion

        #region FORM DRAG-DROP METHODS FOR FILE DROP

        // This event occurs when the user drags over the form with 
        // the mouse during a drag drop operation 
        void frmMain_DragEnter(object sender, DragEventArgs e)
        {
            // Check if the Dataformat of the data can be accepted
            // (we only accept file drops from Explorer, etc.)
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy; // Okay
            else
                e.Effect = DragDropEffects.None; // Unknown data, ignore it

        }
        // Occurs when the user releases the mouse over the drop target 
        void frmMain_DragDrop(object sender, DragEventArgs e)
        {
            // Extract the data from the DataObject-Container into a string list
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            // Do something with the data...

            // For example add all files into a simple label control:
            foreach (string File in FileList)
            {
                frmNewShortcut x = new frmNewShortcut();
                x.Path = File;
                if (x.ShowDialog() == DialogResult.OK)
                {
                    AddNewShortcut(x.Path, x.Alias);
                    ReadXMLShortcuts();
                }
            }

            // this.label.Text += File + "\n";
        }

        #endregion

        #region HOOK METHODS
        public void MouseMoved(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                this.Location = new Point(e.X, e.Y);
                this.Visible = true;
                this.Show();
                lblStatus.Text = "middle click";
            }
        }

        public void MyKeyDown(object sender, KeyEventArgs e)
        {
            lblStatus.Text = e.KeyCode.ToString();
        }

        public void MyKeyPress(object sender, KeyPressEventArgs e)
        {

        }

        public void MyKeyUp(object sender, KeyEventArgs e)
        {
            /*if (e.KeyCode == Keys.B) MessageBox.Show("B is up");
            if (e.KeyCode == Keys.F12) MessageBox.Show("Ctrl is up");*/
        }

        #endregion

        #region LOCAL SHORTCUT OPERATIONS

        private void UpdateNodeAliasByID(string nodeID, string newAlias)
        {
            string xmlPath = "Shortcuts.xml";

            XmlDocument XMLDom = new XmlDocument();
            //load your xml file
            XMLDom.Load(xmlPath);

            XmlNodeList newXMLNodes = XMLDom.SelectNodes("/Shortcuts/ShortCut");
            foreach (XmlNode newXMLNode in newXMLNodes)
                //Updating data where "Node1" is "sree" with "kambham"
                if (newXMLNode["ID"].InnerText == nodeID)
                    newXMLNode["Alias"].InnerText = newAlias;
            XMLDom.Save(xmlPath);
            XMLDom = null;
        }

        private void UpdateNodeOrderNoByID(string nodeID, string newOrderNo)
        {
            string xmlPath = "Shortcuts.xml";

            XmlDocument XMLDom = new XmlDocument();
            //load your xml file
            XMLDom.Load(xmlPath);

            XmlNodeList newXMLNodes = XMLDom.SelectNodes("/Shortcuts/ShortCut");

            foreach (XmlNode newXMLNode in newXMLNodes)
                //Updating data where "Node1" is "sree" with "kambham"
                if (newXMLNode["ID"].InnerText == nodeID)
                    newXMLNode["OrderNo"].InnerText = newOrderNo;
            XMLDom.Save(xmlPath);
            XMLDom = null;
        }

        private void DeleteNodeByID(string nodeID)
        {
            string xmlPath = "Shortcuts.xml";

            XmlDocument XMLDom = new XmlDocument();
            //load your xml file
            XMLDom.Load(xmlPath);

            XmlNodeList newXMLNodes = XMLDom.SelectNodes("/Shortcuts/ShortCut");
            foreach (XmlNode newXMLNode in newXMLNodes)
                //Updating data where "Node1" is "sree" with "kambham"
                if (newXMLNode["ID"].InnerText == nodeID)
                    newXMLNode.ParentNode.RemoveChild(newXMLNode);
            XMLDom.Save(xmlPath);
            XMLDom = null;
        }

        private string GetOrderNo(XmlDocument xmlDoc)
        {
            XmlNodeList newXMLNodes = xmlDoc.SelectNodes("/Shortcuts/ShortCut");

            string orderNo = (newXMLNodes.Item(0) as XmlNode)["OrderNo"].InnerText;
            foreach (XmlNode newXMLNode in newXMLNodes)
            {
                int i = string.Compare(newXMLNode["OrderNo"].InnerText, orderNo);

                if (i > 0) orderNo = newXMLNode["OrderNo"].InnerText;
            }

            int newOrderNo = Convert.ToInt16(orderNo);
            newOrderNo++;
            return newOrderNo.ToString();
        }

        private void AddNewShortcut(string filePath, string alias)
        {
            string strFilename = "Shortcuts.xml";
            XmlDocument xmlDoc = new XmlDocument();
            if (File.Exists(strFilename))
            {
                xmlDoc.Load(strFilename);

                XmlElement elmRoot = xmlDoc.DocumentElement;
                XmlElement shortCut = xmlDoc.CreateElement("ShortCut");

                //FIELDS
                XmlElement idNode = xmlDoc.CreateElement("ID");
                idNode.InnerText = DateTime.Now.ToBinary().ToString();
                XmlElement filePathNode = xmlDoc.CreateElement("FilePath");
                filePathNode.InnerText = filePath;
                XmlElement aliasNode = xmlDoc.CreateElement("Alias");
                aliasNode.InnerText = alias;

                XmlElement orderNo = xmlDoc.CreateElement("OrderNo");
                orderNo.InnerText = GetOrderNo(xmlDoc);

                shortCut.AppendChild(idNode);
                shortCut.AppendChild(filePathNode);
                shortCut.AppendChild(aliasNode);
                shortCut.AppendChild(orderNo);

                elmRoot.AppendChild(shortCut);
                xmlDoc.Save(strFilename);
            }

        }

        private void ReadXMLShortcuts()
        {
            DataSet ds = new DataSet();
            string strFilename = "Shortcuts.xml";
            ds.ReadXml(strFilename);

            ds.Tables[0].DefaultView.Sort = "OrderNo";

            DataView dv = ds.Tables[0].DefaultView;

            trvShortcuts.Nodes.Clear();
            foreach (DataRowView dvr in dv)
            {
                Shortcut s = new Shortcut(dvr["FilePath"].ToString().Trim(), dvr["Alias"].ToString().Trim());
                s.ID = dvr["ID"].ToString();
                s.OrderNo = dvr["OrderNo"].ToString();
                DataTreeNode d = new DataTreeNode(s);
                trvShortcuts.Nodes.Add(d);
            }

        }


        #endregion

        private void AddNewShortcutOnDragDrop(TreeView senderTreeView, DragEventArgs e, ShortcutOperations shortcutOperations)
        {
            // Extract the data from the DataObject-Container into a string list
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            // Do something with the data...

            // For example add all files into a simple label control:
            foreach (string File in FileList)
            {
                frmNewShortcut x = new frmNewShortcut();
                x.Path = File;
                if (x.ShowDialog() == DialogResult.OK)
                {
                    shortcutOperations.AddNewShortcut(x.Path, x.Alias);
                }
            }

            shortcutOperations.ReadXMLShortcuts(senderTreeView);
        }

        private void UpdateShortcut(TreeView targetTreeView, int treeViewNo)
        {
            if (targetTreeView.SelectedNode != null)
            {
                DataTreeNode node = (DataTreeNode)targetTreeView.SelectedNode;
                string nodeID = (node.Data as Shortcut).ID;

                frmUpdateShortcut x = new frmUpdateShortcut();
                x.ShortcutAlias = (node.Data as Shortcut).Alias;
                x.ShortcutPath = (node.Data as Shortcut).Path;

                if (x.ShowDialog() == DialogResult.OK)
                {
                    switch (treeViewNo)
                    {
                        case 1:
                            _shortcutOperations1.UpdateNodeAliasByID(nodeID, x.ShortcutAlias);
                            _shortcutOperations1.UpdateNodePathByID(nodeID, x.ShortcutPath);
                            _shortcutOperations1.ReadXMLShortcuts(targetTreeView);
                            break;
                        case 2:
                            _shortcutOperations2.UpdateNodeAliasByID(nodeID, x.ShortcutAlias);
                            _shortcutOperations2.UpdateNodePathByID(nodeID, x.ShortcutPath);
                            _shortcutOperations2.ReadXMLShortcuts(targetTreeView);
                            break;
                    }

                }
            }

        }

        public static bool IsValidHttpUri(string uriString)
        {
            Uri test = null;
            return Uri.TryCreate(uriString, UriKind.Absolute, out test) && (test.Scheme == "http" || test.Scheme == "https");
            //return Uri.TryCreate(uriString, UriKind.RelativeOrAbsolute, out test);
        }

        private void RunTargetFile(string filePath)
        {
            try
            {
                System.Diagnostics.Process.Start(filePath);
                this.Hide();
            }
            catch (IOException exp)
            {
                MessageBox.Show(exp.ToString());
            }

        }

        private void RunSelectedNodesShortcut(TreeView targetTreeView)
        {
            string errorMessage = string.Empty;

            if (targetTreeView.SelectedNode != null)
            {
                DataTreeNode node = (DataTreeNode)targetTreeView.SelectedNode;
                string targetFilePath = (node.Data as Shortcut).Path;

                if (!string.IsNullOrEmpty(targetFilePath) && (targetFilePath != "-"))
                {
                    if (Directory.Exists(targetFilePath)) { RunTargetFile(targetFilePath); return; }
                    else if (File.Exists(targetFilePath)) { RunTargetFile(targetFilePath); return; }
                    else if (IsValidHttpUri(targetFilePath)) { RunTargetFile(targetFilePath); return; }
                    else MessageBox.Show("File or folder not found or not valid URL. \n\n " + targetFilePath);
                }
            }

        }

        #region TREEVIEW METHODS 1

        private void trvShortcuts_ItemDrag(object sender, ItemDragEventArgs e)
        {
            sourceNode = (TreeNode)e.Item;
            DoDragDrop(e.Item.ToString(), DragDropEffects.Move | DragDropEffects.Copy);
        }

        private void trvShortcuts_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None; // Unknown data, ignore it
        }

        private void trvShortcuts_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                AddNewShortcutOnDragDrop(trvShortcuts, e, _shortcutOperations1);
            else
            {
                Point pos = trvShortcuts.PointToClient(new Point(e.X, e.Y));
                TreeNode targetNode = trvShortcuts.GetNodeAt(pos);

                if (targetNode != null)
                {
                    DataTreeNode node = (DataTreeNode)targetNode;
                    string targetOrderNo = (node.Data as Shortcut).OrderNo;

                    DataTreeNode node2 = (DataTreeNode)sourceNode;
                    string sourceOrderNo = (node2.Data as Shortcut).OrderNo;

                    _shortcutOperations1.UpdateNodeOrderNoByID((node.Data as Shortcut).ID, sourceOrderNo);
                    _shortcutOperations1.UpdateNodeOrderNoByID((node2.Data as Shortcut).ID, targetOrderNo);
                    _shortcutOperations1.ReadXMLShortcuts(trvShortcuts);
                }
            }
        }




        #endregion

        #region TREEVIEW METHODS 2

        void trvShortcuts2_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                AddNewShortcutOnDragDrop(trvShortcuts2, e, _shortcutOperations2);
            else
            {
                Point pos = trvShortcuts2.PointToClient(new Point(e.X, e.Y));
                TreeNode targetNode = trvShortcuts2.GetNodeAt(pos);

                if (targetNode != null)
                {
                    DataTreeNode node = (DataTreeNode)targetNode;
                    string targetOrderNo = (node.Data as Shortcut).OrderNo;

                    DataTreeNode node2 = (DataTreeNode)sourceNode;
                    string sourceOrderNo = (node2.Data as Shortcut).OrderNo;

                    _shortcutOperations2.UpdateNodeOrderNoByID((node.Data as Shortcut).ID, sourceOrderNo);
                    _shortcutOperations2.UpdateNodeOrderNoByID((node2.Data as Shortcut).ID, targetOrderNo);
                    _shortcutOperations2.ReadXMLShortcuts(trvShortcuts2);
                }
            }
        }

        void trvShortcuts2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None; // Unknown data, ignore it
        }

        private void trvShortcuts2_ItemDrag(object sender, ItemDragEventArgs e)
        {
            sourceNode = (TreeNode)e.Item;
            DoDragDrop(e.Item.ToString(), DragDropEffects.Move | DragDropEffects.Copy);
        }

        #endregion TREEVIEW METHODS 2

        #region TREEVIEW METHODS 3
        void trvShortcuts3_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                AddNewShortcutOnDragDrop(trvShortcuts3, e, _shortcutOperations3);
            else
            {
                Point pos = trvShortcuts3.PointToClient(new Point(e.X, e.Y));
                TreeNode targetNode = trvShortcuts3.GetNodeAt(pos);

                if (targetNode != null)
                {
                    DataTreeNode node = (DataTreeNode)targetNode;
                    string targetOrderNo = (node.Data as Shortcut).OrderNo;

                    DataTreeNode node2 = (DataTreeNode)sourceNode;
                    string sourceOrderNo = (node2.Data as Shortcut).OrderNo;

                    _shortcutOperations3.UpdateNodeOrderNoByID((node.Data as Shortcut).ID, sourceOrderNo);
                    _shortcutOperations3.UpdateNodeOrderNoByID((node2.Data as Shortcut).ID, targetOrderNo);
                    _shortcutOperations3.ReadXMLShortcuts(trvShortcuts3);
                }
            }
        }

        void trvShortcuts3_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None; // Unknown data, ignore it
        }

        private void trvShortcuts3_ItemDrag(object sender, ItemDragEventArgs e)
        {
            sourceNode = (TreeNode)e.Item;
            DoDragDrop(e.Item.ToString(), DragDropEffects.Move | DragDropEffects.Copy);
        }

        #endregion TREEVIEW METHODS 3

        private void RemoveShortcutFromTree(TreeView targetTreeView, ShortcutOperations shortcutOperations)
        {
            if (targetTreeView.SelectedNode != null)
            {
                DataTreeNode node = (DataTreeNode)targetTreeView.SelectedNode;

                string nodeID = (node.Data as Shortcut).ID;
                shortcutOperations.DeleteNodeByID(nodeID);
                shortcutOperations.ReadXMLShortcuts(targetTreeView);
            }

        }
                
        private void cmiClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            MakeEffect(1, this.Height + yOffset, true);
        }

        private void cmiAbout_Click(object sender, EventArgs e)
        {
            frmAbout x = new frmAbout();
            x.ShowDialog();
        }

        private void cmiSettings_Click(object sender, EventArgs e)
        {
            frmSettings x = new frmSettings();
            x.ShowDialog();
        }

        private void trvShortcuts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            RunSelectedNodesShortcut(trvShortcuts);
        }

        private void trvShortcuts2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            RunSelectedNodesShortcut(trvShortcuts2);
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_shortcutOperations2.ShowBiggestOrderNo());
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.Visible)
                {
                    //  MessageBox.Show("Visible");
                    MakeEffect(5, this.Height + yOffset, true);
                }
                else
                {
                    //  MessageBox.Show("not Visible");
                    MakeEffect(5, 0, false);
                    this.Show();
                }
            }
        }

        private void tmrEffect_Tick(object sender, EventArgs e)
        {
            //if (this.Opacity != 1) this.Opacity += 0.1; else { tmrEffect.Enabled = false; }
            if (closeWindow)
            {
                if (yCounter > 0)
                {
                    Point p = new Point(Screen.GetWorkingArea(this).Width - this.Width - xOffset, Screen.GetWorkingArea(this).Height - yCounter);
                    //Point p = new Point(1920 - this.Width - xOffset, 1080 - yCounter);
                    this.Location = p;
                    yCounter -= 40;

                }
                else
                {
                    tmrEffect.Enabled = false;
                    this.Hide();
                }
            }
            else
            {
                if (yCounter < (this.Height + yOffset + 1))
                {
                    Point p = new Point(Screen.GetWorkingArea(this).Width - this.Width - xOffset, Screen.GetWorkingArea(this).Height - yCounter);
                    //Point p = new Point(1920 - this.Width - xOffset, 1080 - yCounter);
                    this.Location = p;
                    yCounter += 45;

                }
                else
                {
                    tmrEffect.Enabled = false; yCounter = 0;
                    Point p = new Point(Screen.GetWorkingArea(this).Width - this.Width - xOffset, Screen.GetWorkingArea(this).Height - this.Height - yOffset);
                    this.Location = p;
                }
            }

        }

        private void tmrClose_Tick(object sender, EventArgs e)
        {
            this.Hide();
            tmrClose.Enabled = false;
        }

   /*     private void lnkOpenControlPanel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("appwiz.cpl");
        }

        private void lnkOpenSystemProperty_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //System.Diagnostics.Process.Start("sysdm.cpl ");//system
            //System.Diagnostics.Process.Start("desk.cpl ");//system
            //System.Diagnostics.Process.Start("Inetcpl.cpl");
            System.Diagnostics.Process.Start("ncpl.cpl");

        }*/

        private void cmiSystemSettings_Click(object sender, EventArgs e)
        {
            
        }

        private void cmiDisplaySettings_Click(object sender, EventArgs e)
        {
            
        }

        private void cmiPrograms_Click(object sender, EventArgs e)
        {
            RunProcess("Appwiz.cpl", false);
        }

        private void cmiInternetSettings_Click(object sender, EventArgs e)
        {
            
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }


        #region RUN PROCESS RIGHT CLICK MENU
        private void cmiNetworkSettings_Click(object sender, EventArgs e)
        {
            
        }

        private void cmiLocalAreaConnection_Click(object sender, EventArgs e)
        {
            RunProcess("nusrmgr.cpl", false);
            //System.Diagnostics.ProcessStartInfo proc = new System.Diagnostics.ProcessStartInfo();
            //proc.FileName = @"C:\\Windows\\System32\\RunDll32.exe";
            //proc.Arguments = "shell32.dll,Control_RunDLL inetcpl.cpl,Internet,4";
            //System.Diagnostics.Process.Start(proc);
            //SendKeys.Send("{TAB}{TAB}{TAB}{TAB}{ENTER}");
        }

        private void tsbPBrush_Click(object sender, EventArgs e)
        {
            RunProcess("PBrush.exe", false);
        }

        private void cmiCalculator_Click(object sender, EventArgs e)
        {
            RunProcess("Calc.exe", false);
        }

        private void cmiCommandPrompt_Click(object sender, EventArgs e)
        {
            RunProcess("cmd.exe", false);
        }

        private void cmiDownloads_Click(object sender, EventArgs e)
        {
            //string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //string pathDownload = Path.Combine(pathUser, "Downloads");
            RunProcess("shell:Downloads", false);
        }

        private void cmiDesktop_Click(object sender, EventArgs e)
        {
            RunProcess("shell:Desktop", false);
        }

        private void cmiSystemInfo_Click(object sender, EventArgs e)
        {
            frmSystemInfo x = new frmSystemInfo();
            x.ShowDialog();
        }

        #endregion



        private void cmiAddShortcut1_Click(object sender, EventArgs e)
        {
            frmNewShortcut x = new frmNewShortcut();
            if (x.ShowDialog() == DialogResult.OK)
            {
                _shortcutOperations1.AddNewShortcut(x.Path, x.Alias);
                _shortcutOperations1.ReadXMLShortcuts(trvShortcuts);
            }
        }

        private void cmiUpdateSelectedShortcut1_Click(object sender, EventArgs e)
        {
            UpdateShortcut(trvShortcuts, 1);
        }

        private void cmiRemoveSelectedShortcut1_Click(object sender, EventArgs e)
        {
            RemoveShortcutFromTree(trvShortcuts, _shortcutOperations1);
        }

        private void cmiAddGroup1_Click(object sender, EventArgs e)
        {
            _shortcutOperations1.AddNewShortcut("-", groupSplitter);
            _shortcutOperations1.ReadXMLShortcuts(trvShortcuts);
        }

        private void cmiAddShortcut2_Click(object sender, EventArgs e)
        {
            frmNewShortcut x = new frmNewShortcut();
            if (x.ShowDialog() == DialogResult.OK)
            {
                _shortcutOperations2.AddNewShortcut(x.Path, x.Alias);
                _shortcutOperations2.ReadXMLShortcuts(trvShortcuts2);
            }
        }

        private void cmiUpdateSelectedShortcut2_Click(object sender, EventArgs e)
        {
            UpdateShortcut(trvShortcuts2, 2);
        }

        private void cmiRemoveSelectedShortcut2_Click(object sender, EventArgs e)
        {
            RemoveShortcutFromTree(trvShortcuts2, _shortcutOperations2);
        }

        private void cmiAddGroup2_Click(object sender, EventArgs e)
        {
            _shortcutOperations2.AddNewShortcut("-", groupSplitter);
            _shortcutOperations2.ReadXMLShortcuts(trvShortcuts2);
        }

        private void cmiRemoveTextFormat_Click(object sender, EventArgs e)
        {
            frmRemoveTextFormat x = new frmRemoveTextFormat();
            x.ShowDialog();
        }


        #region RUN PROCESS VIA ICONS
        private void picRunMyComputer_Click(object sender, EventArgs e)
        {
            RunProcess("explorer",true, "/root,");
        }

        private void picRunDesktop_Click(object sender, EventArgs e)
        {
            RunProcess("shell:Desktop",true);
        }

        private void picRunPBrush_Click(object sender, EventArgs e)
        {
            RunProcess("PBrush.exe",true);
        }
        #endregion

        private void picRunCalculator_Click(object sender, EventArgs e)
        {
            RunProcess("Calc.exe", true);
            
        }

        private void picCommandPrompt_Click(object sender, EventArgs e)
        {
            RunProcess("cmd.exe", true);
        }

        private void picDownloads_Click(object sender, EventArgs e)
        {
            RunProcess("shell:Downloads",true);
        }

        private void picNetwork_Click(object sender, EventArgs e)
        {
            RunProcess("Ncpa.cpl",true);
        }

        private void picSnippingTool_Click(object sender, EventArgs e)
        {
            RunProcess("SnippingTool.exe",true);
        }

        private void picC_Drive_Click(object sender, EventArgs e)
        {
            RunTargetFile("C:\\");
        }

        private void cmiServices_Click(object sender, EventArgs e)
        {
            RunProcess("services.msc",true);
        }

        #region  SELECT ON RIGHT MOUSE CLICK
        private void trvShortcuts_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            trvShortcuts.SelectedNode = e.Node;
        }

        private void trvShortcuts2_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            trvShortcuts2.SelectedNode = e.Node;
        }
        #endregion

        private void cmiExchangeRatesCalculator_Click(object sender, EventArgs e)
        {
            frmExchangeRatesCalculator x = new frmExchangeRatesCalculator();
            x.Show();
            this.Hide();
        }

        private void cmiStickyNotes_Click(object sender, EventArgs e)
        {
            //RunProcess(Path.GetPathRoot(Environment.SystemDirectory) + "Windows\\system32\\stikynot",true);
            RunProcess("C:\\Windows\\Sysnative\\StikyNot.exe", true);
            
        }

        private void cmiComputerManagement_Click(object sender, EventArgs e)
        {
            RunProcess("compmgmt.msc",true);
        }

        private void cmiPerformanceMonitor_Click(object sender, EventArgs e)
        {
            
        }

        private void cmiDeviceManager_Click(object sender, EventArgs e)
        {
           RunProcess("devmgmt.msc",true);
        }

        private void cmiDiskManager_Click(object sender, EventArgs e)
        {
            RunProcess("diskmgmt.msc",true);
        }

        private void cmiTaskManager_Click(object sender, EventArgs e)
        {
            RunProcess("taskmgr", true);
        }

        private void cmiControlPanel_Click(object sender, EventArgs e)
        {
            RunProcess("control", true);
        }

        private void cmiAdministrativeTools_Click(object sender, EventArgs e)
        {
            RunProcess(Path.GetPathRoot(Environment.SystemDirectory)+ "Windows\\system32\\control",true,"admintools");
            this.Hide();
        }

        private void tsmInternetSettings_Click(object sender, EventArgs e)
        {
            RunProcess("Inetcpl.cpl", false);
        }

        private void tsmDisplaySettings_Click(object sender, EventArgs e)
        {
            RunProcess("desk.cpl", false);
        }

        private void tsmSystemSettings_Click(object sender, EventArgs e)
        {
            RunProcess("sysdm.cpl", false);
        }

        private void tsmNetworkSettings_Click(object sender, EventArgs e)
        {
            RunProcess("Ncpa.cpl", false);
        }

        private void tsmPerformanceMonitor_Click(object sender, EventArgs e)
        {
            RunProcess("perfmon.msc", true);
        }

        private void tsmOnScreenKeyboard_Click(object sender, EventArgs e)
        {
            RunProcess("osk", true);
        }

        private void cmiTools_Click(object sender, EventArgs e)
        {
            
        }

        private void tsmCharMap_Click(object sender, EventArgs e)
        {
            RunProcess("charmap", true);
        }

        private void tsmScreenRuler_Click(object sender, EventArgs e)
        {
            Ruler x = new Ruler();
            x.Show();
        }

        private void tsmTomatoTimer_Click(object sender, EventArgs e)
        {
            frmPomodoroTimer x = new frmPomodoroTimer();
            x.Show();
        }

        private void miPomodoroTimer_Click(object sender, EventArgs e)
        {
            frmPomodoroTimer x = new frmPomodoroTimer();
            x.Show();
        }

       
    }
}
