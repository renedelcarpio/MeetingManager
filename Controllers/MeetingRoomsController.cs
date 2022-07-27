using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MeetingManager.Data;
using MeetingManager.Models.Dtos.MeetingRoom;
using MeetingManager.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeetingManager.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class MeetingRoomsController : ControllerBase
  {
    private readonly MeetingDbContext _context;
    private readonly IMapper mapper;

    public MeetingRoomsController(MeetingDbContext context, IMapper mapper)
    {
      _context = context;
      this.mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<MeetingRoomDto>>> Get()
    {
      var meetingRoomsList = await _context.MeetingRooms.OrderBy(m => m.Id).ToListAsync();
      var dtos = mapper.Map<List<MeetingRoomDto>>(meetingRoomsList);
      return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MeetingRoomDto>> GetById(int id)
    {
      var meetingRoom = await _context.MeetingRooms.FirstOrDefaultAsync(m => m.Id == id);
      var dto = mapper.Map<MeetingRoomDto>(meetingRoom);
      if (dto == null)
      {
        return NotFound();
      }
      return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<CreateMeetingRoomDto>> Create([FromBody] CreateMeetingRoomDto createMeetingRoomDto)
    {
      if (createMeetingRoomDto == null)
      {
        return BadRequest();
      }
      var meetingRoom = mapper.Map<MeetingRoom>(createMeetingRoomDto);
      await _context.AddAsync(meetingRoom);
      await _context.SaveChangesAsync();
      return Ok(meetingRoom);
    }

    [HttpPut]
    public async Task<ActionResult<UpdateMeetingRoomDto>> Update([FromBody] UpdateMeetingRoomDto updateMeetingRoomDto)
    {
      if (updateMeetingRoomDto == null)
      {
        return BadRequest();
      }
      var meetingRoom = mapper.Map<MeetingRoom>(updateMeetingRoomDto);
      _context.Update(meetingRoom);
      await _context.SaveChangesAsync();
      return Ok(meetingRoom);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<MeetingRoomDto>> Delete(int id)
    {
      var meetingRoom = await _context.MeetingRooms.FindAsync(id);
      if (meetingRoom == null)
      {
        return NotFound();
      }
      _context.MeetingRooms.Remove(meetingRoom);
      await _context.SaveChangesAsync();
      return Ok();
    }
  }
}