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
    public class FlourSweet: Sweet
    {
        public FlourSweet(string name, int weight, int flourPer100) 
            : base(name, weight)
        {
            Flour = flourPer100;
        }

        public FlourSweet()
        {
            Name = "";
        }

        public int Flour { get; set; }
        public FlourSweetType Type { get; set; }
        public override double SpecialProp { get { return Weight / 100 * Flour; } }

        public override void Show()
        {
            var info = "Name: " + Name + "; " + "Calories: " + Calories + "; "
                 + "Flour in 100: " + Flour + "; " + "Sugar in 100: " + SugarPer100;
            Console.WriteLine(info);
        }
    }
}
