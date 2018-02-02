using System;
using System.Collections.Generic;
using System.Text;

namespace Shortcuts
{
    public class Shortcut
    {
        public string ID { get; set; }
        public string Group { get; set; }
        public string Alias { get; set; }
        public string Path { get; set; }
        public string OrderNo { get; set; }
        
        public Shortcut(string path, string alias)
        {
            Path = path;
            Alias = alias;
        }

        public override string ToString()
        {
            return Alias;
        }
    }
}
