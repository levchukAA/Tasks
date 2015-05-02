using System.Web.Mvc;
using MvcSaleProject.Models;

namespace MvcSaleProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        public ActionResult Info()
        {
            using (UsersContext dataBase = new UsersContext())
            {
                ViewBag.item = dataBase.Archive;
            }
            return View();
        }
    }
}
