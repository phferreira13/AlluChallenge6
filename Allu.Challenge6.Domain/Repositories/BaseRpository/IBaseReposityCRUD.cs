namespace Allu.Challenge6.Domain.Repositories.BaseRpository
{
    public interface IBaseReposityCRUD<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T data);
        Task UpdateAsync(T data);
        Task DeleteAsync(T data);
    }
}
