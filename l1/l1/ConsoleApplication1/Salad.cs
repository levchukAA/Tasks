using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Salad
    {
        private string name;
        private List<Ingredient> ingredients = new List<Ingredient>();
        public Salad(string name)
        {
            this.name = name;
        }

        public double CountCalories()
        {
            double calories = 0.0;
            foreach (Ingredient ingredient in ingredients)
            {
                calories = calories + ingredient.FullCalories();
            }
            return calories;
        }
    }
}
