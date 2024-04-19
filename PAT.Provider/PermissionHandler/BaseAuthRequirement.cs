using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAT.Provider.PermissionHandler
{
    public class BaseAuthRequirement : IAuthorizationRequirement
    {
        public BaseAuthRequirement() { }

    }
}
