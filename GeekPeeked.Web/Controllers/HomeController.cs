using System.Web.Mvc;

namespace GeekPeeked.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}