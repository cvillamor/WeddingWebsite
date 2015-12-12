using LinqToDB;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeddingWebsite.Models.Repository;

namespace WeddingWebsite.Models.Ninject_Modules
{
  /// <summary>
  /// Handles all calls to for the TwilioRepository
  /// </summary>
  public class TwilioRepositoryModule : NinjectModule
  {
    private IDataContext _dataContext;

    /// <summary>
    /// The data context for the TwilioRepository to be used
    /// </summary>
    /// <param name="context"></param>
    public TwilioRepositoryModule(IDataContext context)
    {
      _dataContext = context;
    }

    /// <summary>
    /// LoadTwilio Repository
    /// </summary>
    public override void Load()
    {
      Bind<ITwilioMessageRepository>()
        .To<TwilioMessageRepository>()
        .InSingletonScope()
        .WithConstructorArgument("IDataContext", _dataContext);
   
    }
  }
}