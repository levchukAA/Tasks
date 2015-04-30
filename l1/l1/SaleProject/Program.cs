using System;
using System.CodeDom;
using System.Data.Entity;

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
