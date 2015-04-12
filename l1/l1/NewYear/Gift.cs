using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace NewYear
{
    public class Gift
    {
        private readonly List<Sweet> _sweets = new List<Sweet>();
        public Gift() { }
        public Gift(string path)
        {
            var info = InfoFromFile.GetTextFile(path);
            CreateGift(info);
        }

        public void Add(Sweet sweet)
        {
            _sweets.Add(sweet);
        }

        public List<Sweet> Sweets
        {
            get { return _sweets; }
        }
        
        public int TotalWeight()
        {
            return Sweets.Aggregate(0, (current, sweet) => current + sweet.Weight);
        }

        public void Show()
        {
            Console.WriteLine("Gift contains: ");
            foreach (var sweet in Sweets)
            {
                sweet.Show();
            }
            Console.WriteLine("Weight of gift: {0}", TotalWeight());
        }

        public void CreateGift(string text)
        {
            var infoSweets = text.Split('\n');
            var countChocoSweet = Int32.Parse(infoSweets[0]);
            var countFlourSweet = Int32.Parse(infoSweets[countChocoSweet + 1]);
            var cSweets = new ChocoSweet[countChocoSweet];
            var fSweets = new FlourSweet[countFlourSweet];
            for (var i = 0; i < countChocoSweet; i++)
            {
                cSweets[i] = new ChocoSweet();
                var varStrings = infoSweets[i + 1].Split('|');
                cSweets[i].Name = varStrings[0];
                cSweets[i].Weight = Int32.Parse(varStrings[1]);
                cSweets[i].Type = (ChocoSweetType) Enum.Parse(typeof (ChocoSweetType), varStrings[2]);
                cSweets[i].KcalPer100 = Int32.Parse(varStrings[3]);
                cSweets[i].SugarPer100 = Int32.Parse(varStrings[4]);
                cSweets[i].Choco = Int32.Parse(varStrings[5]);
                Sweets.Add(cSweets[i]);
            }
            for (var i = 0; i < countFlourSweet; i++)
            {
                fSweets[i] = new FlourSweet();
                var varStrings = infoSweets[i + countChocoSweet + 2].Split('|');
                fSweets[i].Name = varStrings[0];
                fSweets[i].Weight = Int32.Parse(varStrings[1]);
                fSweets[i].Type = (FlourSweetType) Enum.Parse(typeof (FlourSweetType), varStrings[2]);
                fSweets[i].KcalPer100 = Int32.Parse(varStrings[3]);
                fSweets[i].SugarPer100 = Int32.Parse(varStrings[4]);
                fSweets[i].Flour = Int32.Parse(varStrings[5]);
                Sweets.Add(fSweets[i]);
            }
        }

        public void SearchSweet(int min, int max)
        {
            Console.WriteLine("Sweets with Sugar per 100 in [{0},{1}]", min,max);
            foreach (Sweet sweet in Sweets)
            {
                if(sweet.SugarPer100>=min && sweet.SugarPer100<=max)
                    sweet.Show();
            }
        }
    }
}
