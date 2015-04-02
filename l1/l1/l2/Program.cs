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
            Book testBook = new Book("Test.txt", "Lermontov", "Death of the Poet");
            Dictionary testDictionary = testBook.CreateDictionary();
            testBook.PrintInfoBook();
            testDictionary.PrintDictionary();
            testBook.ToPages();
        }
    }
}
