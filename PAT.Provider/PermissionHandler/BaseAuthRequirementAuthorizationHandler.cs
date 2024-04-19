using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAT.AccessModel.Enums;
using Newtonsoft.Json.Linq;
using PAT.Provider.ISecurityHandler;
using PAT.AccessModel.Models.PermessionsRolesModels;
using PAT.AccessModel.Models;

namespace PAT.Provider.PermissionHandler
{
    public class BaseAuthRequirementAuthorizationHandler : AuthorizationHandler<BaseAuthRequirement>
    {
        readonly APITechnicalPermissionsEnum _claim;
        private readonly DBContext _context;

        public BaseAuthRequirementAuthorizationHandler(APITechnicalPermissionsEnum claim, DBContext context)
        {
            _claim = claim;
            _context = context;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, BaseAuthRequirement requirement)
        {
            DefaultHttpContext httpRequest = (DefaultHttpContext)context.Resource;
            var syncIOFeature = httpRequest.Features.Get<IHttpBodyControlFeature>();

            httpRequest.Request.EnableBuffering();
            if (syncIOFeature != null)
            {
                syncIOFeature.AllowSynchronousIO = true;
            }

            var token = context.User.Identity;
            var user = token.Name;
            var userIsAuthorized = UserHasPermission(int.Parse(user), _claim);
            if (!userIsAuthorized)
            {
                context.Fail();
            }
            context.Succeed(requirement);

            if (syncIOFeature != null)
            {
                syncIOFeature.AllowSynchronousIO = false;
            }

            return Task.CompletedTask;
        }
        public bool UserHasPermission(int token, APITechnicalPermissionsEnum claimName)
        {
            var permissions = getUserPermissions(token);
            bool result = false;
            if (permissions.Count() > 0)
            {
                result = permissions.Any(x => x.MethodPermissionKey == claimName.ToString());
            }
            // var securityTokenClaimsExists = securityToken.Claims.Where(clm => !standardClaims.Contains(clm.Type) && Decompress(clm.Type).Split(new string[] { "__" }, StringSplitOptions.RemoveEmptyEntries).ToList().Contains(claimName.ToString())).Any();
            return result;
        }

        public List<Permission> getUserPermissions(int userId)
        {
            var roles = _context.UserRoles.Where(x => x.UserId == userId).Select(r => new UserRole
            {
                Role = r.Role
            }).ToList();
            var rolePermissions = _context.RolePermissions.Where(x => roles.Any(r => r.RoleId == x.RoleId)).ToList();

            var permissions = _context.Permissions.Where(x => rolePermissions.Any(p => p.PermissionId == x.Id)).ToList();

            return permissions;
        }

    }
}
