using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RenewableEnergyCredits.Models
{
    public class TransactionsRequest
    {
        public DateTime BeforeDateTime  { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
    }
}
