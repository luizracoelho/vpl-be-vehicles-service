using System.ComponentModel.DataAnnotations;
using VehiclesService.Domain.Enums;

namespace VehiclesService.Domain.ViewModels.Vehicles
{
    public class CreateVehicleVm
    {
        [Required]
        public long BrandId { get; set; }

        [Required]
        public long ModelId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int ProductionYear { get; set; }

        [Required]
        public int ModelYear { get; set; }

        [Required]
        public VehicleType Type { get; set; }
    }
}
