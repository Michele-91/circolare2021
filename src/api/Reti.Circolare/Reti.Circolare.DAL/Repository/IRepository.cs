using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Reti.Circolare.DAL.Repository
{
    public interface IRepository<TEntity> where TEntity : class 
    {
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void Update(TEntity entity);
        IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        void Delete(TEntity entity);
    }
}
