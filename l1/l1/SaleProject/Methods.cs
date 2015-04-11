using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SaleProject
{
    class Methods
    {
        private const string Folder = @"D:\epam\Tasks\l1\l1\SaleProject\bin\Debug";
        private static readonly FileSystemWatcher Watcher = new FileSystemWatcher(Folder, "*.csv");
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
            while (Console.Read() != 'q') { }
            Console.WriteLine("Testing program which search all .csv files in catalog with the help Parallel programming. " +
                              "Info from files sent to database.");
            ParallelMethod();
        }
        public static void Run()
        {
            Watcher.Created += OnCreated;
            Watcher.EnableRaisingEvents = true;
        }
        private static void OnCreated(object source, FileSystemEventArgs e)
        {
            var dataTable = GetTableCsv(e.Name);
            TableToDataBase(dataTable);
        }
        public static void TableToDataBase(DataTable dataTable)
        {
            using (var dataBase = new BloggingContext())
            {
                for (var i = 0; i < dataTable.Rows.Count; i++)
                {
                    var record = new ArchiveRecord
                    {
                        Date = dataTable.Rows[i][0].ToString(),
                        Client = dataTable.Rows[i][1].ToString(),
                        Goods = dataTable.Rows[i][2].ToString(),
                        Amount = (int)dataTable.Rows[i][3]
                    };
                    dataBase.Archive.Add(record);
                }
                Console.WriteLine("Processing {0} on thread {1}", dataTable.TableName, Thread.CurrentThread.ManagedThreadId);
                //Console.WriteLine("In DataBase add new file " + fileName);
                dataBase.SaveChanges();
            }
        }
        public static void ParallelMethod()
        {
            var files = Directory.GetFiles(Folder, "*.csv");
            var parOpts = new ParallelOptions { MaxDegreeOfParallelism = 2 };
            Parallel.ForEach(files, parOpts, currentFile =>
            {
                var fileName = Path.GetFileName(currentFile);
                var dataTable = GetTableCsv(fileName);
                TableToDataBase(dataTable);
            });
        }
    }
}
