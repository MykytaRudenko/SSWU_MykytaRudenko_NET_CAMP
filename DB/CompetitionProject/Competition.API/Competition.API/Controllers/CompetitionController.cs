using Competition.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Competition.API.Controllers;

using Competition = Competition.API.Models.Competition;

[Route("api/[controller]")]
[ApiController]
public class CompetitionController : ControllerBase
{

    private readonly ApplicationContext _context;
    
    public CompetitionController(ApplicationContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Competition>>> GetCompetitions()
    {
        return Ok(await _context.Competitions.ToListAsync());
    }

    [HttpPost]
    public async Task<ActionResult<List<Competition>>> CreateCompetition(Competition competition)
    {
        var location = await _context.Locations.FindAsync(competition.LocationId);
        if (location == null)
            return NotFound();
        _context.Competitions.Add(competition);
        await _context.SaveChangesAsync();
        return Ok(await _context.Competitions.ToListAsync());
    }
    
    [HttpPut]
    public async Task<ActionResult<List<Competition>>> UpdateCompetition(Competition competition)
    {
        var dbCompetition = await _context.Competitions.FindAsync(competition.Id);
        var location = await _context.Locations.FindAsync(competition.LocationId);
        if (dbCompetition == null || location == null)
        {
            return NotFound();
        }

        dbCompetition.Name = competition.Name;
        dbCompetition.Date = competition.Date;
        dbCompetition.LocationId = competition.LocationId;

        await _context.SaveChangesAsync();
        return Ok(await _context.Competitions.ToListAsync());
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Competition>>> DeleteCompetition(int id)
    {
        var dbCompetition = await _context.Competitions.FindAsync(id);
        if (dbCompetition == null)
        {
            return NotFound();
        }

        _context.Competitions.Remove(dbCompetition);
        await _context.SaveChangesAsync();
        return Ok(await _context.Competitions.ToListAsync());
    }
}