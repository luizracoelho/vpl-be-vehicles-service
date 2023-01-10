using VehiclesService.Domain.Enums;

namespace VehiclesService.Domain.ViewModels.Models
{
    public class ModelVm
    {
        public long Id { get; set; }
        public long BrandId { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public VehicleType Type { get; set; }
        public DateTime ProductionStart { get; set; }
        public DateTime? ProductionEnd { get; set; }
        public bool ProductionEnded { get; set; }
    }
}
