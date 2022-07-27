using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingManager.Models.Dtos.Employee
{
  public class UpdateEmployeeDto
  {
    [Required]
    [MaxLength(30)]
    public string FullName { get; set; }

    [Required]
    [MaxLength(30)]
    public string Position { get; set; }
  }
}