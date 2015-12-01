using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeddingWebsite.Models.DTO;

namespace WeddingWebsite.Models.Repository
{
  public class TwilioMessageRepository : Repository<TwilioMessaging>, ITwilioMessageRepository
  {
    public TwilioMessageRepository(IDataContext dataContext)
      : base(dataContext)
    { }

    public bool MaxRequestsNotReached(string phoneNumber)
    {
      return this.Find(m => m.PhoneNumber == phoneNumber && 
                            m.Date. > DateTime.Now.AddMinutes(-1)).Count() < 3;
    }
  }
}