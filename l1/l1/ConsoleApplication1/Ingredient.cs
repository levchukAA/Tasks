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
        private double kcal100;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Kcal100
        {
            get { return kcal100; }
            set { kcal100 = value; }
        }


        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public double KcalFull()
        {
            return kcal100 * weight / 100;
        }

        public string InfoString()
        { 
            return "Название: " + name + "\n" + "Вес: " + weight + "\n" + "Количество калорий: "
                + KcalFull();
        }
    }
}
