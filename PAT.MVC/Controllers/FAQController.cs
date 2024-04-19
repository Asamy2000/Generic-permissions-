using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PAT.AccessModel.Models;
using PAT.Provider.Info.Dtos;
using PAT.Provider.Info.Repos.IRepos;

namespace PAT.MVC.Controllers
{
    public class FAQController : Controller
    {
        private readonly IFAQRepo _fAQRepo;
        private readonly DBContext _context;

        public FAQController(IFAQRepo fAQRepo, DBContext context)
        {
            _fAQRepo = fAQRepo;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _context.FAQCategories.Select(S => new SelectListItem { Value = S.Id.ToString(), Text = S.Name })
            .ToListAsync();
            var model = new FAQToReturnDto()
            {
                FAQsList = await _fAQRepo.GetFAQs(),
                CategoryList = categories
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> FilterCategoryFAQs(int category)
        {
            var news = await _context.FAQModels.Include(Y => Y.FaQQuestionAnswer)
                                .Where(m => m.Category == category)
                                .ToListAsync();


            return PartialView("_FAQ", news);
        }

        [HttpGet]
        public async Task<IActionResult> FilterFAQsBasedOnCategory(int category)
        {
            var FAQS = await _context.FAQModels
                                .Where(m => m.Category == category)
                                .ToListAsync();


            return PartialView("_FAQPOPUP", FAQS);
        }

    }
}
