using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RenewableEnergyCredits.Models
{
    public class GraduationRequest
    {
        public string PermanentCode { get; set; }
        public string University { get; set; }
        public string Degree { get; set; }
        public string GraduationYear { get; set; }
        public string Program { get; set; }
        public decimal Gpa { set; get; }
    }
}
