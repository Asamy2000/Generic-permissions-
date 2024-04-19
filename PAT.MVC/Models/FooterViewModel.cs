using PAT.AccessModel.Models.Info.FooterModels;

namespace PAT.MVC.Models
{
    public class FooterViewModel
    {
        public string LogoName { get; set; }
        public string YotubeLink { get; set; }
        public List<FooterSection> Sections { get; set; } = new List<FooterSection>();
    }
}
