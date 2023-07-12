using Competition.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Competition.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DisciplineController : ControllerBase
{

    private readonly ApplicationContext _context;
    
    public DisciplineController(ApplicationContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Discipline>>> GetDisciplines()
    {
        return Ok(await _context.Disciplines.ToListAsync());
    }

    [HttpPost]
    public async Task<ActionResult<List<Discipline>>> CreateDiscipline(Discipline discipline)
    {
        _context.Disciplines.Add(discipline);
        await _context.SaveChangesAsync();
        return Ok(await _context.Disciplines.ToListAsync());
    }
    
    [HttpPut]
    public async Task<ActionResult<List<Discipline>>> UpdateDiscipline(Discipline discipline)
    {
        var dbDiscipline = await _context.Disciplines.FindAsync(discipline.Id);
        if (dbDiscipline == null)
        {
            return NotFound();
        }

        dbDiscipline.Name = discipline.Name;

        await _context.SaveChangesAsync();
        return Ok(await _context.Disciplines.ToListAsync());
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Discipline>>> DeleteDiscipline(int id)
    {
        var dbDiscipline = await _context.Disciplines.FindAsync(id);
        if (dbDiscipline == null)
        {
            return NotFound();
        }

        _context.Disciplines.Remove(dbDiscipline);
        await _context.SaveChangesAsync();
        return Ok(await _context.Disciplines.ToListAsync());
    }
}