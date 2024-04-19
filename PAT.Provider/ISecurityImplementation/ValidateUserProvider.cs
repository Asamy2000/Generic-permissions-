using PAT.AccessModel.Enums;
using PAT.AccessModel.Models;
using PAT.AccessModel.Models.PermessionsRolesModels;
using PAT.Provider.ISecurityHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAT.Provider.ISecurityImplementation
{
    public class ValidateUserProvider : IValidateUserProvider
    {
        private readonly DBContext _context;
        public ValidateUserProvider(DBContext context)
        {
            _context = context;
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
            var roles = _context.UserRoles.Where(x=>x.UserId == userId).Select(r => new UserRole
            {
                Role = r.Role
            }).ToList();
            var rolePermissions = _context.RolePermissions.Where(x => roles.Any(r => r.RoleId == x.RoleId)).ToList();

            var permissions = _context.Permissions.Where(x=> rolePermissions.Any(p => p.PermissionId == x.Id)).ToList();

            return permissions;
        }
        }
}
