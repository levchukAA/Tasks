using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleProject
{
    class Methods
    {
        public static DataTable GetTableCsv(string file)
        {
            const string folder = @"D:\epam\Tasks\l1\l1\SaleProject\bin\Debug";
            var connection = new OdbcConnection(@"Driver={Microsoft Text Driver (*.txt; *.csv)};
Dbq=" + folder + ";Extensions=asc,csv,tab,txt;Persist Security Info=False");
            var dt = new DataTable();
            var da = new OdbcDataAdapter("select * from [" + file + "]", connection);
            da.Fill(dt);
            return dt;
        }
    }
}
