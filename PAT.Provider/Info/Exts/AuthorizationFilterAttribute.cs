using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAT.Provider.Info.Exts
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
	public class AuthorizationFilterAttribute : Attribute, IAuthorizationFilter
	{
		private readonly string[] _role;

		public AuthorizationFilterAttribute(string[] role)
		{
			_role = role;
		}
		public void OnAuthorization(AuthorizationFilterContext context)
		{
			//TODO: write Auth Logic
			var userRole = context.HttpContext.User.Claims.ToList().Where(y => y.Type == "UserRole").Select(x => x.Value).FirstOrDefault();
			if (_role.Length == 0 || !_role.Contains(userRole))
			{
				context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
				return;
			}
		}
	}
}