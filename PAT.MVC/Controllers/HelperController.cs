using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PAT.AccessModel.Models.Info;
using PAT.MVC.Models;
using PAT.Provider.Info.Repos.IRepos;
using PAT.Service;
using System.Security.Claims;

namespace PAT.MVC.Controllers
{
    //[Authorize]
    //[Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]

    public class HelperController : Controller
    {
        private readonly IHelperRepo _helperRepo;
        private readonly IUserService _userService;

        public HelperController(IHelperRepo helperRepo, IUserService userService)
        {
            _helperRepo = helperRepo;
            _userService = userService;
        }


   
        [HttpPost]
        public async Task<IActionResult> Create(PopupVM model)
        {

            var message = new Message
            {
                Content= model.MessageBody,
                Sender= 1,
                Type = model.TypeId,
                SendDate = DateTime.UtcNow,
                Subject= model.Topic,
                Reply = "",
                Reviewer = 1
            };
            try
            {
                _helperRepo.AddMessage(message);
                return Ok("Sent Successfully");
            }
            catch (Exception)
            {
                ModelState.AddModelError("Error", "an error accoured while saving the model");
                return View(model);
            }

        }

    }
}
