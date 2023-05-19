
using Allu.Challenge6.Domain.Repositories;

namespace Allu.Challenge6.Business.UseCases.Tutores
{
    public abstract class TutorBaseHandler
    {
        protected readonly ITutorRepository _repository;

        protected TutorBaseHandler(ITutorRepository repository)
        {
            _repository = repository;
        }
    }
}
