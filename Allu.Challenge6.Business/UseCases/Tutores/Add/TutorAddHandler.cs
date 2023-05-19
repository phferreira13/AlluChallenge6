using Allu.Challenge6.Domain.Repositories;
using MediatR;

namespace Allu.Challenge6.Business.UseCases.Tutores.Add
{
    public class TutorAddHandler : IRequestHandler<TutorAddCommand, TutorResponse>
    {
        private readonly ITutorRepository _repository;
        public TutorAddHandler(ITutorRepository repository)
        {
            _repository = repository;
        }

        public async Task<TutorResponse> Handle(TutorAddCommand request, CancellationToken cancellationToken)
        {
            var tutorToInsert = request.GetTutor();
            await _repository.AddAsync(tutorToInsert);
            return tutorToInsert;
        }
    }
}
