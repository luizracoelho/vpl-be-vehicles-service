using VehiclesService.Domain.Models;

namespace VehiclesService.Domain.Contracts.Repos
{
    public interface IVehicleRepo : IBaseRepo<Vehicle>
    {
        Task<IList<Vehicle>> ListByModelAsync(long modelId);
        Task<IList<Vehicle>> ListByBrandAsync(long brandId);
    }
}
