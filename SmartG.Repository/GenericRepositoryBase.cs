using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SmartG.Contracts;

namespace SmartG.Repository
{
    public abstract class GenericRepositoryBase<T> : IGenericRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext { get; }
        public GenericRepositoryBase(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);

        public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ? RepositoryContext.Set<T>().AsNoTracking() : RepositoryContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            //return !trackChanges ? RepositoryContext.Set<T>().
            //     Where(expression).AsNoTracking() :
            //     RepositoryContext.Set<T>().Where(expression);
            return !trackChanges ? RepositoryContext.Set<T>().
                Where(expression).AsNoTracking() :
                RepositoryContext.Set<T>().Where(expression);
        }

        public void Update(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);
        }
    }
}

