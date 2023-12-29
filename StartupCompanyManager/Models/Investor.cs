using StartupCompanyManager.Models.Abstraction;

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
