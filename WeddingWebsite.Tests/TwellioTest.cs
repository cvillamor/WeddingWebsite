﻿using System.Configuration;
using Twilio;
using WeddingWebsite.Models;
using WeddingWebsite.Models.DataObjects;
using Xunit;

namespace WeddingWebsite.Tests
{
  public class TwellioTest
  {
    [Fact]
    public void SendMessage()
    {
      TwilioLogin login = new TwilioLogin();
      login.AccountSId = ConfigurationManager.AppSettings["AccountSId"];
      login.AuthToken = ConfigurationManager.AppSettings["AccountToken"];

      IMessage message = new TwilioMessage();
      message.NumberFrom = ConfigurationManager.AppSettings["NumberFrom"];
      message.NumberTo = ConfigurationManager.AppSettings["NumberTo"];
      message.Message = "Derp derp derp";
      

      // Find your Account Sid and Auth Token at twilio.com/user/account 
      string AccountSid = login.AccountSId;
      string AuthToken = login.AuthToken;
      var twilio = new TwilioRestClient(AccountSid, AuthToken);

      var twilioMessage = twilio.SendMessage(message.NumberFrom, message.NumberTo, "Derp derp derpaderp", new string[] {});
      System.Console.WriteLine(twilioMessage.Sid); 
    }
  }
}
