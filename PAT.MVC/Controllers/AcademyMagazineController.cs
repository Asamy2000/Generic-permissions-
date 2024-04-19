using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PAT.AccessModel.Models;
using PAT.AccessModel.Models.Info;
using PAT.Provider.Info.Repos.IRepos;

namespace PAT.MVC.Controllers
{
    public class AcademyMagazineController : Controller
    {
        private readonly IMagazineRepo _magazineRepo;
        private readonly DBContext _context;

        public AcademyMagazineController(IMagazineRepo magazineRepo , DBContext context)
        {
            _magazineRepo = magazineRepo;
            _context = context;
        }
        public  async Task<IActionResult> Index()
        {
            var magazienes = await _magazineRepo.GetMagazines();
            return View(magazienes);
        }


        [HttpGet]
        public async Task<IActionResult> FilterMagazines(int month)
        {
            var magazines = await _context.AcademyMagazines
                                .Where(m => m.CreationDate.Month == month)
                                .OrderBy(m => m.CreationDate)
                                .ToListAsync();

           
            return PartialView("_Magazines", magazines);
        }

    }
}
