using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeddingWebsite.Models.DataModels;

namespace WeddingWebsite.Models.DTO
{
  [Table(Name = "twilio_messaging")]
  public class TwilioMessaging : IEntity
  {
    [Column(Name = "phone_number")]
    public string PhoneNumber { get; set; }

    [Column(Name = "date"), NotNull]
    public DateTime Date { get; set; }

    [Column(Name = "code"), NotNull]
    public string Code { get; set; }
  }
}