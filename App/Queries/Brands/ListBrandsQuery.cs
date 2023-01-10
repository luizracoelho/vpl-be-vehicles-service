using AutoMapper;
using MediatR;
using VehiclesService.Domain.Contracts;
using VehiclesService.Domain.ViewModels.Brands;

namespace VehiclesService.App.Queries.Brands
{
    public class ListBrandsQuery : IRequest<IList<BrandVm>>
    {
        public class ListBrandsQueryHandler : IRequestHandler<ListBrandsQuery, IList<BrandVm>>
        {
            private readonly IUnitOfWork _uow;
            private readonly IMapper _mapper;
            public ListBrandsQueryHandler(IUnitOfWork uow, IMapper mapper)
            {
                _uow = uow;
                _mapper = mapper;
            }

            public async Task<IList<BrandVm>> Handle(ListBrandsQuery request, CancellationToken cancellationToken)
            {
                var brands = await _uow.Brands.ListAsync();

                return _mapper.Map<IList<BrandVm>>(brands);
            }
        }
    }
}
