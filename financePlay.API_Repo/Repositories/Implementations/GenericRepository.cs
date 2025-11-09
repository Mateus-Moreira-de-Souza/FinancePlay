
using financePlay.API.Data;
using financePlay.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace financePlay.API.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly FinancePlayDbContext _ctx;
        protected readonly DbSet<T> _db;

        public GenericRepository(FinancePlayDbContext ctx)
        {
            _ctx = ctx;
            _db = _ctx.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _db.AsNoTracking().ToListAsync();

        public async Task<T?> GetByIdAsync(int id) => await _db.FindAsync(id);

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
            => await _db.Where(predicate).AsNoTracking().ToListAsync();

        public async Task AddAsync(T entity) => await _db.AddAsync(entity);

        public void Update(T entity) => _db.Update(entity);

        public void Remove(T entity) => _db.Remove(entity);
    }
}
