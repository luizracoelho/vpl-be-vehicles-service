using VehiclesService.Domain.Models;

namespace VehiclesService.Domain.Contracts.Repos
{
    public interface IModelRepo : IBaseRepo<Model>
    {
        Task<IList<Model>> ListByBrandAsync(long brandId);
    }
}
