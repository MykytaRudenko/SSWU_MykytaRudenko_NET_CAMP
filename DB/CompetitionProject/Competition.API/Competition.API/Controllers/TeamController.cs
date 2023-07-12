using Competition.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Competition.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeamController : ControllerBase
{

    private readonly ApplicationContext _context;
    
    public TeamController(ApplicationContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Team>>> GetTeams()
    {
        return Ok(await _context.Teams.ToListAsync());
    }

    [HttpPost]
    public async Task<ActionResult<List<Team>>> CreateTeam(Team team)
    {
        var location = await _context.Locations.FindAsync(team.LocationId);
        if (location == null)
            return NotFound();
        _context.Teams.Add(team);
        await _context.SaveChangesAsync();
        return Ok(await _context.Teams.ToListAsync());
    }
    
    [HttpPut]
    public async Task<ActionResult<List<Team>>> UpdateTeam(Team team)
    {
        var dbTeam = await _context.Teams.FindAsync(team.Id);
        var location = await _context.Locations.FindAsync(team.LocationId);
        if (dbTeam == null || location == null)
        {
            return NotFound();
        }

        dbTeam.Name = team.Name;
        dbTeam.LocationId = team.LocationId;

        await _context.SaveChangesAsync();
        return Ok(await _context.Teams.ToListAsync());
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Team>>> DeleteTeam(int id)
    {
        var dbTeam = await _context.Teams.FindAsync(id);
        if (dbTeam == null)
        {
            return NotFound();
        }

        _context.Teams.Remove(dbTeam);
        await _context.SaveChangesAsync();
        return Ok(await _context.Teams.ToListAsync());
    }
}