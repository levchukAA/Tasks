using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    abstract class Ingredient
    {
        private double weight;
        private string name;
        private double calories100;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Caloriesl100
        {
            get { return calories100; }
            set { calories100 = value; }
        }

        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public double FullCalories()
        {
            return calories100 * weight / 100;
        }

        public string InfoString()
        { 
            return "Name: " + name + "\n" + "Weight: " + weight + "\n" + "Count of calories(kcal): "
                + FullCalories();
        }
    }
}
