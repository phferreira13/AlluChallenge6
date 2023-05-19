using Allu.Challenge6.Domain.Repositories;
using MediatR;

namespace Allu.Challenge6.Business.UseCases.Tutores.Add
{
    public class TutorAddHandler : TutorBaseHandler, IRequestHandler<TutorAddCommand, TutorResponse>
    {
        public TutorAddHandler(ITutorRepository repository) : base(repository)
        {
        }

        public async Task<TutorResponse> Handle(TutorAddCommand request, CancellationToken cancellationToken)
        {
            var tutorToInsert = request.GetTutor();
            await _repository.AddAsync(tutorToInsert);
            return tutorToInsert;
        }
    }
}
