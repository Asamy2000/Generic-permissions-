using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAT.Provider.ISecurityHandler
{
    public interface IAuthAuthorizationSecurity
    {
        bool ValidateCurrentToken(string token);

    }
}
