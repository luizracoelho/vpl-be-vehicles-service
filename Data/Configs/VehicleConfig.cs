using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehiclesService.Domain.Models;

namespace VehiclesService.Data.Configs
{
    public class VehicleConfig : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
           builder.HasKey(x => x.Id);

            builder.HasOne(v => v.Model)
                   .WithMany(m => m.Vehicles)
                   .HasForeignKey(v => v.ModelId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(v => v.Brand)
                   .WithMany(b => b.Vehicles)
                   .HasForeignKey(v => v.BrandId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
