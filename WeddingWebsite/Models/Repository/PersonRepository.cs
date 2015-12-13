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
  }
}