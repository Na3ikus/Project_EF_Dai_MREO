using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DAI_MREO.Repositories
{
    public interface IRepository<T>
        where T : class
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        T? GetById(long id);

        void Create(T entity);

        void Update(T entity);

        void Delete(long id);
    }
}