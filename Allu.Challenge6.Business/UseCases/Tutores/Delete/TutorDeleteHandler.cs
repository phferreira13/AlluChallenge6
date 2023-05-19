using Allu.Challenge6.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allu.Challenge6.Business.UseCases.Tutores.Delete
{
    public class TutorDeleteHandler : IRequestHandler<TutorDeleteCommand, TutorResponse>
    {
        private readonly ITutorRepository _repository;
        public TutorDeleteHandler(ITutorRepository repository)
        {
            _repository = repository;
        }

        public async Task<TutorResponse> Handle(TutorDeleteCommand request, CancellationToken cancellationToken)
        {
            var tutor = await _repository.GetByIdAsync(request.Id);
            if (tutor != null) await _repository.DeleteAsync(tutor);
            return tutor;
        }
    }
}
