using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject.Web.Common;
using Ninject;
using System.Reflection;
using WeddingWebsite.Models.Ninject_Modules;
using WeddingWebsite.Models;

namespace WeddingWebsite
{
  public class MvcApplication : NinjectHttpApplication
  {

    protected void Application_Start()
    {
      AreaRegistration.RegisterAllAreas();
      GlobalConfiguration.Configure(WebApiConfig.Register);
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);
    }

    /// <summary>
    /// Create Kernel call
    /// </summary>
    /// <returns>An instanced version of the StandardKernel for Ninject</returns>
    protected override IKernel CreateKernel()
    {
      var kernel = new StandardKernel(new GmailModule(),
                                      new TwilioModule());
      return kernel;
    }
  }
}
