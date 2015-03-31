using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Methods.ReadTextFile("Test.txt");
            Console.WriteLine(text);
            List<Word> words = Methods.CreateDictionary(text);
            foreach (Word word in words)
            {
                word.PrintWord();
            }
        }
    }
}
