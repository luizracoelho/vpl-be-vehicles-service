using VehiclesService.Data.Context;
using VehiclesService.Domain.Contracts.Repos;
using VehiclesService.Domain.Models;

namespace VehiclesService.Data.Repos
{
    public class BrandRepo : BaseRepo<Brand>, IBrandRepo
    {
        public BrandRepo(VehiclesContext context) : base(context) { }
    }
}
