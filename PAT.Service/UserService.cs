using Microsoft.EntityFrameworkCore;
using PAT.AccessModel.Models;
using PAT.AccessModel.Models.Info;

namespace PAT.Service
{
    public class UserService : IUserService
    {
        private readonly DBContext _context;

        public UserService(DBContext context)
        {
            _context = context;
        }
        public async Task<User> GetUserByEmailAddress(string emailAddress)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == emailAddress.ToLower());
        }
    }
}
