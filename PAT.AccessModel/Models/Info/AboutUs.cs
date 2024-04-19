using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAT.AccessModel.Models.Info
{
    public class AboutUs
    {
        public int id { get; set; }
        public string Vision { get; set; } = "Vision";
        public string Mission { get; set; } = "Mission";
        public string Responsibilities { get; set; } = "Vision.Misiion";
        public string History { get; set; } = "drop it";

        [ForeignKey("User")]
        public int CreatedBy { get; set; }
        public User User { get; set; }
    }
}
