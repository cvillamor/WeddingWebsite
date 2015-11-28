using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WeddingWebsite.Models.Enums
{
  public enum RSVPStatusEnums
  {
    [Description("NotResponded")]
    NOTRESPONDED = 1,

    [Description("Responded - Going")]
    RESPONDEDGOING = 2,

    [Description("Responded - Not Going")]
    RESPONDEDNOTGOING = 3
  }
}