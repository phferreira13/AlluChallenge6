using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace Allu.Challenge6.Data.Entities
{
    public class Tutor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo Email deve ser um endereço de email válido.")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        public string Senha { get; private set; }
        public string ProfilePicture { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }
        public string Sobre { get; set; }

        public Tutor(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = Encrypt(senha);
        }

        public void UpdateSenha(string senha)
        {
            Senha = Encrypt(senha);
        }

        private string Encrypt(string input)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                var stringBuilder = new StringBuilder();
                foreach (var hashedByte in hashedBytes)
                {
                    stringBuilder.Append(hashedByte.ToString("x2"));
                }
                return stringBuilder.ToString();
            }
        }
    }
}
