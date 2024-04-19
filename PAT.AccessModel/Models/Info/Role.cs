using PAT.AccessModel.Models.PermessionsRolesModels;

namespace PAT.AccessModel.Models.Info
{
    public class Role
    {
        public int id { get; set; }
        public string Name { get; set; }


        public ICollection<UserRole> Users { get; set; } = new HashSet<UserRole>();
        public ICollection<RolePermission> Permissions { get; set; } = new HashSet<RolePermission>();
    }
}
