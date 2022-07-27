using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MeetingManager.Models.Dtos.Attendee;
using MeetingManager.Models.Entities;

namespace MeetingManager.Models.AutoMapper
{
  public class AttendeeProfile : Profile
  {
    public AttendeeProfile()
    {
      CreateMap<CreateAttendeeDto, Attendee>();
      CreateMap<UpdateAttendeeDto, Attendee>();
      CreateMap<Attendee, AttendeeDto>();
    }
  }
}