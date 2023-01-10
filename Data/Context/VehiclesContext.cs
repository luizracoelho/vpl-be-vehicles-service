using Microsoft.EntityFrameworkCore;
using VehiclesService.Domain.Contracts.Context;
using VehiclesService.Domain.Models;

namespace VehiclesService.Data.Context
{
    public class VehiclesContext : DbContext, IDataContext
    {
        public VehiclesContext(DbContextOptions<VehiclesContext> options) : base(options)
        {
            //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            //ChangeTracker.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VehiclesContext).Assembly);
        }

        #region DbSets
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        #endregion
    }
}
