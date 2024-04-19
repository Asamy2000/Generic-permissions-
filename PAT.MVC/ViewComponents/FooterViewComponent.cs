using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PAT.AccessModel.Models;

namespace PAT.MVC.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly DBContext _context;

        public FooterViewComponent(DBContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var foo = _context.Footers.Include(F => F.Sections).ThenInclude(S => S.Links).First();
            return View(foo);
        }
    }
}
