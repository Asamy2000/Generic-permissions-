using System.ComponentModel.DataAnnotations;

namespace DashboardTemplate.Models
{
    public class LoginVM
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "! يجب إدخال إسم المستخدم")]
        public string Email { get; set; } = default!;

        [Required(AllowEmptyStrings = false, ErrorMessage = "! يجب إدخال كلمة المرور")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;

        public bool RememberMe { get; set; }
    }
}
