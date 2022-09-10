using Microsoft.EntityFrameworkCore;
using RepositoryDesignPattern.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace RepositoryDesignPattern.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryDbContext _repositoryDbContext;
        public RepositoryBase(RepositoryDbContext repositoryDbContext)
        {
            _repositoryDbContext = repositoryDbContext;
        }

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ?
              _repositoryDbContext.Set<T>()
                .AsNoTracking() :
              _repositoryDbContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ?
              _repositoryDbContext.Set<T>()
                .Where(expression)
                .AsNoTracking() :
              _repositoryDbContext.Set<T>()
                .Where(expression);

        public void Create(T entity) => _repositoryDbContext.Set<T>().Add(entity);

        public void Update(T entity) => _repositoryDbContext.Set<T>().Update(entity);

        public void Delete(T entity) => _repositoryDbContext.Set<T>().Remove(entity);
    }
}
