using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MeetingManager.Models.Dtos.Reservation;
using MeetingManager.Models.Entities;

namespace MeetingManager.Models.AutoMapper
{
  public class ReservationProfile : Profile
  {
    public ReservationProfile()
    {
      CreateMap<CreateReservationDto, Reservation>();
      CreateMap<UpdateReservationDto, Reservation>();
      CreateMap<Reservation, ReservationDto>();
    }
  }
}