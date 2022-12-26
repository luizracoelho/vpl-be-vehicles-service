using VehiclesService.Data.Context;
using VehiclesService.Data.Repos;
using VehiclesService.Domain.Contracts;
using VehiclesService.Domain.Contracts.Repos;

namespace VehiclesService.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VehiclesContext _context;
        public UnitOfWork(VehiclesContext context) => _context = context;

        #region Repos
        private BrandRepo _brandRepo;
        public IBrandRepo Brands => _brandRepo ??= new BrandRepo(_context);

        private ModelRepo _modelRepo;
        public IModelRepo Models => _modelRepo ??= new ModelRepo(_context);

        private VehicleRepo _vehicleRepo;
        public IVehicleRepo Vehicles => _vehicleRepo ??= new VehicleRepo(_context);
        #endregion

        #region Methods
        public async Task Commit() => await _context.SaveChangesAsync();

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
