using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATS
{
    public enum StatusTariff
    {
        LowCost,
        Costly
    }

    public class Tariff
    {
        public Tariff()
        {
            Type = StatusTariff.LowCost;
        }
        public StatusTariff Type { get; set; }
        public int Arrear { get; set; }

        public int Cost
        {
            get
            {
                switch (Type)
                {
                    case StatusTariff.LowCost:
                        return 10;
                    case StatusTariff.Costly:
                        return 14;
                    default:
                        return 0;
                }
            } 
            
        }
        public void AddCall(Call call)
        {
            Arrear = Arrear + call.Duration*Cost\60;
        }

        
    }
}
