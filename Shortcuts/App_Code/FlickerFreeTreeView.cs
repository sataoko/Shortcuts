using System;
using System.Collections.Generic;
using System.Text;

namespace Shortcuts
{

    internal class FlickerFreeTreeView : System.Windows.Forms.TreeView
    {
        public FlickerFreeTreeView() : base()
        {
        }

        private const int WM_ERASEBKGND = 0x0014;
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == WM_ERASEBKGND)
            {
                m.Result = IntPtr.Zero;
                return;
            }
            base.WndProc(ref m);
        }
    }
}
