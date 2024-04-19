using Microsoft.AspNetCore.Mvc;

namespace PAT.MVC.Controllers
{
    public class TermsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
