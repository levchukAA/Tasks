using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewYear
{
    class InfoFromFile
    {
        public static string GetTextFile(string pathFile)
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
            return text;
        }
    }
}
