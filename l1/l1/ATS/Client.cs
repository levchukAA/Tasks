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
        public Port Port { get; set; }
        public Tariff Tariff { get; set; }
        public string Show()
        {
            return FirstName + " " + LastName;
        }
        public void OnOffTerminal()
        {
            Port.Status = Port.Status == StatusPort.Off ? StatusPort.On : StatusPort.Off;
        }

        public void ChangeTariff(StatusTariff newTariff)
        {
            Tariff.Type = newTariff;
        }
    }
}
