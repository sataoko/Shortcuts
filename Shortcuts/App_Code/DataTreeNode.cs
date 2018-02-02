using System;
using System.Windows.Forms;

namespace Shortcuts
{
	/* Object saklayacak olan TreeNode sýnýfýmýz */
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
