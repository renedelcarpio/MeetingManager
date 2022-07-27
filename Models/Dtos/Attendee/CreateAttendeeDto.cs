using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingManager.Models.Dtos.Attendee
{
  public class CreateAttendeeDto
  {
    public int? ReservationId { get; set; }
    public int EmployeeId { get; set; }

    [Required]
    public bool DidAssist { get; set; }
  }
}