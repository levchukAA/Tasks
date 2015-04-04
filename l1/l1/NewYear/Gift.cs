using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace NewYear
{
    class Gift
    {
        private List<Sweet> _sweets = new List<Sweet>();
        public Gift() { }
        public Gift(string path)
        {
            CreateGift(path);
        }

        public void Add(Sweet sweet)
        {
            _sweets.Add(sweet);
        }

        public List<Sweet> Sweets
        {
            get { return _sweets; }
        }
        public void GetTextFile(string pathFile)
        {
            string text = "";
            try
            {
                using (StreamReader sr = new StreamReader(pathFile))
                {
                    text = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
        public void CreateGift(string text)
        {
            
            string[] infoSweets = text.Split('\n');
            int countSugarySweet = int.Parse(infoSweets[0]);
            int countFlourSweet = int.Parse(infoSweets[countSugarySweet + 1]);
            SugarySweet[] sSweets = new SugarySweet[countSugarySweet];
            FlourSweet[] fSweets = new FlourSweet[countFlourSweet];
            for (int i = 0; i < countSugarySweet; i++)
            {
                string[] varStrings = infoSweets[i + 1].Split('|');
                sSweets[i].Name = varStrings[0];
                sSweets[i].Weight = int.Parse(varStrings[1]);
                sSweets[i].Type = (SugarySweetType) varStrings[2];
            }
        }
        public int TotalWeight()
        {
            int totalWeight = 0;
            foreach (var sweet in Sweets)
            {
                totalWeight = totalWeight + sweet.Weight;
            }
            return totalWeight;
        }
        public void Show()
        {
            foreach (var sweet in Sweets)
            {
                sweet.Show();
            }
        }
    }
}
