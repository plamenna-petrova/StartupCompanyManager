using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Infrastructure.Exceptions
{
    public class NonExistingStartupCompanyException : Exception
    {
        public NonExistingStartupCompanyException() 
        {
            
        }

        public NonExistingStartupCompanyException(string message) : base(message)
        {
            
        }
    }
}
