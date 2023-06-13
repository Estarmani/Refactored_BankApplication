using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Data
{
    public class Activity
    {
        public string Description { get; set; }
        public DateTime ActivityDate { get; set; }
        public decimal ActivityAmount { get; set; }
        public decimal ActivityBalance { get; set; }
    }
}
