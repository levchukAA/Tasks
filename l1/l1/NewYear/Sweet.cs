﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewYear
{
    abstract class Sweet: IComparable<Sweet>
    {
        public Sweet() : this("default", 100) { }
        public Sweet(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }
        public string Name { get; set; }
        public int KcalPer100 { get; set; }
        public int Weight { get; set; }
        public int Calories { get { return KcalPer100*Weight; } }
        public int Sugar { get; set; }
        public int CompareTo(Sweet compareSweet)
        {
            if (compareSweet == null)
                return 1;
            else
                return Calories.CompareTo(compareSweet.Calories);
        }

        public override string ToString()
        {
            return Name + " | " + Weight;
        }
    }
}
