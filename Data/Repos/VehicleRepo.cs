using Microsoft.EntityFrameworkCore;
using VehiclesService.Data.Context;
using VehiclesService.Domain.Contracts.Repos;
using VehiclesService.Domain.Models;

namespace VehiclesService.Data.Repos
{
    public class VehicleRepo : BaseRepo<Vehicle>, IVehicleRepo
    {
        public VehicleRepo(VehiclesContext context) : base(context) { }

        public async Task<IList<Vehicle>> ListByBrandAsync(long brandId)
            => await dbSet.Where(x => x.BrandId == brandId).ToListAsync();

        public async Task<IList<Vehicle>> ListByModelAsync(long modelId)
            => await dbSet.Where(x => x.ModelId == modelId).ToListAsync();
    }
}
