using System.ComponentModel.DataAnnotations;

namespace VehiclesService.Domain.ViewModels.Brands
{
    public class CreateBrandVm
    {
        [Required]
        public string Name { get; set; }

        public string? Logo { get; set; }
    }
}
