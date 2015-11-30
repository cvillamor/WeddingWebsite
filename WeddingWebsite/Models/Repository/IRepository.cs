using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WeddingWebsite.Models.Repository
{
  public interface IRepository<T> where T : class
  {
    void Delete(T entity);
    void Upsert(T entity);
    T Find(Expression<Func<T>> predicate);
    IQueryable<T> GetAll();
    T GetById();
  }
}
