using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Net.Http.Headers;
using PAT.Provider.Info.Dtos;
using PAT.Provider.Info.Service;

namespace PAT.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;
        private readonly PositionService _positionService;
        private readonly GovernmentService _governmentService;
        private readonly EducitionalAdministrationService _educitionalAdministrationService;
        public UserController(UserService userService
            , GovernmentService governmentService
            , EducitionalAdministrationService educitionalAdministrationService
            , PositionService positionService)
        {
            _userService = userService;
            _governmentService = governmentService;
            _educitionalAdministrationService = educitionalAdministrationService;
            _positionService = positionService;
        }
        [Authorize] // Authantication filter
        // [AuthorizationFilter(new string[] { "Admin", "Student" })] //TODO : write the correct roles (AuthorizationFilter is a custom filter that checks the roles of the user and returns 403 if the user is not authorized to access the endpoint)
        [HttpGet]
        public ActionResult<List<CreateUserDto>> Get()
        {
            return Ok(_userService.Get());
        }

        [HttpGet("{id}")]
        public ActionResult<CreateUserDto> Get(int id)
        {
            return Ok(_userService.Get(id));
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            CreateUserDto dto = new CreateUserDto();
            dto.CreteUserVM = new CreteUserVM()
            {
                Governments = _governmentService.GetAllGovernmentes().Select(g => new SelectListItem { Value = g.id.ToString(), Text = g.Name }),
                EducitionalAdministration = _educitionalAdministrationService.GetAllEducitionalAdministrationes().Select(g => new SelectListItem { Value = g.id.ToString(), Text = g.Name }),
                Positions = (await _positionService.GetPositions()).Select(g => new SelectListItem { Value = g.id.ToString(), Text = g.Name }),
            };
            return View(dto);
        }

        [HttpPost]
        public async Task<ActionResult<CreateUserDto>> Register(CreateUserDto createUser)
        {
            var user = await _userService.Create(createUser);
            if (user == null)
                return BadRequest();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<CreateUserDto>> Put(int id, CreateUserDto createUser)
        {
            var user = await _userService.Update(id, createUser);
            if (user == null)
                return NotFound();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            if (await _userService.Delete(id))
                return Ok();
            return BadRequest();//TODO: check the return of this
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<string>> Login(LoginDto login)
        {

            var context = HttpContext.User.Identity?.Name;

            var token = await _userService.Login(login.Email, login.Password);

            if (token == null)
            {
                return Unauthorized("Email or Password is Incorrect");
            }

            return Ok(new CookieHeaderValue("Token", "Bearer " + token));
        }



        private string GetLoggedUser()
        {
            var token = HttpContext.User.Identity;
            var userName = token?.Name;
            if (string.IsNullOrEmpty(userName))
                return null;
            else
                return userName;
        }
    }
}