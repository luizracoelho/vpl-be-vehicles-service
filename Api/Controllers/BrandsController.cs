using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehiclesService.App.Commands.Brands;
using VehiclesService.App.Queries.Brands;
using VehiclesService.Domain.ViewModels;
using VehiclesService.Domain.ViewModels.Brands;

namespace VehiclesService.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class BrandsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public BrandsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IList<BrandVm>?> List()
        {
            return await _mediator.Send(new ListBrandsQuery());
        }

        [HttpGet("{id}")]
        public async Task<BrandVm?> Find(long id)
        {
            return await _mediator.Send(new FindBrandByIdQuery
            {
                Id = id
            });
        }

        [HttpPost]
        public async Task<BrandVm> Create([FromBody] CreateBrandVm brand)
        {
            var command = _mapper.Map<CreateBrandCommand>(brand);

            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<BrandVm> Update(long id, [FromBody] CreateBrandVm brand)
        {
            var command = _mapper.Map<UpdateBrandCommand>(brand);
            command.Id = id;

            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<RemoveResultVm> Remove(long id)
        {
            return await _mediator.Send(new RemoveBrandCommand
            {
                Id = id
            });
        }
    }
}
