using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    abstract class Ingredient
    {
        private double _weight;
        private string _name;
        private double _calories100;
        private string _category;

        public Ingredient(string name, double calories100, double weight)
        {
            _name = name;
            _weight = weight;
            _calories100 = calories100;
        }

        public double Caloriesl100
        {
            get { return _calories100; }
            set { _calories100 = value; }
        }

        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public double FullCalories()
        {
            return _calories100 * _weight / 100;
        }

        public string Type
        {
            get ; set;
        }

        public string InfoString()
        { 
            return "Name: " + _name + "\n" + "Weight: " + _weight + "\n" + "Count of calories(kcal): "
                + FullCalories();
        }
    }
}
