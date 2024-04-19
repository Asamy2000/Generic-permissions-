using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PAT.AccessModel.Models;
using PAT.MVC.Models;
using PAT.Provider.Info.Dtos;
using PAT.Provider.Info.Repos.IRepos;

namespace PAT.MVC.Controllers
{
    public class NewsController : Controller
    {
        private readonly IAcademyNews _newsRepo;
        private readonly IMonthesRepo _monthesRepo;
        private readonly DBContext _context;

        public NewsController(IAcademyNews news, IMonthesRepo monthesRepo , DBContext context)
        {
            _newsRepo = news;
            _monthesRepo = monthesRepo;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _context.NewsCategories.Select(S => new SelectListItem { Value = S.Id.ToString(), Text = S.Name })
           .AsNoTracking()
           .ToListAsync();
            var model = new NewsToReturnDto()
            {
                MonthesList = await _monthesRepo.GetAllMonthesForDropdown(),
                NewsList = await _newsRepo.GetAcademyNews(),
                CategoryList = categories
            };

            return View(model);
        }
        //public async Task<IActionResult> Details(int Id)
        //{
        //    var news = await _newsRepo.GetAcademyNewsById(Id);
        //    if (news == null)
        //        return NotFound();

        //    return View(news);
        //}
        public async Task<IActionResult> Details(int id) 
        {
            var newsItem = await _context.AcademyNews.FirstOrDefaultAsync(n => n.Id == id);
            if (newsItem == null)
            {
                return NotFound();
            }

            
            var relatedNews = await _context.AcademyNews
                                    .Where(n => n.CategoryId == newsItem.CategoryId && n.Id != id)
                                    .OrderByDescending(n => n.CreateTime) 
                                    .Take(5) 
                                    .ToListAsync();

            
            var viewModel = new NewsDetailViewModel
            {
                CurrentNews = newsItem,
                RelatedNews = relatedNews
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> FilterNews(int month)
        {
            var news = await _context.AcademyNews
                                .Where(m => m.CreateTime.Month == month)
                                .OrderBy(m => m.CreateTime)
                                .ToListAsync();


            return PartialView("_News", news);
        }

        [HttpGet]
        public async Task<IActionResult> FilterCategoryNews(int category)
        {
            var news = await _context.AcademyNews
                                .Where(m => m.CategoryId == category)
                                .OrderBy(m => m.CreateTime)
                                .ToListAsync();


            return PartialView("_News", news);
        }


    }
}
