using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Infrastructure.Exceptions
{
    public class ExistingStartupCompanyException : Exception
    {
        public ExistingStartupCompanyException()
        {
            
        }

        public ExistingStartupCompanyException(string message) : base(message)
        {
            
        }
    }
}
