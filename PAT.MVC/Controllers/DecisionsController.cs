using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PAT.AccessModel.Models;
using PAT.AccessModel.Models.Info;
using PAT.Provider.Info.Dtos;
using PAT.Provider.Info.Service;

namespace PAT.MVC.Controllers
{
    public class DecisionsController : Controller
    {
        private readonly MinisterialEmploymentDescisionsService _ministerialEmploymentDescisionsService;
        private readonly DBContext _context;

        public DecisionsController(MinisterialEmploymentDescisionsService ministerialEmploymentDescisionsService, DBContext context)
        {
            _ministerialEmploymentDescisionsService = ministerialEmploymentDescisionsService;
            _context = context;

        }
        public async Task<ActionResult<MinisterialEmploymentDescisionsToReturnDto>> Index()
        {
            var categories = await _context.DeciesionCategories.Select(S => new SelectListItem { Value = S.Id.ToString(), Text = S.CategoryName })
           .AsNoTracking()
           .ToListAsync(); ;
            var model = new MinisterialEmploymentDescisionsToReturnDto()
            {
                ministerialEmploymentDescisions = await _ministerialEmploymentDescisionsService.GetAllMinisterialEmploymentDescisions(),
                CategoryList= categories
            };
            return View(model);
        }
        [HttpGet]

        [HttpGet]
        public async Task<IActionResult> FilterCategoryDecisions(int category)
        {
            var decisions = await _context.MinisterialEmploymentDescisions.Include(m => m.DeciesionCategory)
                                .Where(m => m.DeciesionCategoryId == category)
                                .ToListAsync();

           
            return PartialView("_DecisionsPartial", decisions);
        }

    }
}
