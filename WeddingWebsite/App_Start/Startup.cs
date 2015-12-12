using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WeddingWebsite.App_Start.Startup))]

namespace WeddingWebsite.App_Start
{
  public class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
    }
  }
}
