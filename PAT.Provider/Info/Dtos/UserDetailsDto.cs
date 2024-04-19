using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAT.Provider.Info.Dtos
{
    public class UserDetailsDto
    {
        public int id { get; set; }
        public int UserId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string familyName { get; set; }
        public int? governmentId { get; set; }
        public int positionId { get; set; }
        public int educitionalAdministrationId { get; set; }
        public string teacherCode { get; set; }
        public string Mobile { get; set; }
        public string nationalId { get; set; }
    }
}
