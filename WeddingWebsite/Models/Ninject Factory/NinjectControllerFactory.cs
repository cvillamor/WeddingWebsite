using Ninject;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace WeddingWebsite.Models.Ninject_Modules
{
  /// <summary>
  /// Here to solve dependency issues with Ninject.
  /// 
  /// Source:
  /// http://stackoverflow.com/questions/12311479/asp-net-mvc-4-ninject-mvc-3-no-parameterless-constructor-defined-for-this-ob
  /// </summary>
  public class NinjectControllerFactory : DefaultControllerFactory
  {
    private IKernel ninjectKernel;
    public NinjectControllerFactory(IKernel kernel)
    {
      ninjectKernel = kernel;
    }

    protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
    {
      return (controllerType == null) ? null : (IController)ninjectKernel.Get(controllerType);
    }
  }
}