using System;
using LinqToDB.Mapping;
using WeddingWebsite.Models.Enums;
using WeddingWebsite.Models.DataModels;

namespace WeddingWebsite.Models.DTO
{
  [Table(Name="person")]
  public class Person : IEntity
  {
    [PrimaryKey, Identity]
    public int Id { get; set; }

    [Column(Name= "name"), NotNull]
    public string Name { get; set; }

    [Column(Name = "group_id"), Nullable]
    public int GroupId { get; set; }

    [Column(Name = "instagram"), Nullable]
    public string Instagram { get; set; }

    [Column(Name = "phone_number"), Nullable]
    public string PhoneNumber { get; set; }

    [Column(Name = "wedding_rsvp_status"), Nullable]
    public RSVPStatusEnums? WeddingRSVPStatus { get; set; }

    [Column(Name = "r_dinner_rsvp_status"), Nullable]
    public RSVPStatusEnums? RehearsalDinnerRSVPStatus { get; set; }

    [Column(Name = "is_invited_r_dinner"), Nullable]
    public bool IsInvitedRehearsalDinner { get; set; }

    [Column(Name = "email"), Nullable]
    public string Email { get; set; }

  }
}