using Allu.Challenge6.Data.Entities;
using MediatR;

namespace Allu.Challenge6.Business.UseCases.Tutores.Add
{
    public class TutorAddCommand : IRequest<TutorResponse>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Tutor GetTutor()
            => new Tutor(Nome, Email, Senha);
    }
}
