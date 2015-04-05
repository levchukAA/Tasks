using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewYear
{
    public enum ChocoSweetType
    {
        ChocoZephyr,
        Candy,
        Chocolate,
        ChocoHalva
    }
    class ChocoSweet: Sweet
    {
        public ChocoSweet(string name, int weight, int chocoPer100) 
            : base(name, weight)
        {
            Choco = chocoPer100;
        }

        public ChocoSweet()
        {
            Name = "";
        }
        
        public int Choco { get; set; }
        public ChocoSweetType Type { get; set; }
        public override double SpecialProp { get { return Weight/100*Choco; } }
        public override void Show()
        {
            string info = "Name: " + Name + "; " + "Calories: " + Calories + "; "
                 + "Choco in 100: " + Choco + "; " + "Sugar in 100: " + SugarPer100; ;
            Console.WriteLine(info);
        }



        
    }
}
