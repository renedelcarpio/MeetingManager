using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MeetingManager.Data;
using MeetingManager.Models.Dtos.Reservation;
using MeetingManager.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeetingManager.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ReservationsController : ControllerBase
  {
    private readonly MeetingDbContext _context;
    private readonly IMapper mapper;

    public ReservationsController(MeetingDbContext context, IMapper mapper)
    {
      _context = context;
      this.mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<ReservationDto>>> Get()
    {
      var reservationsList = await _context.Reservations.OrderBy(r => r.Id).ToListAsync();
      var dtos = mapper.Map<List<ReservationDto>>(reservationsList);
      return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReservationDto>> GetById(int id)
    {
      var reservation = await _context.Reservations.FirstOrDefaultAsync(r => r.Id == id);
      var dto = mapper.Map<ReservationDto>(reservation);
      if (dto == null)
      {
        return NotFound();
      }
      return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<CreateReservationDto>> Create([FromBody] CreateReservationDto createReservationDto)
    {
      if (createReservationDto == null)
      {
        return BadRequest();
      }
      var reservation = mapper.Map<Reservation>(createReservationDto);
      await _context.AddAsync(reservation);
      await _context.SaveChangesAsync();
      return Ok(reservation);
    }

    [HttpPut]
    public async Task<ActionResult<UpdateReservationDto>> Update([FromBody] UpdateReservationDto updateReservationDto)
    {
      if (updateReservationDto == null)
      {
        return BadRequest();
      }
      var reservation = mapper.Map<Reservation>(updateReservationDto);
      _context.Update(reservation);
      await _context.SaveChangesAsync();
      return Ok(reservation);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ReservationDto>> Delete(int id)
    {
      var reservation = await _context.Reservations.FindAsync(id);
      if (reservation == null)
      {
        return NotFound();
      }
      _context.Reservations.Remove(reservation);
      await _context.SaveChangesAsync();
      return Ok();
    }
  }
}