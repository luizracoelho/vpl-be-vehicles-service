using Microsoft.EntityFrameworkCore;

namespace VehiclesService.Domain.Contracts.Context
{
    public interface IDataContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
