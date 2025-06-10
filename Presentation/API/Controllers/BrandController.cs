using Core.Application.Features.Brand.Commands.Create;
using Core.Application.Features.Brand.Commands.HardDelete;
using Core.Application.Features.Brand.Commands.SoftDelete;
using Core.Application.Features.Brand.Commands.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Api.Controllers
{
    [Route("api/brand")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(BrandCreateRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(BrandUpdateRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpDelete("soft")]
        public async Task<IActionResult> SoftDelete(BrandSoftDeleteRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpDelete("hard")]
        public async Task<IActionResult> HardDelete(BrandHardDeleteRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}