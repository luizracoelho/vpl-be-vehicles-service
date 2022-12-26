using Microsoft.EntityFrameworkCore;
using VehiclesService.Data.Context;
using VehiclesService.Domain.Contracts.Repos;
using VehiclesService.Domain.Models;

namespace VehiclesService.Data.Repos
{
    public class ModelRepo : BaseRepo<Model>, IModelRepo
    {
        public ModelRepo(VehiclesContext context) : base(context) { }

        public async Task<IList<Model>> ListByBrandAsync(long brandId) 
            => await dbSet.Where(model => model.BrandId == brandId).ToListAsync();
    }
}
