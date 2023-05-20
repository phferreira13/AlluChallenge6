using MediatR;

namespace Allu.Challenge6.Business.UseCases.Tutores.Update
{
    public class TutorUpdateCommand : IRequest<TutorResponse>
    {
        public int Id { get; set; }
        public string? ProfilePicture { get; set; }
        public string Nome { get; set; }
        public string? Telefone { get; set; }
        public string? Cidade { get; set; }
        public string? Sobre { get; set; }
    }
}
