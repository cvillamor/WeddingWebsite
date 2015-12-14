using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingWebsite.Models.DataObjects;
using WeddingWebsite.Models.DTO;

namespace WeddingWebsite.Models.Repository
{
  public interface ITwilioMessageRepository
  {
    bool MaxRequestsNotReached(string phoneNumber);
    bool AddRequest(TwilioMessaging twilioMessage);
    bool CodeEqualsLastRequest(TwilioMessaging twilioMessage);
  }
}
