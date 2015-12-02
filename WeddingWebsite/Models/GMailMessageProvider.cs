using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeddingWebsite.Models
{
  public class GmailMessageProvider : IMessageProvider
  {
    public GmailMessageProvider()
    {
    }

    public bool SendMessage(IMessage message)
    {
      throw new NotImplementedException();
    }
  }
}