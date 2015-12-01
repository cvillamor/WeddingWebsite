using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WeddingWebsite.Models.DataModels;

namespace WeddingWebsite.Models.Repository
{
  public interface IRepository<T> where T : class
  {
    void Delete(T entity);
    void Upsert(T entity);
    IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    IEnumerable<T> GetAll();
  }
}
