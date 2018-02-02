using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shortcuts
{
    public class WorkBlock
    {
        public int Id { get; set; }
        public DateTime BlockStartTime { get; set; }
        public DateTime BlockEndTime { get; set; }
        public string BlockGroup { get; set; }
        public int BlockNo { get; set; }
        public string BlockNote { get; set; }
    }
}
