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
        public WatcherCsv()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            AddLog("start");
            Methods.Run();
        }

        protected override void OnStop()
        {
            Methods.Watcher.Dispose();
            AddLog("stop");
        }
        
        private void AddLog(string log)
        {
            const string serviceName = "WatcherCsv";
            try
            {
                if (!EventLog.SourceExists(serviceName))
                {
                    EventLog.CreateEventSource(serviceName, serviceName);
                }
                eventLog1.Source = serviceName;
                eventLog1.WriteEntry(log);
            }
            catch
            {
                // ignored
            }
        }
    }
}
