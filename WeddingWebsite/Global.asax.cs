﻿using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject.Web.Common;
using Ninject;
using System.Reflection;
using WeddingWebsite.Models.Ninject_Modules;
using WeddingWebsite.Models;
using WeddingWebsite.Models.DBConnectors;
using WeddingWebsite.App_Start;

namespace WeddingWebsite
{
  public class MvcApplication : NinjectHttpApplication
  {

    protected override void OnApplicationStarted()
    {
      base.OnApplicationStarted();

      AreaRegistration.RegisterAllAreas();
      GlobalConfiguration.Configure(WebApiConfig.Register);
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);
      AutoMapperConfig.RegisterMappings();

      ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(Kernel));
    }

    /// <summary>
    /// Create Kernel call
    /// </summary>
    /// <returns>An instanced version of the StandardKernel for Ninject</returns>
    protected override IKernel CreateKernel()
    {
      var kernel = new StandardKernel();
      
      //Loads the instance of DB -- creates a singleton DB instance to be injected into all repositories
      kernel.Load(new DbModule());

      //Messaging Modules
      kernel.Load(new GmailModule());
      kernel.Load(new TwilioModule());

      //Crypto
      kernel.Load(new CodeGeneratorModule());

      //Repositories
      kernel.Load(new RepositoryModule(kernel.Get<WeddingDb>()));


      return kernel;
    }
  }
}
