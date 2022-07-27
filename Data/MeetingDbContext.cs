using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingManager.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeetingManager.Data
{
  public class MeetingDbContext : DbContext
  {
    public MeetingDbContext(DbContextOptions<MeetingDbContext> options) : base(options)
    {

    }

    public DbSet<MeetingRoom> MeetingRooms { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Attendee> Attendees { get; set; }
  }
}