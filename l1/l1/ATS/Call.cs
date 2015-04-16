using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATS
{
    public class Call
    {
        public Terminal Port0 { get; set; }
        public Terminal Port1 { get; set; }
        public int Duration { get; set; }

        public override string ToString()
        {
            return ATS.Clients[Port0.Id].FirstName + " " + ATS.Clients[Port0.Id].LastName + " - "
                   + ATS.Clients[Port1.Id].FirstName + " " + ATS.Clients[Port1.Id].LastName + " | " + Duration;
        }
    }
}

