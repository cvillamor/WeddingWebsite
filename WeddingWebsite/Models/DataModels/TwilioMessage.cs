using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeddingWebsite.Models.DataModels;

namespace WeddingWebsite.Models.DTO
{
  [Table(Name = "twilio_messaging")]
  public class TwilioMessage 
  {
    [PrimaryKey, Identity]
    public int Id { get; set; }

    [Column(Name = "date"), NotNull]
    public DateTime Date { get; set; }

    [Column(Name = "code"), NotNull]
    public string Code { get; set; }
  }
}