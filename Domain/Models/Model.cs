using VehiclesService.Domain.Enums;

namespace VehiclesService.Domain.Models
{
    public sealed class Model : BaseDomain
    {
        #region Properties
        public long BrandId { get; private set; }
        public Brand? Brand { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public VehicleType Type { get; private set; }
        public DateTime ProductionStart { get; private set; }
        public DateTime? ProductionEnd { get; private set; }
        public bool ProductionEnded { get; private set; }
        public IList<Vehicle> Vehicles { get; private set; }
        #endregion

        #region Contructors
        private Model() { }

        public Model(long brandId, string name, string description, VehicleType type, DateTime productionStart, DateTime? productionEnd, bool productionEnded)
        {
            Update(brandId, name, description, type, productionStart);

            ProductionEnd = productionEnd;
            ProductionEnded = productionEnded;
        }
        #endregion

        #region Methods
        public override bool Validate()
        {
            return BrandId > 0 && !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Description);
        }

        public void Update(long brandId, string name, string description, VehicleType type, DateTime productionStart)
        {
            BrandId = brandId;
            Name = name;
            Description = description;
            Type = type;
            ProductionStart = productionStart;
        }

        public void EndProduction(DateTime productionEnd)
        {
            ProductionEnd = productionEnd;
            ProductionEnded = true;
        }

        public override string ToString() => Name;
        #endregion
    }
}
