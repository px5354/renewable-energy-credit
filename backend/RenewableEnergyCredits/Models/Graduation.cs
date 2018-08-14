using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RenewableEnergyCredits.Models
{
    public class Graduation
    {
        public string PermanentCode { get; set; }
        public University University { get; set; }
        public Program Program { get; set; }
        public string GraduationYear { get; set; }
        public decimal Gpa { set; get; }
        
        public override string ToString()
        {
            return $"{PermanentCode}\n\n{University.ShortName}\n\n{Program.Degree}\n\n{Program.ShortName}\n\n{Gpa}\n\n{GraduationYear}";
        }
    }
}
