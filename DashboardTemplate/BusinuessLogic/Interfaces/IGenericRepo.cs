using PAT.AccessModel.Models.Info;
using System.Linq.Expressions;

namespace DashboardTemplate.BusinuessLogic.Interfaces
{
    public interface IGenericRepo<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        IQueryable<T> GetAllQueryable();
        Task<T> GetBYIdAsync(int id);

        Task<IReadOnlyList<T>> GetAllWithSpecAsync(params Expression<Func<T, object>>[] includes);
        Task<TEntity> GetById<TEntity>(int id, params Expression<Func<TEntity, object>>[] includes) where TEntity : BaseEntity;

        Task Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
