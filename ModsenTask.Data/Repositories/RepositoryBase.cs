using Microsoft.EntityFrameworkCore;
using ModsenTask.Data.Data;
using ModsenTask.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ModsenTask.Data.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationDbContext DataContext { get; set; }
        public RepositoryBase(ApplicationDbContext dataContext)
        {
            DataContext = dataContext;
        }

        public IQueryable<T> FindAll() => DataContext.Set<T>().AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            DataContext.Set<T>().Where(expression).AsNoTracking();
        public void Create(T entity) => DataContext.Set<T>().Add(entity);
        public void Update(T entity) => DataContext.Set<T>().Update(entity);
        public void Delete(T entity) => DataContext.Set<T>().Remove(entity);

        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
