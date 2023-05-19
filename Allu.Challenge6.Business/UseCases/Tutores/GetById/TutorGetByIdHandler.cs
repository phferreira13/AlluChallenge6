using Allu.Challenge6.Domain.Repositories;
using MediatR;

namespace Allu.Challenge6.Business.UseCases.Tutores.GetById
{
    public class TutorGetByIdHandler : TutorBaseHandler, IRequestHandler<TutorGetByIdQuery, TutorResponse>
    {
        public TutorGetByIdHandler(ITutorRepository repository) : base(repository)
        {
        }

        public async Task<TutorResponse> Handle(TutorGetByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}
