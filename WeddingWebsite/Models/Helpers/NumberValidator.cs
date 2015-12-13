using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WeddingWebsite.Models.Helpers
{
  public class NumberValidator
  {
    public static bool IsPhoneNumber(string number)
    {
      return Regex.Match(number, @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}").Success;
    }
  }
}