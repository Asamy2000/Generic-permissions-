using Microsoft.AspNetCore.Mvc;
using PAT.Provider.Info.Dtos;
using PAT.Provider.Info.Repos.IRepos;

namespace PAT.MVC.Controllers
{
    public class SocialController : Controller
    {
        private readonly ISocialRepo _socialPAT;

        public SocialController(ISocialRepo socialPAT)
        {
            _socialPAT = socialPAT;
        }
        public  IActionResult Index()
        {
            var topHeader = _socialPAT.GetTopHeader();

            return View(topHeader);
        }
    }
}
