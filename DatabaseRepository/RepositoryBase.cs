using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DatabaseRepository.Interfaces;
using System.Data.Entity.Infrastructure;

namespace DatabaseRepository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public readonly DateTime Today = DateTime.Now.Date;

        protected DbContext DbContext { get; set; }

        protected DbSet<T> DbSet { get; set; }

        public RepositoryBase(IDatabaseFactory databaseFactory)
        {
            DbContext dbContext = databaseFactory.GetGiveawaysEntitiesContext();
            if (dbContext == null)
                throw new ArgumentNullException("Null DbContext");
            DbContext = dbContext;
            DbSet = DbContext.Set<T>();
        }

        public RepositoryBase(DbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("Null DbContext");
            DbContext = dbContext;
            DbSet = DbContext.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public T GetById(object[] ids)
        {
            return DbSet.Find(ids);
        }

        public T GetWithNavigational(int id, params string[] navigational)
        {
            IQueryable<T> includeQuery = DbSet;
            foreach(var inc in navigational)
            {
                includeQuery = includeQuery.Include(inc);
            }
            return (includeQuery as DbSet<T>).Find(id);
        }

        public void Add(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
                dbEntityEntry.State = EntityState.Detached;
            else
                DbSet.Add(entity);
        }

        public void Update(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
                DbSet.Attach(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
                dbEntityEntry.State = EntityState.Deleted;
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null)
                return;
            Delete(entity);
        }
    }
}
