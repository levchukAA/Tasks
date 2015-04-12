using System;
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
using System.Threading;
using System.Threading.Tasks;

namespace SaleProject
{
    class Program
    {
        private static void Main()
        {
            Methods.ViewAbilities();
        }
    }
    
    public class BloggingContext : DbContext
    {
        public DbSet<ArchiveRecord> Archive { get; set; } 
    }
}
