using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using WeddingWebsite.Models.Helpers;

namespace WeddingWebsite.Models.Ninject_Modules
{
  public class CodeGeneratorModule : NinjectModule
  {
    public override void Load()
    {
      Bind<ICodeGenerator>()
        .To<SixDigitCodeGenerator>()
        .InSingletonScope()
        .WithConstructorArgument("algorithm", MD5.Create());
    }
  }
}