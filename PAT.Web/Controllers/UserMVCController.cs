using Microsoft.AspNetCore.Mvc;
using PAT.Provider.Info.Service;

namespace PAT.Web.Controllers
{
    public class UserMVCController : Controller
    {
        private readonly UserService _userService;
        public UserMVCController(UserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    }
}
