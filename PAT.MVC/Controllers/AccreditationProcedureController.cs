using Microsoft.AspNetCore.Mvc;
using PAT.Provider.Info.Repos.IRepos;

namespace PAT.MVC.Controllers
{
    public class AccreditationProcedureController : Controller
    {
        private readonly IAccreditationProcedureRepo apRepo;
        private readonly IAccreditationProcedureCategoryRepo categoryRepo;

        public AccreditationProcedureController(IAccreditationProcedureRepo apRepo , IAccreditationProcedureCategoryRepo categoryRepo)
        {
            this.apRepo = apRepo;
            this.categoryRepo = categoryRepo;
        }
        public  IActionResult Index()
        {
            var APCs = categoryRepo.GetAccreditationProcedureCategory();
            return View(APCs);
        }
        public async Task<IActionResult> Details(int Id)
        {
            var APs = await apRepo.GetAccreditationProcedureByCategoryId(Id);
            return View(APs);
        }
    }
}
