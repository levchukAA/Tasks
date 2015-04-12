using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SaleProject
{
    public class Methods
    {
        private const string Folder = @"D:\epam\Tasks\l1\l1\SaleProject\bin\Debug";
        public static readonly FileSystemWatcher Watcher = new FileSystemWatcher(Folder, "*.csv");
        public static DataTable GetTableCsv(string file)
        {
            var connection = new OdbcConnection(@"Driver={Microsoft Text Driver (*.txt; *.csv)};
Dbq=" + Folder + ";Extensions=asc,csv,tab,txt;Persist Security Info=False");
            var dt = new DataTable();
            var da = new OdbcDataAdapter("select * from [" + file + "]", connection);
            da.Fill(dt);
            dt.TableName = file;
            return dt;
        }
        public static void ViewAbilities()
        {
            Console.WriteLine("Testing program which tracks addition new .csv files in catalog. " +
                              "Info from files sent to database.");
            Run();
            Console.WriteLine("Press \'q\' to quit the sample.");
            while (Console.Read() != 'q') {}
        }
        public static void Run()
        {
            Watcher.Created += OnCreated;
            Watcher.EnableRaisingEvents = true;
        }
        private static void OnCreated(object source, FileSystemEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(CsvToDataBase, e.Name);
        }
        public static void CsvToDataBase(object file)
        {
            var path = (string) file;
            var dataTable = GetTableCsv(path);
            using (var dataBase = new BloggingContext())
            {
                for (var i = 0; i < dataTable.Rows.Count; i++)
                {
                    var varTime = (DateTime) dataTable.Rows[i][0];
                    var record = new ArchiveRecord
                    {
                        Date = varTime,
                        Client = (string)dataTable.Rows[i][1],
                        Goods = (string)dataTable.Rows[i][2],
                        Amount = (int)dataTable.Rows[i][3]
                    };
                    dataBase.Archive.Add(record);
                }
                Console.WriteLine("In DataBase add new file {0} on thread {1}", dataTable.TableName, Thread.CurrentThread.ManagedThreadId);
                dataBase.SaveChanges();
            }
        }
    }
}
