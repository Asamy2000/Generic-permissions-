using Microsoft.AspNetCore.Mvc;
using PAT.AccessModel.Models;

namespace PAT.MVC.Controllers
{
    public class TempController : Controller
    {
        private readonly DBContext _context;

        public TempController(DBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var tempPage = _context.TempPage.First();
            ViewBag.PageName = tempPage.PageName;
            var pageContent = _context.tempModels.ToList();
            return View(pageContent);
        }
    }
}
