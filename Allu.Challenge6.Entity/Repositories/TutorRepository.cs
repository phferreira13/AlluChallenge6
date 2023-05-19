using Allu.Challenge6.Data.Context;
using Allu.Challenge6.Data.Entities;
using Allu.Challenge6.Domain.Repositories;
using Allu.Challenge6.Entity.Repositories.BaseRepository;

namespace Allu.Challenge6.Entity.Repositories
{
    public class TutorRepository : BaseRepositoryCRUD<Tutor>, ITutorRepository
    {
        public TutorRepository(Challenge6Context context) : base(context, context.Tutores)
        {
        }
    }
}
