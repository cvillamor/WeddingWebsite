using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Net;
using System.Net.Mail;

namespace WeddingWebsite.Tests
{
  public class EmailTest
  {
    [Fact]
    public void SendEmail()
    {
      var fromAddress = new MailAddress("@gmail.com", "");
      var toAddress = new MailAddress("", "");
      var toAddress2 = new MailAddress("", "");

      List<MailAddress> mailAddresses = new List<MailAddress>() { toAddress, toAddress2 };
      const string fromPassword = "";
      const string subject = "Test Email";
      const string body = "Derp";

      var smtp = new SmtpClient
      {
        Host = "smtp.gmail.com",
        Port = 587,
        EnableSsl = true,
        DeliveryMethod = SmtpDeliveryMethod.Network,
        Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
        Timeout = 20000
      };

      foreach(var mailingAddress in mailAddresses)
      { 
        using (var message = new MailMessage(fromAddress, mailingAddress)
        {
          Subject = subject,
          Body = body
        })
        {
          try
          { 
            smtp.Send(message);
          }
          catch(Exception ex)
          {

          }
        }
      }
    }

  }
}
