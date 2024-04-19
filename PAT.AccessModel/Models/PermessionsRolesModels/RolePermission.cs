

using PAT.AccessModel.Models.Info;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAT.AccessModel.Models.PermessionsRolesModels
{
    public class RolePermission : BaseEntity
    {
        [ForeignKey("Permission")]
        public int PermissionId { get; set; }
        public Permission Permission { get; set; } 

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
