using StartupCompanyManager.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Models.Abstraction
{
    public class BaseModel : IBaseModel<string>
    {
        public BaseModel()
        {
            Id = Guid.NewGuid().ToString()[..7];
        }

        public string Id { get; set; }
    }
}
