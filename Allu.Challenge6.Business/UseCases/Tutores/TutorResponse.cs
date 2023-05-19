using Allu.Challenge6.Business.UseCases.Tutores.Add;
using Allu.Challenge6.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

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
