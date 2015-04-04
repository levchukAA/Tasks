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
        private List<Word> _words = new List<Word>();

        public Dictionary()
        {
            
        }

        public List<Word> Words
        {
            get { return _words; }
        }

        public Word GetItem(int index)
        {
            return _words[index];
        }
        public void Add(Word word)
        {
            _words.Add(word);
        }

        public void PrintDictionary()
        {
            Console.WriteLine(_words[0].FirstChar);
            _words[0].PrintWord();
            for (int i = 1; i<_words.Count; i++)
            {
                if (_words[i].FirstChar == _words[i - 1].FirstChar)
                {
                    _words[i].PrintWord();
                }
                else
                {
                    Console.WriteLine(_words[i].FirstChar);
                    _words[i].PrintWord();
                }
            }
        }
    }
}
