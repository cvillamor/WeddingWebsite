using System;
using LinqToDB.Mapping;
using WeddingWebsite.Models.Enums;

namespace WeddingWebsite.Models.DTO
{
  [Table(Name="group")]
  public class Group
  {
    [PrimaryKey, Identity]
    public int Id { get; set; }

    [Column(Name = "rsvp_status"), Nullable]
    public RSVPStatusEnums? RSVPStatus { get; set; }

    [Column(Name = "hotel_rooms_needed"), Nullable]
    public int HotelRoomsNeeded { get; set; }

    [Column(Name = "name"), Nullable]
    public string Name { get; set; }

    [Column(Name = "address"), Nullable]
    public string Address { get; set; }
  }
}