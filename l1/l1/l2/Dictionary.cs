using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace l2
{
    class Dictionary
    {
        private List<Word> _dictionary = new List<Word>();

        public Dictionary()
        {
            
        }

        public List<Word> Words
        {
            get { return _dictionary; }
        }

        public Word GetItem(int index)
        {
            return _dictionary[index];
        }
        public void Add(Word word)
        {
            _dictionary.Add(word);
        }

        public void PrintDictionary()
        {
            Console.WriteLine(_dictionary[0].FirstChar);
            _dictionary[0].PrintWord();
            for (int i = 1; i<_dictionary.Count; i++)
            {
                if (_dictionary[i].FirstChar == _dictionary[i - 1].FirstChar)
                {
                    _dictionary[i].PrintWord();
                }
                else
                {
                    Console.WriteLine(_dictionary[i].FirstChar);
                    _dictionary[i].PrintWord();
                }
            }
        }
    }
}
