using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Infrastructure.Exceptions
{
    public class NonExistingStartupCompanyManagerEntityException : Exception
    {
        public NonExistingStartupCompanyManagerEntityException() 
        {
            
        }

        public NonExistingStartupCompanyManagerEntityException(string message) : base(message)
        {
            
        }
    }
}
