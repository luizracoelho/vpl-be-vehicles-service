using AutoMapper;
using MediatR;
using VehiclesService.Domain.Contracts;
using VehiclesService.Domain.ViewModels.Brands;

namespace VehiclesService.App.Commands.Brands
{
    public class UpdateBrandCommand : IRequest<BrandVm>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? Logo { get; set; }

        public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, BrandVm>
        {
            private readonly IUnitOfWork _uow;
            private readonly IMapper _mapper;
            public UpdateBrandCommandHandler(IUnitOfWork uow, IMapper mapper)
            {
                _uow = uow;
                _mapper = mapper;
            }

            public async Task<BrandVm> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
            {
                var brand = await _uow.Brands.FindAsync(request.Id);

                if (brand == null)
                    throw new Exception("Marca não encontrada.");

                brand.Update(request.Name, request.Logo);

                if(!brand.Validate())
                    throw new Exception("Marca inválida.");

                _uow.Brands.Update(brand);

                await _uow.Commit();

                return _mapper.Map<BrandVm>(brand);
            }
        }
    }
}
