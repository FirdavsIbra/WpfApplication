using Examination.Data.DbContexts;
using Examination.Domain.Entities.Commons;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Data.Repositories.GenericRepo
{
    public class GenericRepository<T> where T : Auditable
    {
        private readonly ExaminationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ExaminationDbContext airportSystemContext)
        {
            _context = airportSystemContext;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
            => (await _dbSet.AddAsync(entity)).Entity;

        public async Task<bool> DeleteAsync(Expression<Func<T, bool>> expression)
        {
            var entity = await GetAsync(expression);

            if (entity is null)
            {
                return false;
            }
            _dbSet.Remove(entity);

            return true;
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> expression)
            => _dbSet.FirstOrDefaultAsync(expression);

        public T UpdateAsync(T entity)
            => _dbSet.Update(entity).Entity;

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression = null)
            => expression is null ? _dbSet : _dbSet.Where(expression);


    }
}
