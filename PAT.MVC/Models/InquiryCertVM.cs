using PAT.AccessModel.Enums;
using PAT.AccessModel.Models.Info;

namespace PAT.MVC.Models
{
    public class InquiryCertVM
    {
        public string IMagePath { get; set; }
        public List<CertificateProcedureCategory> CertificateProceduresList { get; set; }

        public string CertificateSerial { get; set; }


    }
}
