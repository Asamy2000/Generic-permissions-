using Microsoft.AspNetCore.Mvc;
using PAT.AccessModel.Enums;
using PAT.AccessModel.Models;
using PAT.AccessModel.Models.Info;
using PAT.MVC.Models;
using PAT.Provider.Info.Repos.IRepos;
using PAT.Service;
using System.Security.Claims;

namespace PAT.MVC.Controllers
{
    public class UserCertificateRequestController : Controller
    {
        private readonly IUserCertificateRequestRepo _ucrRepo;
        private readonly ICertificateProcedure _cpRepo;
        private readonly IUserCertificatesRepo _certRepo;

        public UserCertificateRequestController(IUserCertificateRequestRepo ucrRepo, ICertificateProcedure cpRepo, IUserCertificatesRepo CertRepo)
        {
            _ucrRepo = ucrRepo;
            _cpRepo = cpRepo;
            _certRepo = CertRepo;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(InquiryCertVM INQVM)
        {
            try
            {

                UserCertificateRequest model = new UserCertificateRequest
                {
                    certificateId = INQVM.CertificateSerial,
                    userId = 2,
                    RequestType = CertRequestsTypes.Enquiry,
                };
                var result = _ucrRepo.AddUserCertificateRequest(model);
                return Ok();
            }
            catch (Exception)
            {
                ModelState.AddModelError("Error", "an error accoured while saving the model");
                return BadRequest();
            }
        }

        public IActionResult newCert()
        {

            var certList = _certRepo.GetUserCertificates(true);


            return View(certList);
        }


        public IActionResult newCertReplace()
        {

            var certList = _certRepo.GetUserCertificates(false);


            return View(certList);
        }

        public async Task<IActionResult> CreateRenewal()
        {

            var model = new InquiryCertVM()
            {
                IMagePath = _cpRepo.GetCertificateInquiry().Result.ImagePath,
                CertificateProceduresList = await _cpRepo.CPByCategoryId(12),
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateRenewal(string serial)
        {
            try
            {

                UserCertificateRequest model = new UserCertificateRequest
                {
                    certificateId = serial,
                    userId = 2,
                    RequestType = CertRequestsTypes.Renewal,
                    status = UserCertificateStatus.Renewal
                };
                _ucrRepo.AddUserCertificateRequest(model);
                return Ok();
            }
            catch (Exception)
            {
                ModelState.AddModelError("Error", "an error accoured while saving the model");
                return BadRequest();
            }
        }
        public async Task<IActionResult> CreateReplacement()
        {

            var model = new InquiryCertVM()
            {
                IMagePath = _cpRepo.GetCertificateInquiry().Result.ImagePath,
                CertificateProceduresList = await _cpRepo.CPByCategoryId(13),
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateReplacement(InquiryCertVM INQVM)
        {
            try
            {

                UserCertificateRequest model = new UserCertificateRequest
                {
                    certificateId = INQVM.CertificateSerial,
                    userId = 2,
                    RequestType = CertRequestsTypes.Replacement,
                    status = UserCertificateStatus.Pending,


                };
                var result = _ucrRepo.AddUserCertificateRequest(model);
                return Ok();
            }
            catch (Exception)
            {
                ModelState.AddModelError("Error", "an error accoured while saving the model");
                return BadRequest();
            }
        }

        public IActionResult newCertRequest(string serial)
        {
            try
            {

                UserCertificateRequest model = new UserCertificateRequest
                {
                    certificateId = serial,
                    userId = 2,
                    RequestType = CertRequestsTypes.Renewal,
                    status = UserCertificateStatus.Renewal
                };
                _ucrRepo.AddUserCertificateRequest(model);
                return Ok();
            }
            catch (Exception)
            {
                ModelState.AddModelError("Error", "an error accoured while saving the model");
                return BadRequest();
            }
        }


        public IActionResult newCertRequestReplace(string serial)
        {
            try
            {

                UserCertificateRequest model = new UserCertificateRequest
                {
                    certificateId = serial,
                    userId = 2,
                    RequestType = CertRequestsTypes.Replacement,
                    status = UserCertificateStatus.Renewal
                };
                _ucrRepo.AddUserCertificateRequest(model);
                return Ok();
            }
            catch (Exception)
            {
                ModelState.AddModelError("Error", "an error accoured while saving the model");
                return BadRequest();
            }
        }
    }
}
