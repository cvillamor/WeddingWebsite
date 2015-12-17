using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeddingWebsite.Models.Enums;

namespace WeddingWebsite.Models.DomainModels
{
  public class PersonDomain
  {
    public string Name { get; set; }
    public int Id { get; set; }
    public string Instagram { get; set; }
    public bool IsInvitedToRehearsalDinner { get; set; }
    public RSVPStatusEnums WeddingRSVPStatus { get; set; }
    public RSVPStatusEnums RehearsalDinnerRSVPStatus { get; set; }
  }
}