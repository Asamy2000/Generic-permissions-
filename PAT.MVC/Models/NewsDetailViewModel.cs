using PAT.AccessModel.Models.Info;

namespace PAT.MVC.Models
{
    public class NewsDetailViewModel
    {
        public AcademyNews CurrentNews { get; set; } = default!;
        public List<AcademyNews> RelatedNews { get; set; } = new List<AcademyNews>();
    }
}
