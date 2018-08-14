using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RenewableEnergyCredits.Models
{
    public class Program
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UniversityId { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public string Degree { get; set; }
        public string Year { get; set; }
    }
}
