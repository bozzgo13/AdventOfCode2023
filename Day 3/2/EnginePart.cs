using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode_2023_3_2
{
    internal class EnginePart
    {
        public char PartSymbol { get; set; }
        public int XPoz { get; set; }
        public int YPoz { get; set; }
        public List<int> ConnectedNumbers { get; set; }

        public EnginePart( )
        {
            ConnectedNumbers = new List<int>();
        }
    }
}
