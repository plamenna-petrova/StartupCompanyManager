namespace StartupCompanyManager.Models.Interfaces
{
    public interface IBaseModel<TKey>
    {
        TKey Id { get; set; }
    }
}