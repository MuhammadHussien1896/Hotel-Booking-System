using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class HotelRepository<T> : IHotelRepository<T> where T : class
    {
        private readonly AppDbContext context;

        public HotelRepository(AppDbContext context)
        {
            this.context = context;
        }
        public T Create(T entity)
        {
            context.Set<T>().Add(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public List<T> GetAll(string[]? includes)
        {
            IQueryable<T> query = context.Set<T>();
            if(includes != null)
            {
                foreach (var item in includes)
                    query = query.Include(item);
            }
            return query.ToList<T>();
        }

        public List<T> GetAllBy(Expression<Func<T,bool>> expression, string[]? includes)
        {
            IQueryable<T> query = context.Set<T>();
            if (includes != null)
            {
                foreach (var item in includes)
                    query = query.Include(item);
            }
            return query.Where(expression).ToList<T>();
        }

        public T GetBy(Expression<Func<T, bool>> expression, string[]? includes)
        {
            IQueryable<T> query = context.Set<T>();
            if (includes != null)
            {
                foreach (var item in includes)
                    query = query.Include(item);
            }
            return query.FirstOrDefault(expression);
        }

        public T Update(T entity)
        {
            context.Set<T>().Update(entity);
            return entity;
        }
    }
}
