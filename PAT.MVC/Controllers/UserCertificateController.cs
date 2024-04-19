using Microsoft.AspNetCore.Mvc;
using PAT.MVC.Models;
using PAT.Provider.Info.Repos.IRepos;
using PAT.Service;
using System.Security.Claims;

namespace PAT.MVC.Controllers
{
    public class UserCertificateController : Controller
    {
        private readonly IUserCertificatesRepo _userCertificateRepo;

        public UserCertificateController(IUserCertificatesRepo userCertificatesRepo)
        {
            _userCertificateRepo = userCertificatesRepo;

        }


        public IActionResult Index()
        {

            var userCertificates = _userCertificateRepo.GetUserCertificatesByUser(2);

            return View(userCertificates);
        }

        public IActionResult UserCertificates()
        {
            var userCertificates = _userCertificateRepo.GetUserCertificatesByUser(2);

            return View(userCertificates);
        }
        public IActionResult Details(InquiryCertVM id)
        {
            var userCertificate = _userCertificateRepo.GetUserCertificate(id.CertificateSerial);
            return View(userCertificate);
        }
    }
}
