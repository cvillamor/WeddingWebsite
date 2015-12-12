using Ninject.Modules;
using WeddingWebsite.Models.Providers;
using WeddingWebsite.Models.Providers.Email;
using System.Configuration;
using WeddingWebsite.Models.DataObjects;

namespace WeddingWebsite.Models.Ninject_Modules
{
  public class NinjectBindings : NinjectModule
  {
    public override void Load()
    {
      //GmailClientBuilder
      var gmailClientBuilder = Bind<IEmailClientSender>()
                                .To<GmailClientSender>()
                                .WithConstructorArgument("fromAddress", ConfigurationManager.AppSettings["MessageFrom"])
                                .WithConstructorArgument("password", ConfigurationManager.AppSettings["EmailPassword"]);

      Bind<IMessageProvider<Email>>().To<GmailMessageProvider>()
                                .WithConstructorArgument("builder", gmailClientBuilder)
                                .WithConstructorArgument("");

      
    }
  }
}