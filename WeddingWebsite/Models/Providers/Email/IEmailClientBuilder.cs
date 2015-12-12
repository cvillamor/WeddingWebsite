using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WeddingWebsite.Models.Providers
{
  /// <summary>
  /// Builds the SMTP object
  /// </summary>
  public interface IEmailClient
  {
    MailAddress EmailSender { get; }
    SmtpClient BuildEmailClient();
  }
}
