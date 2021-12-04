using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudentManagement.Contacts
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected AppDbContext AppDbContext { get; set; } 
        public RepositoryBase(AppDbContext appDbContext)
        {
            this.AppDbContext = appDbContext;
        }
        public void Create(T entity)
        {
            this.AppDbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            this.AppDbContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll()
        {
            return this.AppDbContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.AppDbContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            this.AppDbContext.Set<T>().Update(entity);
        }
    }
}
