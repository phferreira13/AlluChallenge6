using Allu.Challenge6.Business.UseCases.Tutores;
using Allu.Challenge6.Business.UseCases.Tutores.Add;
using Allu.Challenge6.Business.UseCases.Tutores.Delete;
using Allu.Challenge6.Business.UseCases.Tutores.GetById;
using Allu.Challenge6.Business.UseCases.Tutores.List;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Allu.Challenge6.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TutorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TutorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<TutorResponse> TutorAddAsync([FromBody] TutorAddCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TutorResponse>> GetTutorAsync(int id)
        {
            var query = new TutorGetByIdQuery { Id = id };
            var tutor = await _mediator.Send(query);
            if (tutor == null) return NotFound();
            return Ok(tutor);
        }

        [HttpGet]
        public async Task<TutorListResponse> GetTutorListAsync()
        {
            return await _mediator.Send(new TutorListQuery());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TutorResponse>> DeleteTutorAsync(int id)
        {
            var command = new TutorDeleteCommand { Id = id };
            var tutor = await _mediator.Send(command);
            if (tutor == null) return NotFound();
            return Ok(tutor);
        }
    }
}
