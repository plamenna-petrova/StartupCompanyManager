using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Utilities.Interpreter.Context
{
    public class StartupCompanyManagerOperationsContext
    {
        public StartupCompanyManagerOperationsContext(string input)
        {
            Input = input;
        }

        public string Input { get; set; }

        public string Output { get; set; }
    }
}