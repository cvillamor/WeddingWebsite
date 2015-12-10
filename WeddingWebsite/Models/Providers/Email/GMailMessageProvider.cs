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
    /// <summary>
    /// Represents the SMTP client used by email provider
    /// </summary>
    SmtpClient _client;
    
    /// <summary>
    /// Represents the recepients receiving the email
    /// </summary>
    List<MailAddress> _messageRecepients;

    /// <summary>
    /// Represents the 
    /// </summary>
    MailAddress _messageSender;


    public GmailMessageProvider(IEmailClientBuilder builder, MailAddress messageSender, List<MailAddress> messageRecepients)
    {
      _client = builder.BuildEmailClient();
      _messageSender = messageSender;
      _messageRecepients = messageRecepients;
    }

    /// <summary>
    /// Class that represents all the messages that can be sent
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public bool SendMessage(Email message)
    {
      bool success = true;

      if (_messageRecepients == null)
        return !success;

      foreach (var recepient in _messageRecepients)
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
          }
          catch (Exception ex)
          {
            success = false;
          }
        }
      }

      return success;
    }
  }
}