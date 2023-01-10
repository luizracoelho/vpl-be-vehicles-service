using System.ComponentModel.DataAnnotations;
using VehiclesService.Domain.Enums;

namespace VehiclesService.Domain.ViewModels.Models
{
    public class CreateModelVm
    {
        [Required]
        public long BrandId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public VehicleType Type { get; set; }

        [Required]
        public DateTime ProductionStart { get; set; }
    }
}
