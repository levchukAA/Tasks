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
            Gift gift = new Gift("Gift.txt");
            gift.Show();
            gift.Sweets.Sort();
            Console.WriteLine("After sort gift by calories: ");
            gift.Show();
            gift.SearchSweet(10, 20);
        }
    }
}
