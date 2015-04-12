using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewYear
{
    public class InfoFromFile
    {
        public static string GetTextFile(string pathFile)
        {
            var text = "";
            try
            {
                using (var sr = new StreamReader(pathFile))
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
