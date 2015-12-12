using System.Collections.Generic;
using System.Net.Mail;

namespace WeddingWebsite.Models.Providers.Email
{
  public interface IEmailClientRecipients
  {
    List<MailAddress> EmailRecipients {get;}
  }
}