using Microsoft.IdentityModel.Tokens;
using PAT.Provider.ISecurityHandler;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAT.Provider.ISecurityImplementation
{
    public class AuthAuthorizationSecurity : IAuthAuthorizationSecurity
    {
        public bool ValidateCurrentToken(string token)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(""/*ConfigurationManager.AppSettings["JwtKey"]*/));
            // var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var myIssuer = ""; //ConfigurationManager.AppSettings["JwtIssuer"];
            var myAudience = "";//ConfigurationManager.AppSettings["JwtAudience"];

            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidIssuer = myIssuer,
                    ValidAudience = myAudience,
                    IssuerSigningKey = securityKey
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
