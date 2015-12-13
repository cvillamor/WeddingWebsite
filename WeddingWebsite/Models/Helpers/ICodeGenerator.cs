using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeddingWebsite.Models.Helpers
{
  public interface ICodeGenerator
  {
    string GenerateCode();
    string HashCode(string code);
  }
}