using System.ComponentModel.DataAnnotations;

namespace VehiclesService.Domain.ViewModels.Models
{
    public class EndProductionModelVm
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public DateTime ProductionEnd { get; set; }
    }
}
