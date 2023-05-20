using FluentValidation;
namespace Allu.Challenge6.Business.UseCases.Tutores.Update
{
    public class TutorUpdateCommandValidator : AbstractValidator<TutorUpdateCommand>
    {
        public TutorUpdateCommandValidator()
        {
            RuleFor(command => command.Nome).NotEmpty();
        }
    }
}
