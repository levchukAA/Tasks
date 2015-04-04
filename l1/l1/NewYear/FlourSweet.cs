using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewYear
{
    public enum FlourSweetType
    {
        Waffle,
        Cookie,
        Cake
    }
    class FlourSweet: Sweet
    {
        public FlourSweet(string name, int weight, FlourSweetType type) 
            : base(name, weight)
        {
            Type = type;
        }
        public FlourSweetType Type { get; set; }
    }
}
