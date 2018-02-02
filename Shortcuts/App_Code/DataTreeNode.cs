using System;
using System.Windows.Forms;

namespace Shortcuts
{
	/* Object saklayacak olan TreeNode s�n�f�m�z */
	public class DataTreeNode : TreeNode
	{
		object data;

		public DataTreeNode( object data ) : base ( data.ToString() )
		{
			this.data = data;
		}
    
		public object Data
		{
			get { return data; }
		}
	}
}
