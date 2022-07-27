using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MeetingManager.Models.Dtos.Employee;
using MeetingManager.Models.Entities;

namespace MeetingManager.Models.AutoMapper
{
  public class EmployeeProfile : Profile
  {
    public EmployeeProfile()
    {
      CreateMap<CreateEmployeeDto, Employee>().ReverseMap();
      CreateMap<UpdateEmployeeDto, Employee>();
      CreateMap<Employee, EmployeeDto>();
    }
  }
}