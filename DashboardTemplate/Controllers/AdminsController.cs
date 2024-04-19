using DashboardTemplate.BusinuessLogic;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DashboardTemplate.Models;
using PAT.AccessModel.Models;
using PAT.AccessModel.Models.PermessionsRolesModels;
using Microsoft.EntityFrameworkCore;

namespace DashboardTemplate.Controllers
{
    public class AdminsController : Controller
    {
        private readonly DBContext _context;
        private readonly IConfiguration _configuration;

        public AdminsController(DBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public IActionResult Login()
        {
            return PartialView();
        }



        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);

                if (user is null) return NotFound();
                var permissions = await GetUserPermissions(user.id);

                if (model.Password == user.Password && model.Email == user.Email)
                {
                    var token = GenerateJwtToken(user.Email, "Admin");
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                    var claims = new List<Claim>
                    {
                      new Claim(ClaimTypes.Name, user.id.ToString()),
                      new Claim(ClaimTypes.Email, user.Email),
                      new Claim(ClaimTypes.Role, "Admin")
                    };
                    foreach (var permission in permissions)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, permission.MethodPermissionKey));
                    }
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = model.RememberMe,
                        ExpiresUtc = model.RememberMe ? DateTimeOffset.UtcNow.AddMonths(1) : null 
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    // Store the token in a cookie
                    Response.Cookies.Append("AuthToken", tokenString, new CookieOptions
                    {
                        Expires = model.RememberMe ? DateTimeOffset.UtcNow.AddMonths(1) : DateTimeOffset.UtcNow.AddMinutes(30), 
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.None
                    });


                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);

                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "!إسم المستخدم أو كلمة المرور غير صحيحه");
            return View(model);
        }



        public IActionResult Logout()
        {

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);


            return RedirectToAction(nameof(Login), "Admins");
        }


        private JwtSecurityToken GenerateJwtToken(string username, string role)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Secret"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,username),
                    new Claim(ClaimTypes.Role, role),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                var token = new JwtSecurityToken(
                    issuer: _configuration["JwtSettings:ValidIssuer"],
                    audience: _configuration["JwtSettings:ValidAudience"],
                    expires: DateTime.Now.AddMonths(1),
                    claims: authClaims,
                    signingCredentials: credentials
                    );
                return token;
            }
            catch
            {
                return null;
            }
        }


        public async Task<List<Permission>> GetUserPermissions(int userId)
        {
            var roles = await _context.UserRoles
                                     .Where(x => x.UserId == userId)
                                     .Select(r => r.Role)
                                     .ToListAsync();

            var roleIds = roles.Select(r => r.id).ToList();

            var rolePermissions = await _context.RolePermissions
                                              .Where(x => roleIds.Contains(x.RoleId))
                                              .ToListAsync();

            var permissionIds = rolePermissions.Select(p => p.PermissionId).ToList();

            var permissions = await _context.Permissions
                                            .Where(x => permissionIds.Contains(x.Id))
                                            .ToListAsync();

            return permissions;
        }

    }
}
