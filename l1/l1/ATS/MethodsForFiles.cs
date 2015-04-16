using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewYear;

namespace ATS
{
    class MethodsForFiles
    {
        public static void ReadContracts(string path)
        {
            string text = InfoFromFile.GetTextFile(path);
            string[] clients = text.Split('\n');
            foreach (var client in clients)
            {
                string firstName = client.Split('|')[0];
                string lastName = client.Split('|')[1];
                ATS.AddContract(firstName, lastName);
            }
        }
        
    }
}
