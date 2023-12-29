using StartupCompanyManager.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Models
{
    public class Investor : BaseModel
    {
        public Investor(string name, decimal funds)
        {
            Name = name;
            Funds = funds;
        }

        public string Name { get; set; }

        public decimal Funds { get; set; }
    }
}
