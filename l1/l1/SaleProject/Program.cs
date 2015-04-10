﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Data.Odbc;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleProject
{
    class Program
    {
        private static void Main(string[] args)
        {
            Run();
            ParallelExample();
        }

        public static void Run()
        {
            var watcher = new FileSystemWatcher(@"D:\epam\Tasks\l1\l1\SaleProject\bin\Debug", "*.csv");
            watcher.Created += OnCreated;
            watcher.EnableRaisingEvents = true;
        }
        private static void OnCreated(object source, FileSystemEventArgs e)
        {
            using (var dataBase = new BloggingContext())
            {
                var dataTable = Methods.GetTableCsv(e.Name);
                for (var i = 0; i < dataTable.Rows.Count; i++)
                {
                    var record = new ArchiveRecord
                    {
                        Date = dataTable.Rows[i][0].ToString(),
                        Client = dataTable.Rows[i][1].ToString(),
                        Goods = dataTable.Rows[i][2].ToString(),
                        Amount = (int) dataTable.Rows[i][3]
                    };
                    dataBase.Archive.Add(record);
                }
                //Console.WriteLine("In DataBase add new file " + e.Name);
                dataBase.SaveChanges();
            }
        }

        public static void ParallelExample()
        {
            ParallelOptions parOpts = new ParallelOptions();
            parOpts.MaxDegreeOfParallelism = 2;

        }
    }
    
    public class BloggingContext : DbContext
    {
        public DbSet<ArchiveRecord> Archive { get; set; } 
    }
}
