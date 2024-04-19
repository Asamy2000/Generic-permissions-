using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PAT.AccessModel.Models;
using PAT.MVC.Models;

namespace PAT.MVC.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly DBContext _context;

        public MenuViewComponent(DBContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var menu =_context.MenuBars.FirstOrDefault();
            var drobDowns = _context.Dropdowns.Include(D => D.DrobdownLinks).ToList();
            var menuLinks = _context.MenuLinks.ToList();
            var model = new MenuViewModel()
            {
                LogoName = menu.LogoName,
                Dropdowns = drobDowns,
                MenuLinks = menuLinks
            };
            return View(model);
        }
    }
}
