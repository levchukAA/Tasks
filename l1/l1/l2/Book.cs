using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace l2
{
    class Book
    {
        private string _text;
        private string _author;
        private string _nameBook;

        public Book(string path)
        {
            GetTextFile(path);
        }

        public Book(string path, string author, string nameBook)
        {
            GetTextFile(path);
            _author = author;
            _nameBook = nameBook;
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        public string NameBook
        {
            get { return _nameBook; }
            set { _nameBook = value; }
        }

        public void GetTextFile(string pathFile)
        {
            try
            {
                using (StreamReader sr = new StreamReader(pathFile))
                {
                    _text = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public string[] ToPages()
        {
            string[] lines = _text.Split('\n');
            int countPages = lines.Count()/10+1;
            string[] page = new string[countPages];
            for (int i = 0; i < countPages; i++)
            {
                int length = i*10 + 10;
                if (length>lines.Length)
                {
                    length = lines.Length;
                }
                for (int j = i*10; j < length; j++)
                {
                    page[i] = page[i] + lines[j];
                }
            }
            return page;
        }

        public Dictionary CreateDictionary()
        {
            string[] pages = ToPages();
            Dictionary testDictionary = new Dictionary();
            const string regexWord = @"([[^\wA-Za-z]+)";
            for (int i = 0; i<pages.Length; i++)
            {
                Match m = Regex.Match(pages[i], regexWord, RegexOptions.IgnoreCase);
                Word varWord;
                string varMatch = "";
                while (m.Success)
                {
                    varMatch = m.Value.ToLower();
                    varWord = new Word(varMatch);
                    int indexWord = testDictionary.Words.IndexOf(varWord);
                    //varWord.AddNumber(i);
                    if (indexWord != -1)
                    {
                        testDictionary.GetItem(indexWord).Count = testDictionary.GetItem(indexWord).Count + 1;
                        testDictionary.GetItem(indexWord).AddNumber(i);
                    }
                    else
                    {
                        testDictionary.Add(varWord);
                        testDictionary.Words.Last().AddNumber(i);
                    }
                    m = m.NextMatch();
                }
            }
            
            testDictionary.Words.Sort();
            return testDictionary;
        }

        public void PrintInfoBook()
        {
            string info = "The book " + NameBook + " is written by " + Author;
            Console.WriteLine(info);
        }
    }
}
