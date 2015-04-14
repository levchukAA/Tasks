using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS
{
    public class GenerateCallEventArgs: EventArgs
    {
        public GenerateCallEventArgs(int port0, int port1)
        {
            Port0 = port0;
            Port1 = port1;
        }
        public int Port0 { get; set; }
        public int Port1 { get; set; }
    }
}
