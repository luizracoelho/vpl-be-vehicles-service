using AutoMapper;
using VehiclesService.App.Commands.Brands;
using VehiclesService.Domain.Models;
using VehiclesService.Domain.ViewModels.Brands;
using VehiclesService.Domain.ViewModels.Models;
using VehiclesService.Domain.ViewModels.Vehicles;

namespace VehiclesService.Domain.ViewModels
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region Brand
            CreateMap<Brand, BrandVm>().ReverseMap();
            CreateMap<CreateBrandVm, CreateBrandCommand>();
            CreateMap<CreateBrandVm, UpdateBrandCommand>();
            #endregion

            #region Model
            CreateMap<Model, ModelVm>()
                .ForMember(vm => vm.Brand, opt =>
                {
                    opt.MapFrom(model => model.Brand != null ? model.Brand.Name : "");
                });

            CreateMap<ModelVm, Model>()
                .ForMember(model => model.Brand, opt =>
                {
                    opt.MapFrom(vm => new Brand(vm.Brand, null));
                });
            #endregion

            #region Vehicle
            CreateMap<Vehicle, VehicleVm>().ReverseMap();
            #endregion
        }
    }
}
