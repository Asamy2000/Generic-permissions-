using DashboardTemplate.BusinuessLogic.Interfaces;
using Microsoft.EntityFrameworkCore;
using PAT.AccessModel.Models;
using PAT.AccessModel.Models.Info;
using System.Linq.Expressions;

namespace DashboardTemplate.BusinuessLogic.Repos
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly DBContext _context;

        public GenericRepo(DBContext context)
        {
            _context = context;
        }


        public async Task<IReadOnlyList<T>> GetAllAsync()
            => await _context.Set<T>().ToListAsync();

        public async Task<T> GetBYIdAsync(int id)
            => await _context.Set<T>().FindAsync(id);


        public async Task Add(T entity)
             => await _context.Set<T>().AddAsync(entity);

        public void Update(T entity)
             => _context.Set<T>().Update(entity);

        public void Delete(T entity)
             => _context.Set<T>().Remove(entity);



        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            var entities = await query.ToListAsync();

            return entities;
        }

        public async Task<TEntity> GetById<TEntity>(int id, params Expression<Func<TEntity, object>>[] includes) where TEntity : BaseEntity
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            var entity = await query.FirstOrDefaultAsync(e => e.Id == id);

            return entity;
        }

        public IQueryable<T> GetAllQueryable()
            => _context.Set<T>().AsQueryable();

    }
}
