using PAT.AccessModel.Models.Info.MenuBarModels;

namespace PAT.MVC.Models
{
    public class MenuViewModel
    {
        public string LogoName { get; set; }
        public List<Dropdown> Dropdowns { get; set; } = new List<Dropdown>();
        public List<MenuLink> MenuLinks { get; set; } = new List<MenuLink>();
    }
}
