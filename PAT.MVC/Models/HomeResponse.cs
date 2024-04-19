using PAT.AccessModel.Models.Info;
using PAT.AccessModel.Models.StatisticsModels;

namespace PAT.MVC.Models
{
    public class HomeResponse
    {
        public Carousal Carousal { get; set; }
        public List<StatItem> StatItems { get; set; } = new List<StatItem>();
    }
}
