using Microsoft.AspNetCore.Mvc.Rendering;
using PAT.AccessModel.Models.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAT.Provider.Info.Dtos
{
    public class CreateUserDto
    {
        public UserDto User { get; set; }
        public UserDetailsDto UserDetails { get; set; }
        public CreteUserVM CreteUserVM { get; set; }
    }
    public class CreteUserVM
    {
        public IEnumerable<SelectListItem> Governments { get; set; }
        public IEnumerable<SelectListItem> Positions { get; set; }
        public IEnumerable<SelectListItem> EducitionalAdministration { get; set; }
    }
}
