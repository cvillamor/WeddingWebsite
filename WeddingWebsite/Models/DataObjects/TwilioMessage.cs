using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeddingWebsite.Models.DataObjects
{
  public class TwilioMessage : IMessage
  {
    public string NumberFrom { get; set; }
    public string NumberTo { get; set; }
    public string Message { get; set;}
    
  }
}