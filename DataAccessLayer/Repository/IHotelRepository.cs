using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public interface IHotelRepository<T>
    {
        public T GetBy(Expression<Func<T, bool>> expression, string[]? includes);
        public List<T> GetAll(string[]? includes);
        public List<T> GetAllBy(Expression<Func<T, bool>> expression, string[]? includes);
        public T Create(T entity);
        public T Update(T entity);
        public void Delete(T entity);
    }
}
