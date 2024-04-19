using PAT.AccessModel.Models.Info;
using System.ComponentModel.DataAnnotations.Schema;


namespace PAT.AccessModel.Models.PermessionsRolesModels
{
    public class UserRole : BaseEntity
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; }


    }
}
