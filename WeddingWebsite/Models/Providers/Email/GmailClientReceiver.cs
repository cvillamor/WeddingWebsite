using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace WeddingWebsite.Models.Providers.Email
{
  public class GmailClientReceiver : IEmailClientRecipients
  {
    private List<MailAddress> _addresses;

    public List<MailAddress> EmailRecipients
    {
      get
      {
        return _addresses;
      }
    }

    /// <summary>
    /// Pass in list of addresses to mail to
    /// </summary>
    /// <param name="addresses"></param>
    public GmailClientReceiver(List<MailAddress> addresses)
    {
      _addresses = addresses;
    }
  }
}