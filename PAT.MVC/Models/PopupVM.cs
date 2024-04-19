using Microsoft.AspNetCore.Mvc.Rendering;
using PAT.AccessModel.Models.Info;

namespace PAT.MVC.Models
{
    public class PopupVM
    {
        public List<FAQModel> FAQModels { get; set; } = new List<FAQModel>();
        public int TypeId { get; set; }
        public IEnumerable<SelectListItem> Types { get; set; }
        public int BranchId { get; set; }
        public IEnumerable<SelectListItem> Branches { get; set; }
        public string Topic { get; set; }
        public string MessageBody { get; set; }

        public int FAQTypeId { get; set; }
        public IEnumerable<SelectListItem> FAQTypes { get; set; }
    }
}
