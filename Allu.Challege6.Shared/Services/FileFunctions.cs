using Allu.Challege6.Shared.Constants;

namespace Allu.Challege6.Shared.Services
{
    public static class FileStorageService
    {
        public static async Task<string> SaveFileAsync(Stream fileStream, string targetFolderPath, string fileName)
        {
            if (fileStream == null || fileStream.Length == 0)
            {
                throw new ArgumentException("O arquivo fornecido é inválido ou vazio.");
            }

            // Crie um nome de arquivo único com base no Tutor que está sendo atualizado
            string uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(fileName)}";

            // Construa o caminho completo para a pasta de destino
            string folderPathRelative = Path.Combine(targetFolderPath, uniqueFileName);

            string folderPath = Path.Combine(Environment.CurrentDirectory, Folders.PICTURES, targetFolderPath);

            // Crie a pasta de destino, caso ela não exista
            Directory.CreateDirectory(folderPath);

            // Construa o caminho completo para o arquivo
            string filePath = Path.Combine(folderPath, uniqueFileName);

            // Salve o arquivo no caminho especificado
            using (var outputFileStream = new FileStream(filePath, FileMode.Create))
            {
                await fileStream.CopyToAsync(outputFileStream);
            }

            return folderPathRelative;
        }
    }
}
