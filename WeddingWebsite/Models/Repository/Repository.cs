using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Web;
using LinqToDB.Data;
using WeddingWebsite.Models.DataModels;
using WeddingWebsite.Models.DBConnectors;
using LinqToDB;

namespace WeddingWebsite.Models.Repository
{
  public class Repository<T> : IRepository<T> where T : class, IEntity
  {
    private DataConnection _dataConnection;

    /// <summary>
    /// Construct repository
    /// </summary>
    /// <param name="dbConnection">Database connection</param>
    public Repository(DataConnection dataConnection)
    {
      _dataConnection = dataConnection;
    }

    public void Delete(T entity)
    {
      _dataConnection.Delete(entity);
    }

    public void Upsert(T entity)
    {
      _dataConnection.InsertOrReplace(entity);
    }

    public T Find(Expression<Func<T>> predicate)
    {
      return _dataConnection.Select(predicate);
    }

    public IQueryable<T> GetAll()
    {
      return null;//_dataConnection.Where()
    }

    public T GetById()
    {
      throw new NotImplementedException();
    }
  }
}