using ConnectorResource.Core.Entities;

namespace ConnectorResource.Api.Services
{
    public interface IMedicineService
    {
        Task CreateAsync(Medicine medicine);
        Task UpdateAsync(Medicine medicine);
        Task DeleteAsync(string Id);
        Task<Medicine> GetAsync(string Id);
        Task<IEnumerable<Medicine>> GetAllAsync();
    }
}
