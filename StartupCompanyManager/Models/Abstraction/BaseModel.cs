using StartupCompanyManager.Models.Interfaces;

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
