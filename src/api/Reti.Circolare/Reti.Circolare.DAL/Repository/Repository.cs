using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Reti.Circolare.DAL.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private CircolareContext circolareContext;
        private DbSet<TEntity> dbSet;

        protected DbSet<TEntity> DbSet
        {
            get
            {
                if (dbSet == null)
                {
                    dbSet = circolareContext.Set<TEntity>();
                }
                return dbSet;
            }
        }

        public Repository(CircolareContext circolareContext)
        {
            this.circolareContext = circolareContext;
        }
        //public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        //{
        //    return DbSet.Where(predicate);
        //}
        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }
        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbSet;
        }
        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }
    }
}
