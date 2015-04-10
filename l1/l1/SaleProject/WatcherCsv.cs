using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace SaleProject
{
    partial class WatcherCsv : ServiceBase
    {
        FileSystemWatcher watcher = new FileSystemWatcher(@"D:\epam\Tasks\l1\l1\SaleProject\bin\Debug", "*.csv");
        public WatcherCsv()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            AddLog("start");
            watcher.Created += OnCreated;
            watcher.EnableRaisingEvents = true;
        }

        protected override void OnStop()
        {
            if (watcher != null)
                watcher.Dispose();
            AddLog("stop");
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
                        Amount = (int)dataTable.Rows[i][3]
                    };
                    dataBase.Archive.Add(record);
                }
                //Console.WriteLine("In DataBase add new file " + e.Name);
                dataBase.SaveChanges();
            }
        }
        private void AddLog(string log)
        {
            string serviceName = "WatcherCsv";
            try
            {
                if (!EventLog.SourceExists(serviceName))
                {
                    EventLog.CreateEventSource(serviceName, serviceName);
                }
                eventLog1.Source = serviceName;
                eventLog1.WriteEntry(log);
            }
            catch {}
        }
    }
}
