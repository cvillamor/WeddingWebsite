using Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using WeddingWebsite.Models.DataObjects;
using WeddingWebsite.Models.Providers;
using WeddingWebsite.Models.Providers.Email;

namespace WeddingWebsite.Models
{
  public class GmailMessageProvider : IMessageProvider<Email>
  {
    ILog _log = LogManager.GetLogger<GmailMessageProvider>();

    /// <summary>
    /// Represents the SMTP client used by email provider
    /// </summary>
    SmtpClient _client;
    
    /// <summary>
    /// Represents the recepients receiving the email
    /// </summary>
    List<MailAddress> _messageRecipients;

    /// <summary>
    /// Represents the 
    /// </summary>
    MailAddress _messageSender;

    public GmailMessageProvider(IEmailClientSender sender, IEmailClientRecipients recipients)
    {
      _client = sender.BuildEmailClient();
      _messageSender = sender.EmailSender;
      _messageRecipients = recipients.EmailRecipients;
    }

    /// <summary>
    /// Class that represents all the messages that can be sent
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public bool SendMessage(Email message)
    {
      bool success = true;

      if (_messageRecipients == null)
        return !success;

      foreach (var recepient in _messageRecipients)
      {
        using (var emailMessage = new MailMessage(_messageSender, recepient)
        {

          Body = message.Message,
          Subject = message.Subject
        })
        {
          try
          {
            _client.Send(emailMessage);
            _log.InfoFormat("Email message sent to: {0} ", recepient.Address);
          }
          catch (Exception ex)
          {
            _log.ErrorFormat("Email message not sent to {0} error: {1}", recepient.Address, ex.Message);
            success = false;
          }
        }
      }

      return success;
    }
  }
}