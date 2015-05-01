using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using SaleProject;


namespace MvcSaleProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var dataTable = Methods.GetTableCsv(@"D:\epam\Tasks\l1\l1\SaleProject\bin\Debug\6.csv");
            using (var dataBase = new BloggingContext())
            {
                for (var i = 0; i < dataTable.Rows.Count; i++)
                {
                    var varTime = (DateTime)dataTable.Rows[i][0];
                    var record = new ArchiveRecord
                    {
                        Date = varTime,
                        Client = (string)dataTable.Rows[i][1],
                        Goods = (string)dataTable.Rows[i][2],
                        Amount = (int)dataTable.Rows[i][3]
                    };
                    dataBase.Archive.Add(record);
                }
                dataBase.SaveChanges();
            }
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            return View();
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
