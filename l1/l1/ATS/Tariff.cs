using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATS
{
    public enum StatusTariff
    {
        Unsociable,
        Default,
        Active
    }

    public class Tariff
    {
        public Tariff(StatusTariff tariff)
        {
            Type = tariff;
            switch (Type)
            {
                case StatusTariff.Unsociable:
                    MonthCost = 10;
                    MinuteCost = 2;
                    break;
                case StatusTariff.Default:
                    MonthCost = 12;
                    MinuteCost = 1;
                    break;
                case StatusTariff.Active:
                    MonthCost = 14;
                    MinuteCost = 0;
                    break;
            }
        }

        public StatusTariff Type { get; set; }
        public int MinuteCost { get; set; }
        public int MonthCost { get; set; }
        public double Arrear { get; set; }
        public int Cost { get; set; }

        public void AddCall(Call call)
        {
            Arrear = Arrear + call.Duration*MinuteCost;
        }

    }
}
