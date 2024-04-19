using Microsoft.AspNetCore.Mvc;

namespace PAT.MVC.Controllers
{
    public class CenterPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
