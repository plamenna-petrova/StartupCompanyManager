using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupCompanyManager.Models.Interfaces
{
    public interface IBaseModel<TKey>
    {
        TKey Id { get; set; }
    }
}
