using MediatR;

namespace Allu.Challenge6.Business.UseCases.Tutores.Delete
{
    public class TutorDeleteCommand : IRequest<TutorResponse>
    {
        public int Id { get; set; }
    }
}
