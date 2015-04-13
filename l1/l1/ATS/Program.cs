using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ATS
{
    class Program
    {
        private static void Main(string[] args)
        {
            var ats = new ATS();
            ats.GenerateContract(@"d:\epam\Tasks\l1\l1\ATS\Contracts\Contract1.txt");
        }
    }
}
