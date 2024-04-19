using Microsoft.AspNetCore.Mvc;
using PAT.Provider.Info.Repos.IRepos;

namespace PAT.MVC.Controllers
{
    public class AccreditedCentersController : Controller
    {
        private readonly IAccreditedCenter _accreditedCenter;

        public AccreditedCentersController(IAccreditedCenter accreditedCenter)
        {
            _accreditedCenter = accreditedCenter;
        }
        public async Task<IActionResult> Index()
        {
            var accreditedCenters = await _accreditedCenter.GetAccreditedCenters();
            return View(accreditedCenters);
        }

        public async Task<IActionResult> Details(int id)
        {
            var accreditedCenter = await _accreditedCenter.GetAccreditedCenter(id);
            return View(accreditedCenter);
        }
    }
}
