using Allu.Challege6.Shared.Constants;
using Allu.Challege6.Shared.Services;
using Allu.Challenge6.Business.UseCases.Tutores;
using Allu.Challenge6.Business.UseCases.Tutores.Add;
using Allu.Challenge6.Business.UseCases.Tutores.Delete;
using Allu.Challenge6.Business.UseCases.Tutores.GetById;
using Allu.Challenge6.Business.UseCases.Tutores.List;
using Allu.Challenge6.Business.UseCases.Tutores.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Allu.Challenge6.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

        [HttpPatch("{id}")]
        public async Task<ActionResult<TutorResponse>> UpdateTutorAsync(int id, [FromForm] TutorUpdateCommand command, IFormFile? profilePicture)
        {
            try
            {
                if (command.Id != id)
                {
                    return BadRequest("O ID fornecido não corresponde ao ID no comando.");
                }

                var validator = new TutorUpdateCommandValidator();
                var validationResult = validator.Validate(command);
                if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

                if (profilePicture != null)
                {
                    if (profilePicture.Length > 10 * 1024 * 1024) // Verifica se o tamanho do arquivo é maior que 10MB
                    {
                        return BadRequest("O tamanho máximo do arquivo é de 10MB.");
                    }
                    
                    var pathFile = await FileStorageService.SaveFileAsync(profilePicture.OpenReadStream(), Folders.PROFILE_PICTURES, profilePicture.FileName);
                    command.ProfilePicture = pathFile;
                }

                var tutor = await _mediator.Send(command);
                if (tutor == null) return NotFound();
                return Ok(tutor);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro ao atualizar o Tutor: {ex.Message}");
            }

        }
    }
}
