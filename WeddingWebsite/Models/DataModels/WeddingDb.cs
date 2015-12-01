using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB.Data;
using LinqToDB;
using System.Web;
using WeddingWebsite.Models.DTO;

namespace WeddingWebsite.Models.DBConnectors
{
  public class WeddingDb : LinqToDB.Data.DataConnection
  {
    public WeddingDb() : base("Wedding") { }

    public ITable<Person> People { get { return GetTable<Person>(); }}
    public ITable<Group> Group { get { return GetTable<Group>(); }}
    public ITable<TwilioMessaging> TwilioMessages { get { return GetTable<TwilioMessaging>(); }}
  }
}