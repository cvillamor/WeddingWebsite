using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twilio;
using WeddingWebsite.Models.Enums;
using WeddingWebsite.Models.Helpers;

namespace WeddingWebsite.Models
{
  /// <summary>
  /// Main Message Provider
  /// </summary>
  public class TwilioMessageProvider : IMessageProvider
  {
    TwilioRestClient _twilioClient;

    /// <summary>
    /// Access the Twilio Client
    /// </summary>
    public TwilioRestClient TwilioClient
    {
      get 
      { 
        return _twilioClient;
      }
    }

    /// <summary>
    /// Main constructor to Twilio provider
    /// </summary>
    /// <param name="sId"></param>
    /// <param name="authToken"></param>
    public TwilioMessageProvider(string sId, string authToken)
    {
      _twilioClient = new TwilioRestClient(sId, authToken);
    }

    /// <summary>
    /// Send a message
    /// </summary>
    public bool SendMessage(IMessage message)
    {
      bool status = false;
      var response = _twilioClient.SendMessage(message.NumberFrom,
                                               message.NumberTo,
                                               message.Message,
                                               new string[] {});

      //Fail if the status is failed
      if (response.Status != EnumHelper.GetEnumDescription((TwilioStatusEnums)TwilioStatusEnums.FAILED))
        status = true;

      return status;
    }
  }
}