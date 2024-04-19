using Microsoft.AspNetCore.Mvc.Rendering;

namespace DashboardTemplate.Models.PermissionsVM
{
    public class AssignRoleToUserVM
    {
        public int UserId { get; set; }
        public IEnumerable<SelectListItem> Users { get; set; }

        public List<int> RolesIds { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}
