using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Salad
    {
        private string _name;
        private List<Ingredient> _ingredients = new List<Ingredient>();
        public Salad(string name)
        {
            this._name = name;
        }

        public double CountCalories()
        {
            double calories = 0.0;
            foreach (Ingredient ingredient in _ingredients)
            {
                calories = calories + ingredient.FullCalories();
            }
            return calories;
        }
    }
}
