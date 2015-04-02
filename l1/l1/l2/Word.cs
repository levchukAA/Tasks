﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2
{
    class Word : IEquatable<Word>, IComparable<Word>
    {
        private string _word;
        private int _count = 1;
        private List<int> _numberPages = new List<int>();

        public Word(string word)
        {
            _word = word;
        }

        public string Value
        {
            get { return _word; }
            set { _word = value;  }
        }
        public int Count 
        {
            get { return _count; }
            set { _count = value; }
        }

        public char FirstChar
        {
            get { return _word.ToCharArray()[0]; }
        }

        public bool Equals(Word other)
        {
            if (this.Value == other.Value)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public int CompareTo(Word compareWord)
        {
            if (compareWord == null)
                return 1;

            else
                return Value.CompareTo(compareWord.Value);
        }

        public void AddNumber(int number)
        {
            int page = number + 1;
            try
            {
                int lastPage = _numberPages.Last();
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
            string printString = _word + " " + _count + ": ";
            foreach (int number in _numberPages)
                printString = printString + number + " ";
            Console.WriteLine(printString);
        }
        } 
    }
