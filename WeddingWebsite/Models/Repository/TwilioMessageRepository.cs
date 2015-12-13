using Common.Logging;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeddingWebsite.Models.DataObjects;
using WeddingWebsite.Models.DTO;
using WeddingWebsite.Models.Helpers;

namespace WeddingWebsite.Models.Repository
{
  public class TwilioMessageRepository : Repository<TwilioMessaging>, ITwilioMessageRepository
  {
    private ILog _log = LogManager.GetLogger<TwilioMessageRepository>();

    public TwilioMessageRepository(IDataContext dataContext)
      : base(dataContext)
    { }

    public bool MaxRequestsNotReached(string phoneNumber)
    {
      return this.Find(m => m.PhoneNumber == phoneNumber && 
                            m.Date > DateTime.Now.AddMinutes(-1)).Count() < 3;
    }

    /// <summary>
    /// Add twilio message to database
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public bool AddRequest(TwilioMessaging message)
    {
      bool success = false;

      //Sanitize phone number
      string numbers = new string(message.PhoneNumber.Where(Char.IsDigit).ToArray());

      try
      { 
        if (NumberValidator.IsPhoneNumber(message.PhoneNumber))
          this.Insert(message);
      }
      catch(Exception ex)
      {
        _log.ErrorFormat("Error entering AddRequest data into database {0}", ex.Message);
      }

      return success;
    }
  }
}