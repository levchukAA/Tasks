﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewYear
{
    public enum ChocoSweetType: int
    {
        ChocoZephyr = 10,
        Candy = 12,
        Chocolate = 20,
        ChocoHalva = 6
    }

    public class ChocoSweet : Sweet
    {
        private ChocoSweetType _type;

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

        public ChocoSweetType Type
        {
            get { return _type; }
            set
            {
                _type = value;
                Choco = (int) Type;
            }
        }

        public override double SpecialProp
        {
            get { return Weight/100*Choco; }
        }

        public override void Show()
        {
            var info = "Name: " + Name + "; " + "Calories: " + Calories + "; "
                       + "Choco in 100: " + Choco + "; " + "Sugar in 100: " + SugarPer100;
            Console.WriteLine(info);
        }
    }
}
