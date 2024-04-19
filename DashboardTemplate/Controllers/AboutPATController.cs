using DashboardTemplate.BusinuessLogic;
using DashboardTemplate.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PAT.AccessModel.Models.Info;
using PAT.Service;
using System.Security.Claims;

namespace DashboardTemplate.Controllers
{

    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class AboutPATController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public AboutPATController(IUnitOfWork unitOfWork, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        [Authorize(Roles = "Test_Index")]
        public IActionResult Index()
        {
            var about = _unitOfWork.Repository<AboutUs>().GetAllWithSpecAsync(about => about.User).Result.FirstOrDefault();
            if (about is null)
            {
                return RedirectToAction("CreateAbout");
            }
            return View(about);
        }

        [Authorize(Roles = "Test_Create")]
        public IActionResult CreateAbout()
        {
            var aboutExist = _unitOfWork.Repository<AboutUs>().GetAllWithSpecAsync(about => about.User).Result.FirstOrDefault();
            if (aboutExist != null)
            {
                var about = new AboutPATVM()
                {
                    Vision = aboutExist.Vision,
                    Mission = aboutExist.Mission,
                    Responsibilities = aboutExist.Responsibilities
                };
                return View(about);
            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateAbout(AboutPATVM model)
        {
            var aboutExist = _unitOfWork.Repository<AboutUs>().GetAllWithSpecAsync(about => about.User).Result.FirstOrDefault();
            if (aboutExist != null)
            {
                aboutExist.Vision = model.Vision;
                aboutExist.Mission = model.Mission;
                aboutExist.Responsibilities = model.Responsibilities;

                try
                {
                    _unitOfWork.Repository<AboutUs>().Update(aboutExist);
                    await _unitOfWork.Complete();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    _unitOfWork.Rollback();
                }
            }

            var user = await _userService.GetUserByEmailAddress(User.FindFirst(ClaimTypes.Email).Value);
            var about = new AboutUs()
            {
                Vision = model.Vision,
                Mission = model.Mission,
                Responsibilities = model.Responsibilities,
                History = "Historyyy",        // Drop it from database
                CreatedBy = user.id
            };
            try
            {
                await _unitOfWork.Repository<AboutUs>().Add(about);
                await _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                _unitOfWork.Rollback();
            }

            return View(model);
        }
    }
}
