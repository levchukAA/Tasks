using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATS
{
    public enum StatusPort
    {
        On,
        Off,
        Busy
    }
    public class Port
    {
        public Port(int numberPort)
        {
            NumberPort = numberPort;
            Status = StatusPort.On;
        }
        public int NumberPort { get; set; }
        public StatusPort Status { get; set; }
    }
}
