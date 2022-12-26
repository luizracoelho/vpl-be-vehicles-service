using VehiclesService.Domain.Contracts;

namespace VehiclesService.Domain.Models
{
    public abstract class BaseDomain : IBaseDomain
    {
        #region Properties
        public long Id { get; private set; }
        #endregion

        #region Methods
        public virtual bool Validate() => true;
        #endregion
    }
}
