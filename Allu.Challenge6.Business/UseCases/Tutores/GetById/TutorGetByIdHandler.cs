using Allu.Challenge6.Domain.Repositories;
using MediatR;

namespace Allu.Challenge6.Business.UseCases.Tutores.GetById
{
    public class TutorGetByIdHandler : IRequestHandler<TutorGetByIdQuery, TutorResponse>
    {
        private readonly ITutorRepository _repository;
        public TutorGetByIdHandler(ITutorRepository repository)
        {
            _repository = repository;
        }

        public async Task<TutorResponse> Handle(TutorGetByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}
