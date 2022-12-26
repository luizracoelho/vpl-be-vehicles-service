using VehiclesService.Domain.Enums;

namespace VehiclesService.Domain.Models
{
    public sealed class Vehicle : BaseDomain
    {
        #region Properties
        public long BrandId { get; private set; }
        public Brand Brand { get; private set; }
        public long ModelId { get; private set; }
        public Model Model { get; private set; }
        public string Name { get; private set; }
        public int ProductionYear { get; private set; }
        public int ModelYear { get; private set; }
        public VehicleType Type { get; private set; }
        #endregion

        #region Constructors
        private Vehicle() { }

        public Vehicle(long brandId, long modelId, string name, int productionYear, int modelYear, VehicleType type)
            => Update(brandId, modelId, name, productionYear, modelYear, type);
        #endregion

        #region Methods
        public override bool Validate()
        {
            return BrandId > 0 && ModelId > 0 && !string.IsNullOrWhiteSpace(Name) && ProductionYear > 1900 && ModelYear > 1900;
        }

        public void Update(long brandId, long modelId, string name, int productionYear, int modelYear, VehicleType type)
        {
            BrandId = brandId;
            ModelId = modelId;
            Name = name;
            ProductionYear = productionYear;
            ModelYear = modelYear;
            Type = type;
        }

        public override string ToString() => $"{Name} | {ProductionYear}/{ModelYear}";
        #endregion
    }
}
