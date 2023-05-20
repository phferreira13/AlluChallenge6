using Allu.Challenge6.Data.Entities;
using Allu.Challenge6.Domain.Repositories;
using MediatR;

namespace Allu.Challenge6.Business.UseCases.Tutores.Update
{
    public class TutorUpdateHandler : TutorBaseHandler, IRequestHandler<TutorUpdateCommand, TutorResponse>
    {
        public TutorUpdateHandler(ITutorRepository repository) : base(repository)
        {
        }

        public async Task<TutorResponse> Handle(TutorUpdateCommand request, CancellationToken cancellationToken)
        {
            var tutorToUpdate = await _repository.GetByIdAsync(request.Id);
            if (tutorToUpdate == null) return null;
            tutorToUpdate.Nome = request.Nome;
            tutorToUpdate.ProfilePicture = request.ProfilePicture;
            tutorToUpdate.Telefone = request.Telefone;
            tutorToUpdate.Cidade = request.Cidade;
            tutorToUpdate.Sobre = request.Sobre;
            await _repository.UpdateAsync(tutorToUpdate);
            return tutorToUpdate;
        }
    }
}
