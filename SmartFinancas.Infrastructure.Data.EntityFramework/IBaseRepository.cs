using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SmartFinancas.Infrastructure.Data.EntityFramework
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> AsQueryable();
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        T Single(Expression<Func<T, bool>> predicate);
        T SingleOrDefault(Expression<Func<T, bool>> predicate);
        T First(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Attach(T entity);
        T FirstOrDefault(Expression<Func<T, bool>> predicate);
        IQueryable<T> AsNoTrackingQueryable();
    }
}
