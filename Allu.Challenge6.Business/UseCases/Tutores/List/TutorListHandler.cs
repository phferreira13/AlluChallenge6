using Allu.Challenge6.Domain.Repositories;
using MediatR;

namespace Allu.Challenge6.Business.UseCases.Tutores.List
{
    public class TutorListHandler : IRequestHandler<TutorListQuery, TutorListResponse>
    {
        private ITutorRepository _repository;
        public TutorListHandler(ITutorRepository repository)
        {
            _repository = repository;
        }

        public async Task<TutorListResponse> Handle(TutorListQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.GetAllAsync();
            return new TutorListResponse { Tutors = list.ToList().ConvertAll<TutorResponse>(t => t) };
        }
    }
}
