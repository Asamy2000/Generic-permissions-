using PAT.AccessModel.Models.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAT.Service
{
    public interface IUserService
    {
        Task<User> GetUserByEmailAddress(string emailAddress);
    }
}
