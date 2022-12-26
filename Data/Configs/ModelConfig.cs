using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehiclesService.Domain.Models;

namespace VehiclesService.Data.Configs
{
    public class ModelConfig : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(model => model.Brand)
                   .WithMany(brand => brand.Models)
                   .HasForeignKey(model => model.BrandId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
