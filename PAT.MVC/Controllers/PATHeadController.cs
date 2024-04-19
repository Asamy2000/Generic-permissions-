using Microsoft.AspNetCore.Mvc;
using PAT.Provider.Info.Repos.IRepos;

namespace PAT.MVC.Controllers
{
    public class PATHeadController : Controller
    {
        private readonly IPATManagerRepo _pATManagerRepo;

        public PATHeadController(IPATManagerRepo pATManagerRepo)
        {
            _pATManagerRepo = pATManagerRepo;
        }
        public async Task<IActionResult> Index()
        {   
            var PatHeads = await _pATManagerRepo.GetManagers();
            return View(PatHeads);
        }
    }
}
