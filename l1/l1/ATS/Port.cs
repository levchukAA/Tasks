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
            Id = numberPort;
            Status = StatusPort.On;
        }

        public int Id { get; set; }
        public StatusPort Status { get; set; }

    }
}
