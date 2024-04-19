using PAT.AccessModel.Models.Info;
using System.ComponentModel.DataAnnotations.Schema;


namespace PAT.AccessModel.Models.PermessionsRolesModels
{
    public class Permission : BaseEntity
    {
        public string ControllerName { get; set; }
        public string MethodName { get; set; }
        public string MethodPermissionKey { get; set; }
        [ForeignKey("MethodType")]
        public int MethodTypeId { get; set; }
        public MethodType MethodType { get; set; }
        public DateTime CreateDate { get; set; }
        [ForeignKey("User")]
        public int CreatedBy { get; set; }
        public User User { get; set; }

        public ICollection<RolePermission> Roles { get; set; } = new HashSet<RolePermission>();

    }
}
