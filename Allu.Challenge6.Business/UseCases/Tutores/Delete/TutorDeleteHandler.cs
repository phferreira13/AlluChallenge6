using Allu.Challenge6.Domain.Repositories;
using MediatR;

namespace Allu.Challenge6.Business.UseCases.Tutores.Delete
{
    public class TutorDeleteHandler : TutorBaseHandler, IRequestHandler<TutorDeleteCommand, TutorResponse>
    {
        public TutorDeleteHandler(ITutorRepository repository) : base(repository)
        {
        }

        public async Task<TutorResponse> Handle(TutorDeleteCommand request, CancellationToken cancellationToken)
        {
            var tutor = await _repository.GetByIdAsync(request.Id);
            if (tutor != null) await _repository.DeleteAsync(tutor);
            return tutor;
        }
    }
}
