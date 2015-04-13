using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATS
{
    public class Call
    {
        public Port Port1 { get; set; }
        public Port Port2 { get; set; }
        public int Duration { get; set; }
        public override string ToString()
        {
            return ATS.SearchClient(Port1).Show() + " | " + ATS.SearchClient(Port2).Show() + " | " + Duration;
        }
    }
}

