using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ATS
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var ats = new ATS();
            ats.ReadContracts(@"d:\epam\Tasks\l1\l1\ATS\Files\Contract1.txt");
            ats.InformationAtsToFile();
            
        }
    }
}
