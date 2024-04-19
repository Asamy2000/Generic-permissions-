using Microsoft.AspNetCore.Mvc;
using PAT.MVC.Models;
using PAT.Provider.Info.Repos.IRepos;

namespace PAT.MVC.Controllers
{
    public class CertificateProcedureController : Controller
    {
        private readonly ICertificateProcedure _cpRepo;

        public CertificateProcedureController(ICertificateProcedure cpRepo)
        {
            _cpRepo = cpRepo;
        }
        public IActionResult Index()
        {

            return View();
        }

        public async Task<IActionResult> Details()
        {
            var model = new InquiryCertVM()
            {
                IMagePath = _cpRepo.GetCertificateInquiry().Result.ImagePath,
                CertificateProceduresList = await _cpRepo.CPCategories(),
            };
            return View(model);
        }



    }
}
