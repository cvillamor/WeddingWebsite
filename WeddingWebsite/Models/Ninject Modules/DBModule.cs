using LinqToDB;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeddingWebsite.Models.DBConnectors;

namespace WeddingWebsite.Models.Ninject_Modules
{
  /// <summary>
  /// The database context which can be injected to the other repositories
  /// </summary>
  public class DbModule : NinjectModule
  {
    public override void Load()
    {
      Bind<IDataContext>().To<WeddingDb>().InSingletonScope();
    }
  }
}