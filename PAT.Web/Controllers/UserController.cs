using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PAT.AccessModel.Models.Info;
using PAT.Provider.Info.Dtos;
using PAT.Provider.Info.Exts;
using PAT.Provider.Info.Service;

namespace PAT.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
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
        [HttpPost]
        public async Task<ActionResult<CreateUserDto>> Post(CreateUserDto createUser)
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
            if(await _userService.Delete(id))
                return Ok();
            return BadRequest();//TODO: check the return of this
        }
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginDto login)
        {
            var token = await _userService.Login(login.Email, login.Password);

            if (token == null)
            {
                return Unauthorized("Email or Password is Incorrect");
            }

            return Ok(new { Message = "Login Succeeded", Token = token });
        }
    }
}
