using DashboardTemplate.BusinuessLogic.Interfaces;

namespace DashboardTemplate.BusinuessLogic
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IGenericRepo<TEntity> Repository<TEntity>() where TEntity : class;
        Task<int> Complete();
        public void Rollback();
    }
}
