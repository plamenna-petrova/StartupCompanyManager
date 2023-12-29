using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Infrastructure.Exceptions
{
    public class ExistingStartupCompanyManagerEntityException : Exception
    {
        public ExistingStartupCompanyManagerEntityException()
        {
            
        }

        public ExistingStartupCompanyManagerEntityException(string message) : base(message)
        {
            
        }
    }
}
