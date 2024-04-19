using Microsoft.AspNetCore.Mvc;
using PAT.Provider.Info.Dtos;
using PAT.Provider.Info.Repos.IRepos;

namespace PAT.MVC.Controllers
{
    public class AboutPATController : Controller
    {
        private readonly IAboutPATRepo _aboutPAT;

        public AboutPATController(IAboutPATRepo aboutPAT)
        {
            _aboutPAT = aboutPAT;
        }
        public async Task<IActionResult> Index()
        {
            var about = await _aboutPAT.GetboutUs();
            var goals = await _aboutPAT.GetAcademyGoals();

            var aboutDto = new AboutUsDto
            {
                About = about,
                AcademyGoals = goals
            };
            return View(aboutDto);
        }
    }
}
