using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingManager.Models.Entities
{
  [Table("Asistente")]
  public class Attendee
  {
    public int Id { get; set; }
    public int? ReservationId { get; set; }
    public int EmployeeId { get; set; }

    [Required]
    public bool DidAssist { get; set; }

    public virtual Reservation Reservation { get; set; }
    public virtual Employee Employee { get; set; }

  }
}