using Microsoft.AspNetCore.Mvc.Rendering;

namespace PAT.MVC.Models
{
    public class MessageVM
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime SendDate { get; set; }
        public DateTime ReplyDate { get; set; }
        public int Sender { get; set; }
        public int Reviewer { get; set; }
        public int Type { get; set; }
        public TypeSelectedList TypesList { get; set; }

    }

    public class TypeSelectedList
    {
        public IEnumerable<SelectListItem> Types { get; set; }

    }
}
