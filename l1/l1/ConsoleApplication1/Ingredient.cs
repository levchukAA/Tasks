using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Ingredient
    {
        private double weight;
        private string name;
        private double kcal100g;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Calories
        {
            get { return kcal100g; }
            set { kcal100g = value; }
        }

        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }
    }
}
