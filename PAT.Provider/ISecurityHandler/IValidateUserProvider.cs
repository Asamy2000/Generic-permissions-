using PAT.AccessModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAT.Provider.ISecurityHandler
{
    public interface IValidateUserProvider
    {
        bool UserHasPermission(int token, APITechnicalPermissionsEnum claimName);

    }
}
