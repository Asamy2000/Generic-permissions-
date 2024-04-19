using Microsoft.AspNetCore.Mvc.Rendering;
using PAT.AccessModel.Models.Info;

namespace PAT.Provider.Info.Dtos
{
    public class NewsToReturnDto
    {

        public int MonthId { get; set; } = default!;
        public IEnumerable<SelectListItem> MonthesList { get; set; } = new List<SelectListItem>();
        public int CategoryId { get; set; } = default!;
        public IEnumerable<SelectListItem> CategoryList { get; set; } = new List<SelectListItem>();
    }
}
