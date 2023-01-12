using System.ComponentModel.DataAnnotations;
using VehiclesService.Domain.Enums;

namespace VehiclesService.Domain.ViewModels.Brands
{

    public class BrandVm
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Id do <see href="https://onstock-api.vuptechx.ddns.net">OnStock</see> referente ao logo da marca
        /// </summary>
        public string? Logo { get; set; }
    }
}
