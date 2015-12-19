using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeddingWebsite.Models.DomainModels;

namespace WeddingWebsite.Models.ViewModels
{
  public class RSVPViewModel
  {
    public List<PersonDomain> Persons { get; set; }
    public List<RSVPDomain> RSVPStatuses { get; set; }
  }
}