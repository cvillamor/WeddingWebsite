using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using WeddingWebsite.Models.Providers;
using WeddingWebsite.Models.Providers.Email;

namespace WeddingWebsite.Models.Ninject_Modules
{
  public class NinjectBindings : NinjectModule
  {
    public override void Load()
    {
      Bind<IEmailClientBuilder>().To<GmailClientBuilder>();
    }
  }
}