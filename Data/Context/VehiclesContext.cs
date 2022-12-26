using Microsoft.EntityFrameworkCore;
using VehiclesService.Domain.Contracts.Context;
using VehiclesService.Domain.Models;

namespace VehiclesService.Data.Context
{
    public class VehiclesContext : DbContext, IDataContext
    {
        public VehiclesContext(DbContextOptions<VehiclesContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VehiclesContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        #region DbSets
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        #endregion
    }
}
