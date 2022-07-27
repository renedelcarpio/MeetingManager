using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingManager.Models.Entities
{
  [Table("Sala")]
  public class MeetingRoom
  {
    public int Id { get; set; }

    [Required]
    [MaxLength(80)]
    public string Name { get; set; }

    [MaxLength(300)]
    public string Description { get; set; }

    [Required]
    public int Capacity { get; set; }

    [Required]
    public bool Available { get; set; }

    public List<Reservation> Reservations { get; set; }
  }
}