using Microsoft.AspNetCore.Mvc.Rendering;

namespace DashboardTemplate.Models.PermissionsVM
{
    public class AssignPermissionsToRoleVM
    {
        public int RoleId { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }

        public List<int> PermissionsIds { get; set; }
        public IEnumerable<SelectListItem> Permissions { get; set; }
    }
}
