using Common.Logging;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeddingWebsite.Models.DTO;

namespace WeddingWebsite.Models.Repository
{
  public class PersonRepository : Repository<Person>, IPersonRepository
  {
    private ILog _log = LogManager.GetLogger<PersonRepository>();

    public PersonRepository(IDataContext dataContext)
      : base(dataContext)
    { }

    /// <summary>
    /// Check if the Phone number exists in the database
    /// </summary>
    /// <param name="phoneNumber"></param>
    /// <returns></returns>
    public bool CheckPhoneNumberExists(string phoneNumber)
    {
      bool success = false;

      try
      {
        success = this.Find(m => m.PhoneNumber == phoneNumber).Count() > 0;

        if (success)
          _log.InfoFormat("Number {0} found in database", phoneNumber);
        else
          _log.InfoFormat("Number {0} NOT found in database", phoneNumber);
      }
      catch (Exception ex)
      {
        _log.ErrorFormat("There was an error trying to access PersonTable {0}", ex.Message);
        success = false;
      }

      return success;
    }

    /// <summary>
    /// Gets the group Id by phone number
    /// </summary>
    /// <param name="phoneNumber"></param>
    /// <returns></returns>
    public int GetGroupIdByPhoneNumber(string phoneNumber)
    {
      int groupId = 0;

      try
      {
        var result = this.Find(m => m.PhoneNumber == phoneNumber).FirstOrDefault();
        
        if (result != null)
        {
          groupId = result.GroupId;
        }
      }
      catch(Exception ex)
      {
        _log.ErrorFormat("There was an error trying to access PersonTable {0}", ex.Message);
      }

      return groupId;
    }

    /// <summary>
    /// Return back a list of people within this group
    /// </summary>
    /// <param name="groupId">GroupId in question</param>
    /// <returns>List of people</returns>
    public IEnumerable<Person> GetPersonListByGroupId(int groupId)
    {
      List<Person> personList = new List<Person>();

      if (groupId == 0)
        return personList;

      try
      {
        personList = this.Find(m => m.GroupId == groupId).ToList();
      }
      catch(Exception ex)
      {
        _log.ErrorFormat("There was an error trying to access PersonTable {0}", ex.Message);
      }

      return personList;
    }
  }
}