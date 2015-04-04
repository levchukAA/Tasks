using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewYear
{
    class Program
    {
        static void Main(string[] args)
        {
            FlourSweet proba = new FlourSweet();
            Gift gift = new Gift();
            gift.Add(proba);
            gift.Sweets.Sort();
        }
    }
}
