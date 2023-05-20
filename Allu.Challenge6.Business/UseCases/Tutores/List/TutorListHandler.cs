using Allu.Challenge6.Domain.Repositories;
using MediatR;

namespace Allu.Challenge6.Business.UseCases.Tutores.List
{
    public class TutorListHandler : TutorBaseHandler, IRequestHandler<TutorListQuery, TutorListResponse>
    {
        public TutorListHandler(ITutorRepository repository) : base(repository)
        {
        }

        public async Task<TutorListResponse> Handle(TutorListQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.GetAllAsync();
            return new TutorListResponse { Tutors = list.ToList().ConvertAll<TutorResponse>(t => t) };
        }
    }
}
