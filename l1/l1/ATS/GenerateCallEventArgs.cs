using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS
{
    public class GenerateCallEventArgs: EventArgs
    {
        public GenerateCallEventArgs(int terminal0, int terminal1)
        {
            Terminal0 = terminal0;
            Terminal1 = terminal1;
        }
        public int Terminal0 { get; set; }
        public int Terminal1 { get; set; }
    }
}
