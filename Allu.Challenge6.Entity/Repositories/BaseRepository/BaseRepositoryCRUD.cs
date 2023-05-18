using Allu.Challenge6.Data.Context;
using Allu.Challenge6.Domain.Repositories.BaseRpository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allu.Challenge6.Entity.Repositories.BaseRepository
{
    public class BaseRepositoryCRUD<T> : IBaseReposityCRUD<T> where T : class
    {
        protected readonly Challenge6Context _context;
        private readonly DbSet<T> _dbSet;
        public BaseRepositoryCRUD(Challenge6Context context, DbSet<T> dbSet)
        {
            _context = context;
            _dbSet = dbSet;
        }

        public async Task AddAsync(T data)
        {
            await _dbSet.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T data)
        {
            _dbSet.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(T data)
        {
            _dbSet.Update(data);
            await _context.SaveChangesAsync();
        }
    }
}
