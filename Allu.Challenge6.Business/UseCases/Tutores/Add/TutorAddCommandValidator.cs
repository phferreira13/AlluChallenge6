using FluentValidation;

namespace Allu.Challenge6.Business.UseCases.Tutores.Add
{
    public class TutorAddCommandValidator : AbstractValidator<TutorAddCommand>
    {
        public TutorAddCommandValidator()
        {
            RuleFor(command => command.Nome).NotEmpty();
            RuleFor(command => command.Email).NotEmpty().EmailAddress();
            RuleFor(command => command.Senha).NotEmpty().MinimumLength(6);
        }
    }
}
