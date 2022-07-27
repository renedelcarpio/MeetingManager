using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingManager.Models.Dtos.Reservation
{
  public class UpdateReservationDto
  {
    public int Id { get; set; }
    [Required]
    public DateTime ReservationDate { get; set; }
    public int ReservedBy { get; set; }
    public int MeetinRoomId { get; set; }
    public int EmployeeId { get; set; }
  }
}