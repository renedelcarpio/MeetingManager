using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MeetingManager.Data;
using MeetingManager.Models.Dtos.Employee;
using MeetingManager.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeetingManager.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class EmployeesController : ControllerBase
  {
    private readonly MeetingDbContext _context;
    private readonly IMapper mapper;

    public EmployeesController(MeetingDbContext context, IMapper mapper)
    {
      _context = context;
      this.mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<EmployeeDto>>> Get()
    {
      var employeesList = await _context.Employees.OrderBy(e => e.Id).ToListAsync();
      var dtos = mapper.Map<List<EmployeeDto>>(employeesList);
      return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EmployeeDto>> GetById(int id)
    {
      var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
      var dto = mapper.Map<EmployeeDto>(employee);
      if (dto == null)
      {
        return NotFound();
      }
      return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<CreateEmployeeDto>> Create([FromBody] CreateEmployeeDto createEmployeeDto)
    {
      if (createEmployeeDto == null)
      {
        return BadRequest();
      }
      var employee = mapper.Map<Employee>(createEmployeeDto);
      await _context.AddAsync(employee);
      await _context.SaveChangesAsync();
      var employeeDto = mapper.Map<EmployeeDto>(employee);
      return Ok(employeeDto);
    }

    [HttpPut]
    public async Task<ActionResult<UpdateEmployeeDto>> Update([FromBody] UpdateEmployeeDto updateEmployeeDto)
    {
      if (updateEmployeeDto == null)
      {
        return BadRequest();
      }
      var employee = mapper.Map<Employee>(updateEmployeeDto);
      _context.Update(employee);
      await _context.SaveChangesAsync();
      return Ok(employee);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<EmployeeDto>> Delete(int id)
    {
      var employee = await _context.Employees.FindAsync(id);
      if (employee == null)
      {
        return NotFound();
      }
      _context.Employees.Remove(employee);
      await _context.SaveChangesAsync();
      return Ok();
    }

  }
}