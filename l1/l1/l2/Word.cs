using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2
{
    public class Word : IEquatable<Word>, IComparable<Word>
    {
        private readonly List<int> _numberPages = new List<int>();

        public Word(string word)
        {
            Count = 1;
            Value = word;
        }

        public string Value { get; set; }

        public int Count { get; set; }

        public char FirstChar
        {
            get { return Value[0]; }
        }

        public bool Equals(Word other)
        {
            return Value == other.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public int CompareTo(Word compareWord)
        {
            return compareWord == null ? 1 : String.Compare(Value, compareWord.Value, StringComparison.Ordinal);
        }

        public void AddNumber(int number)
        {
            var page = number + 1;
            try
            {
                var lastPage = _numberPages.Last();
                if (lastPage != page)
                    _numberPages.Add(page);
            }
            catch
            {
                _numberPages.Add(page);
            }
        }

        public void PrintWord()
        {
            var printString = Value + " " + Count + ": ";
            printString = _numberPages.Aggregate(printString, (current, number) => current + number + " ");
            Console.WriteLine(printString);
        }
        } 
    }
