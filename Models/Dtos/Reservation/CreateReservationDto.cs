using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingManager.Models.Dtos.Reservation
{
  public class CreateReservationDto
  {
    [Required]
    public DateTime ReservationDate { get; set; }
    public int EmployeeId { get; set; }
    public int MeetingRoomId { get; set; }
  }
}