using Microsoft.AspNetCore.Mvc.Rendering;

namespace PAT.Provider.Info.Dtos
{
    public class BranchToReturnDto
    {
        public int BranchId { get; set; }
        public IEnumerable<SelectListItem> BranchesDrobDownItems { get; set; } = new List<SelectListItem>();

    }
}
