using PAT.AccessModel.Enums;
using PAT.Provider.ISecurityHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace PAT.Provider.PermissionHandler
{
    public class ClaimRequirementAttribute : AuthorizeAttribute
    {
        readonly APITechnicalPermissionsEnum _claim;
        public ClaimRequirementAttribute(APITechnicalPermissionsEnum claim)
        {
            _claim = claim;
        }
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            string Data = actionContext.Request.RequestUri.ToString();

            IEnumerable<string> Tokens;
            actionContext.Request.Headers.TryGetValues("Authorization", out Tokens);

            string EncryptedToken = null;
            string Token = null;

            if (Tokens != null && Tokens.First().Split(' ').Count() > 2)
            {
                EncryptedToken = Tokens.First().Split(' ')[1].Trim();
            }
            if (EncryptedToken == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, new { Message = "UnAuthorised User" });
            }

            var dependencyScope = actionContext.Request.GetDependencyScope();
            var _authSecurity = (IAuthAuthorizationSecurity)dependencyScope.GetService(typeof(IAuthAuthorizationSecurity));
            var _validateUser = (IValidateUserProvider)dependencyScope.GetService(typeof(IValidateUserProvider));
            Token = EncryptedToken;// _authSecurity.Decompress(EncryptedToken);
            var tokenValidity = _authSecurity.ValidateCurrentToken(Token);

            if (!tokenValidity)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, new { Message = "UnAuthorised User" });
                return;
            }

            var userIsAuthorized = _validateUser.UserHasPermission(int.Parse(Token), _claim);
            if (!userIsAuthorized)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden, new { Message = "You don’t have permission to perform this action" });
                return;
            }
        }
    }
}
