using AutoMapper;
using MediatR;
using VehiclesService.Domain.Contracts;
using VehiclesService.Domain.Models;
using VehiclesService.Domain.ViewModels.Brands;

namespace VehiclesService.App.Commands.Brands
{
    public class CreateBrandCommand : IRequest<BrandVm>
    {
        public string Name { get; set; }
        public string? Logo { get; set; }

        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, BrandVm>
        {
            private readonly IUnitOfWork _uow;
            private readonly IMapper _mapper;
            public CreateBrandCommandHandler(IUnitOfWork uow, IMapper mapper)
            {
                _uow = uow;
                _mapper = mapper;
            }

            public async Task<BrandVm> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                var brand = new Brand(request.Name, request.Logo);

                if (!brand.Validate())
                    throw new Exception("Marca inválida.");

                await _uow.Brands.AddAsync(brand);

                await _uow.Commit();

                return _mapper.Map<BrandVm>(brand);
            }
        }
    }
}
