using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace WeddingWebsite.Models.Providers.Email
{
  public class GmailClientBuilder : IEmailClient
  {
    private string _password;
    private string _emailSender;
    private MailAddress _sender;

    /// <summary>
    /// Email sender property used for sending email
    /// </summary>
    public MailAddress EmailSender { 
      get {
        return _sender;
      }
    }

    /// <summary>
    /// Build the builder, pass in both a fromAddress and password to access from Address
    /// </summary>
    /// <param name="fromAddress"></param>
    /// <param name="fromPassword"></param>
    public GmailClientBuilder(string fromAddress, string password)
    {
      _emailSender = fromAddress;
      _password = password;
      _sender = new MailAddress(fromAddress);
    }

    /// <summary>
    /// Build the email client
    /// </summary>
    /// <returns>The SmtpClient object that is used to send the message</returns>
    public SmtpClient BuildEmailClient()
    {
      return new SmtpClient()
      {
        Host = "smtp.gmail.com",
        Port = 587,
        EnableSsl = true,
        DeliveryMethod = SmtpDeliveryMethod.Network,
        Credentials = new NetworkCredential(_emailSender, _password),
        Timeout = 20000
      };
    }
  }
}