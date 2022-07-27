using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MeetingManager.Models.Dtos.MeetingRoom;
using MeetingManager.Models.Entities;

namespace MeetingManager.Models.AutoMapper
{
  public class MeetingRoomProfile : Profile
  {
    public MeetingRoomProfile()
    {
      CreateMap<CreateMeetingRoomDto, MeetingRoom>();
      CreateMap<UpdateMeetingRoomDto, MeetingRoom>();
      CreateMap<MeetingRoom, MeetingRoomDto>();
    }
  }
}