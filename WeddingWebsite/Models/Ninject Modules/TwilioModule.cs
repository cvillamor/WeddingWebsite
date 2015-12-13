using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WeddingWebsite.Models.DataObjects;

namespace WeddingWebsite.Models.Ninject_Modules
{
  /// <summary>
  /// Twilio text messaging client
  /// </summary>
  public class TwilioModule : NinjectModule
  {
    /// <summary>
    /// Load Twilio Module
    /// </summary>
    public override void Load()
    {
      Bind<IMessageProvider<TwilioMessage>>()
        .To<TwilioMessageProvider>()
        .InSingletonScope()
        .WithConstructorArgument("sId", ConfigurationManager.AppSettings["AccountSId"])
        .WithConstructorArgument("authToken", ConfigurationManager.AppSettings["AccountToken"])
        .WithConstructorArgument("numberFrom", ConfigurationManager.AppSettings["NumberFrom"]);

    }
  }
}