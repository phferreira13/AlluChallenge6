using Allu.Challenge6.Business.UseCases.Tutores;
using Allu.Challenge6.Business.UseCases.Tutores.Add;
using Allu.Challenge6.Business.UseCases.Tutores.Delete;
using Allu.Challenge6.Business.UseCases.Tutores.GetById;
using Allu.Challenge6.Business.UseCases.Tutores.List;
using Allu.Challenge6.Business.UseCases.Tutores.Update;
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
        public async Task<ActionResult<TutorResponse>> TutorAddAsync([FromBody] TutorAddCommand command)
        {
            var validator = new TutorAddCommandValidator();
            var validationResult = await validator.ValidateAsync(command);
            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);
            var tutor = await _mediator.Send(command);
            return Created("TutorAddAsync", tutor);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TutorResponse>> GetTutorAsync(int id)
        {
            var tutor = await _mediator.Send(new TutorGetByIdQuery { Id = id });
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
            var tutor = await _mediator.Send(new TutorDeleteCommand { Id = id });
            if (tutor == null) return NotFound();
            return Ok(tutor);
        }

        [HttpPut]
        public async Task<ActionResult<TutorResponse>> UpdateTutorAsync(TutorUpdateCommand command)
        {
            var validator = new TutorUpdateCommandValidator();
            var validationResult = validator.Validate(command);
            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            var tutor = await _mediator.Send(command);
            if (tutor == null) return NotFound();
            return Ok(tutor);
        }
    }
}
