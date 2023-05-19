using MediatR;

namespace Allu.Challenge6.Business.UseCases.Tutores.GetById
{
    public class TutorGetByIdQuery : IRequest<TutorResponse>
    {
        public int Id { get; set; }
    }
}
