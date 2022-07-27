using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MeetingManager.Data;
using MeetingManager.Models.Dtos.Attendee;
using MeetingManager.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeetingManager.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AttendeesController : ControllerBase
  {
    private readonly MeetingDbContext _context;
    private readonly IMapper mapper;

    public AttendeesController(MeetingDbContext context, IMapper mapper)
    {
      _context = context;
      this.mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<AttendeeDto>>> Get()
    {
      var AttendeesList = await _context.Attendees.OrderBy(a => a.Id).ToListAsync();
      var dtos = mapper.Map<List<AttendeeDto>>(AttendeesList);
      return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AttendeeDto>> GetById(int id)
    {
      var attendee = await _context.Attendees.FirstOrDefaultAsync(a => a.Id == id);
      var dto = mapper.Map<AttendeeDto>(attendee);
      if (dto == null)
      {
        return NotFound();
      }
      return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<CreateAttendeeDto>> Create([FromBody] CreateAttendeeDto createAttendeeDto)
    {
      if (createAttendeeDto == null)
      {
        return BadRequest();
      }
      var attendee = mapper.Map<Attendee>(createAttendeeDto);
      await _context.AddAsync(attendee);
      await _context.SaveChangesAsync();
      return Ok(attendee);
    }

    [HttpPut]
    public async Task<ActionResult<UpdateAttendeeDto>> Update([FromBody] UpdateAttendeeDto updateAttendeeDto)
    {
      if (updateAttendeeDto == null)
      {
        return BadRequest();
      }
      var attendee = mapper.Map<Attendee>(updateAttendeeDto);
      _context.Update(attendee);
      await _context.SaveChangesAsync();
      return Ok(updateAttendeeDto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<AttendeeDto>> Delete(int id)
    {
      var attendee = await _context.Attendees.FindAsync(id);
      if (attendee == null)
      {
        return NotFound();
      }
      _context.Attendees.Remove(attendee);
      await _context.SaveChangesAsync();
      return Ok();
    }
  }
}