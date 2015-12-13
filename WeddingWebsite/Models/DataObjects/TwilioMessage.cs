using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeddingWebsite.Models.DataObjects
{
  public class TwilioMessage : IMessage
  {
    public string To { get; set; }
    public string Message { get; set;}
    
  }
}