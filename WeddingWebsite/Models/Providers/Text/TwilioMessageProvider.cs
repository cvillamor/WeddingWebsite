using Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twilio;
using WeddingWebsite.Models.DataObjects;
using WeddingWebsite.Models.Enums;
using WeddingWebsite.Models.Helpers;

namespace WeddingWebsite.Models
{
  /// <summary>
  /// Main Message Provider
  /// </summary>
  public class TwilioMessageProvider : IMessageProvider<TwilioMessage>
  {
    ILog _log = LogManager.GetLogger<TwilioMessageProvider>();

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
    public bool SendMessage(TwilioMessage message)
    {
      bool status = false;

      try
      { 
        var response = _twilioClient.SendMessage(message.From,
                                                 message.To,
                                                 message.Message,
                                                 new string[] { });

        //Fail if the status is failed
        if (response.Status != EnumHelper.GetEnumDescription((TwilioStatusEnums)TwilioStatusEnums.FAILED))
        {
          _log.InfoFormat("Twilio Message sent to: {0}", message.To);
          status = true;
        }
        else
        {
          _log.ErrorFormat("Twilio Message sent to {0} failed. Error: {1}", message.To, response.ErrorCode);
        }
      }
      catch(Exception ex)
      {
        _log.ErrorFormat("Error sending twilio message to {0}. Error: {1}", message.To, ex.Message);
      }

      return status;
    }
  }
}