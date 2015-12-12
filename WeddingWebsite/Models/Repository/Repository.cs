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
  /// <summary>
  /// Repository for datacontext class
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class Repository<T> : IRepository<T> where T : class, IEntity
  {
    private IDataContext _dataConnection;

    /// <summary>
    /// Construct repository
    /// </summary>
    /// <param name="dbConnection">Database connection</param>
    public Repository(IDataContext dataConnection)
    {
      _dataConnection = dataConnection;
    }

    public void Delete(T entity)
    {
      _dataConnection.Delete(entity);
    }

    public void Insert(T entity)
    {
      _dataConnection.Insert(entity);
    }

    public void Update(T entity)
    {
      _dataConnection.Update(entity);
    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
    {
      return _dataConnection.GetTable<T>().Where(predicate).ToList();
    }

    public IEnumerable<T> GetAll()
    {
      return _dataConnection.GetTable<T>().ToList();
    }
  }
}