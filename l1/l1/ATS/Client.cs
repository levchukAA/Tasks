using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATS
{
    public class Client
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Number { get; set; }
        public Terminal Terminal { get; set; }
        public Tariff Tariff { get; set; }

        
        

        public string Show()
        {
            return FirstName + " " + LastName + " | " + Number + " | " + Terminal.Id + " | " +
                   Tariff.Type;
        }

        public void MyCalls(Client client)
        {
            string myCalls = "Calls " + FirstName + " " + LastName + ":\r\n";
            ATS.Calls.Where(call => (client.Terminal == call.Port0) || (client.Terminal == call.Port1)).
                Aggregate(myCalls, (current, call) => current + call.ToString() + "\r\n");
        }

        public void OnOffTerminal()
        {
            Terminal.Status = Terminal.Status == StatusPort.Off ? StatusPort.On : StatusPort.Off;
        }

        public void ChangeTariff(StatusTariff newTariff)
        {
            Tariff.Type = newTariff;
        }


        
        
    }
}
