using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingManager.Models.Entities
{
  [Table("Reserva")]
  public class Reservation
  {
    public int Id { get; set; }

    [Required]
    public DateTime ReservationDate { get; set; }
    public int ReservedBy { get; set; }
    public int MeetinRoomId { get; set; }
    public int EmployeeId { get; set; }

    public virtual MeetingRoom MeetingRoom { get; set; }
    public virtual Employee Employee { get; set; }
    public List<Attendee> Attendees { get; set; }
  }
}