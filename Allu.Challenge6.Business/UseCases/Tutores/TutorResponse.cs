using Allu.Challenge6.Data.Entities;

namespace Allu.Challenge6.Business.UseCases.Tutores
{
    public class TutorResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public static implicit operator TutorResponse(Tutor? tutor)
        {
            if (tutor == null) return null;
            return new TutorResponse
            {
                Id = tutor.Id,
                Nome = tutor.Nome,
                Email = tutor.Email,
                Senha = tutor.Senha,
            };
        }
    }
}
