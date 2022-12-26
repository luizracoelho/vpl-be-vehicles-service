using VehiclesService.Domain.Contracts.Repos;

namespace VehiclesService.Domain.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        #region Repos
        IBrandRepo Brands { get;}
        IModelRepo Models { get; }
        IVehicleRepo Vehicles { get; }
        #endregion

        #region Methods
        Task Commit();
        #endregion
    }
}
