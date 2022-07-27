using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingManager.Models.Entities
{
  [Table("Empleado")]
  public class Employee
  {
    public int Id { get; set; }

    [Required]
    [MaxLength(30)]
    public string FullName { get; set; }

    [Required]
    [MaxLength(30)]
    public string Position { get; set; }

    public List<Reservation> Reservations { get; set; }
    public List<Attendee> Attendees { get; set; }
  }
}