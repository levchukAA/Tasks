using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace l2
{
    class Methods
    {
        public static string ReadTextFile(string pathFile)
        {
            String text = "";
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
            return text;
        }

        public static List<Word> CreateDictionary(string text)
        {
            List<Word> dictionary = new List<Word>();
            string regexWord = @"([[^\wA-Za-z]+)";
            Match m = Regex.Match(text, regexWord, RegexOptions.IgnoreCase);
            Word varWord;
            while (m.Success)
            {
                varWord = new Word(m.Groups[1].Value);
                int indexWord = dictionary.IndexOf(varWord);
                if (indexWord != -1)
                {
                    dictionary[indexWord].Count = dictionary[indexWord].Count + 1;
                }
                else dictionary.Add(varWord);
                m = m.NextMatch();
            }
            return dictionary;
        } 
    }
}
