using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewYear
{
    public enum SugarySweetType
    {
        Zephyr,
        Marzipan,
        Candy,
        Chocolate,
        Halva
    }
    class SugarySweet: Sweet
    {
        public SugarySweet(string name, int weight, SugarySweetType type) 
            : base(name, weight)
        {
            Type = type;
        }
        public SugarySweetType Type { get; set; }
    }
}
