using PAT.AccessModel.Models.PermessionsRolesModels;

namespace PAT.AccessModel.Models.Info
{
    public class User
    {
        public int id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserTypeId { get; set; }
        virtual public UserType userType { get; set; }


        public ICollection<UserRole> Roles { get; set; } = new HashSet<UserRole>();



    }
}
