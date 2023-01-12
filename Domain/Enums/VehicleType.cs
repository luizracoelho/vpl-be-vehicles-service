using System.ComponentModel;

namespace VehiclesService.Domain.Enums
{
    public enum VehicleType
    {
        [Description("Carro")]
        Car = 1,
        [Description("Moto")]
        Moto = 2,
        [Description("Ônibus")]
        Bus = 3,
        [Description("Caminhão")]
        Truck = 4,
        [Description("Van")]
        Van = 5
    }
}
