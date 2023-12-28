using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartupCompanyManager.Models.Composite.Component;

namespace StartupCompanyManager.Models.Composite.Leafs
{
    public class Specialist : Employee
    {
        public Specialist(string firstName, string lastName, string position, int yearsOfWorkExperience, decimal salary)
            : base(firstName, lastName, position, yearsOfWorkExperience, salary)
        {
        }

        public override void Add(Employee employee)
        {
            throw new NotImplementedException();
        }

        public override void GetHierarchicalLevel(int depthIndicator)
        {
            throw new NotImplementedException();
        }

        public override void Remove(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
