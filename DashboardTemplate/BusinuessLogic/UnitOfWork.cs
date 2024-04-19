using DashboardTemplate.BusinuessLogic.Interfaces;
using DashboardTemplate.BusinuessLogic.Repos;
using Microsoft.EntityFrameworkCore;
using PAT.AccessModel.Models;
using System.Collections;

namespace DashboardTemplate.BusinuessLogic
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DBContext _context;

        private Hashtable _repositories;
        private Dictionary<object, DbSet<object>> addedEntities = new Dictionary<object, DbSet<object>>();
        private Dictionary<object, DbSet<object>> modifiedEntities = new Dictionary<object, DbSet<object>>();
        private List<object> deletedEntities = new List<object>();

        public UnitOfWork(DBContext context)
        {
            _context = context;
        }
        public IGenericRepo<TEntity> Repository<TEntity>() where TEntity : class
        {
            //initialize if first request
            if (_repositories == null)
                _repositories = new Hashtable();

            //Get the entity type
            var type = typeof(TEntity).Name;

            //if the repo is not exist create and add it to the hashTable
            if (!_repositories.ContainsKey(type))
            {
                var repository = new GenericRepo<TEntity>(_context);
                _repositories.Add(type, repository);
            }
            //return the repo [cast from obj to IGenericRepo<TEntity>]
            return _repositories[type] as IGenericRepo<TEntity>;
        }

        public async Task<int> Complete()
        {

            foreach (var entity in deletedEntities)
            {
                _context.Entry(entity).State = EntityState.Deleted;
            }

            var result = await _context.SaveChangesAsync();

            ClearTracking();

            return result;
        }

        public void Rollback()
        {
            ClearTracking();
        }

        public async ValueTask DisposeAsync()
          => await _context.DisposeAsync();

        public void RegisterRemoved<TEntity>(TEntity entity) where TEntity : class
        {
            var set = _context.Set<TEntity>();
            if (addedEntities.ContainsKey(entity))
            {
                addedEntities.Remove(entity);
                return;
            }

            if (modifiedEntities.ContainsKey(entity))
            {
                modifiedEntities.Remove(entity);
                return;
            }

            deletedEntities.Add(entity);
        }

        private void ClearTracking()
        {
            addedEntities.Clear();
            modifiedEntities.Clear();
            deletedEntities.Clear();
        }
    }
}
