using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Shortcuts
{
    class ShortcutOperations
    {
        private string _shortcutsFile = string.Empty;
        public string ShortcutsFile
        {
            get { return _shortcutsFile; }
            set { _shortcutsFile = value; }
        }

        private string _startNode = "/Shortcuts/ShortCut";
        public string StartNode
        {
            get { return _startNode; }
            set { _startNode = value; }
        }

        public ShortcutOperations(string shortcutsFile)
        {
            ShortcutsFile = shortcutsFile;
        }

        public void UpdateNodeAliasByID(string nodeID, string newAlias)
        {
            string xmlPath = _shortcutsFile;

            XmlDocument XMLDom = new XmlDocument();
            //load your xml file
            XMLDom.Load(xmlPath);

            XmlNodeList newXMLNodes = XMLDom.SelectNodes(_startNode);
            foreach (XmlNode newXMLNode in newXMLNodes)
                //Updating data where "Node1" is "sree" with "kambham"
                if (newXMLNode["ID"].InnerText == nodeID)
                    newXMLNode["Alias"].InnerText = newAlias;
            XMLDom.Save(xmlPath);
            XMLDom = null;
        }

        public void UpdateNodePathByID(string nodeID, string newPath)
        {
            string xmlPath = _shortcutsFile;

            XmlDocument XMLDom = new XmlDocument();
            //load your xml file
            XMLDom.Load(xmlPath);

            XmlNodeList newXMLNodes = XMLDom.SelectNodes(_startNode);
            foreach (XmlNode newXMLNode in newXMLNodes)
                //Updating data where "Node1" is "sree" with "kambham"
                if (newXMLNode["ID"].InnerText == nodeID)
                    newXMLNode["FilePath"].InnerText = newPath;
            XMLDom.Save(xmlPath);
            XMLDom = null;
        }

        public  void UpdateNodeOrderNoByID(string nodeID, string newOrderNo)
        {
            string xmlPath = _shortcutsFile;

            XmlDocument XMLDom = new XmlDocument();
            //load your xml file
            XMLDom.Load(xmlPath);

            XmlNodeList newXMLNodes = XMLDom.SelectNodes(_startNode);

            foreach (XmlNode newXMLNode in newXMLNodes)
                //Updating data where "Node1" is "sree" with "kambham"
                if (newXMLNode["ID"].InnerText == nodeID)
                    newXMLNode["OrderNo"].InnerText = newOrderNo;
            XMLDom.Save(xmlPath);
            XMLDom = null;
        }

        public void DeleteNodeByID(string nodeID)
        {
            string xmlPath = _shortcutsFile;

            XmlDocument XMLDom = new XmlDocument();
            //load your xml file
            XMLDom.Load(xmlPath);

            XmlNodeList newXMLNodes = XMLDom.SelectNodes(_startNode);
            foreach (XmlNode newXMLNode in newXMLNodes)
                //Updating data where "Node1" is "sree" with "kambham"
                if (newXMLNode["ID"].InnerText == nodeID)
                    newXMLNode.ParentNode.RemoveChild(newXMLNode);
            XMLDom.Save(xmlPath);
            XMLDom = null;
        }

        public string GetOrderNo(XmlDocument xmlDoc)
        {
            XmlNodeList newXMLNodes = xmlDoc.SelectNodes(_startNode);

            int biggestOrderNo = Convert.ToInt16((newXMLNodes.Item(0) as XmlNode)["OrderNo"].InnerText);
            foreach (XmlNode newXMLNode in newXMLNodes)
            {
                int currentOrderNo = Convert.ToInt16(newXMLNode["OrderNo"].InnerText);
                if (currentOrderNo>biggestOrderNo) biggestOrderNo = currentOrderNo;
            }
            biggestOrderNo++;
            return biggestOrderNo.ToString();
        }


        public string ShowBiggestOrderNo()
        {
            string strFilename = _shortcutsFile;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(strFilename);
            XmlNodeList newXMLNodes = xmlDoc.SelectNodes(_startNode);

            int biggestOrderNo = Convert.ToInt16((newXMLNodes.Item(0) as XmlNode)["OrderNo"].InnerText);
            foreach (XmlNode newXMLNode in newXMLNodes)
            {
                //int i = string.Compare(, orderNo,);
                int currentOrderNo = Convert.ToInt16(newXMLNode["OrderNo"].InnerText);
                if (currentOrderNo>biggestOrderNo) biggestOrderNo = currentOrderNo;
            }
            
            return biggestOrderNo.ToString();
        }


        public void AddNewShortcut(string filePath, string alias)
        {
            string strFilename = _shortcutsFile;
            XmlDocument xmlDoc = new XmlDocument();
            if (System.IO.File.Exists(strFilename))
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

        public void ReadXMLShortcuts(System.Windows.Forms.TreeView targetTreeView )
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            string strFilename = _shortcutsFile;
            ds.ReadXml(strFilename);

            if (ds.Tables.Count > 0)
            {
                ds.Tables[0].DefaultView.Sort = "OrderNo";

                System.Data.DataView dv = ds.Tables[0].DefaultView;

                targetTreeView.Nodes.Clear();
                foreach (System.Data.DataRowView dvr in dv)
                {
                    Shortcut s = new Shortcut(dvr["FilePath"].ToString().Trim(), dvr["Alias"].ToString().Trim());
                    s.ID = dvr["ID"].ToString();
                    s.OrderNo = dvr["OrderNo"].ToString();
                    DataTreeNode d = new DataTreeNode(s);
                    targetTreeView.Nodes.Add(d);
                }
            }

        }
    }
}
