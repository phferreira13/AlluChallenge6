using MediatR;

namespace Allu.Challenge6.Business.UseCases.Tutores.Update
{
    public class TutorUpdateCommand : IRequest<TutorResponse>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
