using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace PAT.Provider.Info.Dtos
{
    public class ContactUsDto
    {
        public int ContactUsTopicId { get; set; }
        public IEnumerable<SelectListItem> ContactUsTopicDrobDownItems { get; set; } = new List<SelectListItem>();
        public string Name { get; set; } = default!;

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } = default!;
        public string Message { get; set; } = default!;
    }
}
