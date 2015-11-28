using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WeddingWebsite.Models.Enums
{
  public enum TwilioStatusEnums
  {
    [Description("queued")]
    QUEUED = 1,

    [Description("sending")]
    SENDING = 2,

    [Description("sent")]
    SENT = 3,

    [Description("failed")]
    FAILED = 4
  }
}