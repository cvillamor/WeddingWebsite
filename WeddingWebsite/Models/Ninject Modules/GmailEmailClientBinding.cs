using Ninject.Modules;
using WeddingWebsite.Models.Providers;
using WeddingWebsite.Models.Providers.Email;
using System.Configuration;
using WeddingWebsite.Models.DataObjects;
using System.Net.Mail;
using System.Linq;

namespace WeddingWebsite.Models.Ninject_Modules
{
  /// <summary>
  /// GMail EmailClient Binding
  /// </summary>
  public class GmailModule : NinjectModule
  {
    public override void Load()
    {
      //IEmailClientSender
       Bind<IEmailClientSender>()
        .To<GmailClientSender>()
        .WhenInjectedInto<GmailMessageProvider>()
        .WithConstructorArgument("fromAddress", ConfigurationManager.AppSettings["MessageFrom"])
        .WithConstructorArgument("password", ConfigurationManager.AppSettings["EmailPassword"]);

      //IEmailClientRecepients
      //Addresses
      var addresses = ConfigurationManager.AppSettings["MessageTo"]
                        .Split(',')
                        .Select(m => new MailAddress(m));

      Bind<IEmailClientRecipients>()
        .To<GmailClientReceiver>()
        .WhenInjectedInto<GmailMessageProvider>()
        .WithConstructorArgument("addresses", addresses);      
    }
  }
}