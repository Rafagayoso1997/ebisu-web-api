using EbisuWebApi.Domain.RepositoryContracts.Contracts;
using EbisuWebApi.Infrastructure.Persistence.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Infrastructure.Repositories.Implementations
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DatabaseContext _context;

        protected GenericRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<T> Add(T entity)
        {
            var result = await _context.Set<T>().AddAsync(entity);
            return result.Entity;
        }

        public async Task<T> Delete(int id)
        {
            var entityT = await GetEntity(id);
            var result = _context.Set<T>().Remove(entityT);
            return result.Entity;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetEntity(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> Update(T entity)
        {
            var result = _context.Set<T>().Update(entity);
            return result.Entity;
        }
    }
}
