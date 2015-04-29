using System;
using System.ComponentModel.DataAnnotations;

namespace SaleProject
{
    public class ArchiveRecord
    {
        [Key]
        public int SaleId { get; set; }
        public DateTime Date { get; set; }
        public string Client { get; set; }
        public string Goods { get; set; }
        public int Amount { get; set; }
    }
}
