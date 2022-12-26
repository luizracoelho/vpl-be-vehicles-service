namespace VehiclesService.Domain.Models
{
    public sealed class Brand : BaseDomain
    {
        #region Proprerties
        public string Name { get; private set; }
        public string? Logo { get; private set; }
        public IList<Model> Models { get; private set; }
        public IList<Vehicle> Vehicles { get; private set; }
        #endregion

        #region Constructors
        private Brand() { }

        public Brand(string name, string? logo) => Update(name, logo);
        #endregion

        #region Methods
        public override bool Validate() => !string.IsNullOrWhiteSpace(Name);

        public void Update(string name, string? logo)
        {
            Name = name;
            Logo = logo;
        }

        public override string ToString() => Name;
        #endregion
    }
}
