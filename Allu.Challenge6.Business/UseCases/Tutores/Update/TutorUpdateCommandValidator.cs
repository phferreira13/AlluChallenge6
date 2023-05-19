using FluentValidation;
namespace Allu.Challenge6.Business.UseCases.Tutores.Update
{
    public class TutorUpdateCommandValidator : AbstractValidator<TutorUpdateCommand>
    {
        public TutorUpdateCommandValidator()
        {
            RuleFor(command => command.Nome).NotEmpty();
            RuleFor(command => command.Email).NotEmpty().EmailAddress();
            RuleFor(command => command.Senha).NotEmpty().MinimumLength(6);
        }
    }
}
