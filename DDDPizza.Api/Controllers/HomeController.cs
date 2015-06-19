using System.Web.Mvc;

namespace DDDPizza.Api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "DDDPizZa!";

            return View();
        }
    }
}
