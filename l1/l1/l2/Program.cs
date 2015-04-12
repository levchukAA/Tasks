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
            var testBook = new Book("Test.txt", "Lermontov", "Death of the Poet");
            var testDictionary = testBook.CreateDictionary();
            testBook.PrintInfoBook();
            testDictionary.PrintDictionary();
        }
    }
}
