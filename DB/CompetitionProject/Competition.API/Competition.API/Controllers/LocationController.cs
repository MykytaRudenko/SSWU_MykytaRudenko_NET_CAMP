using Competition.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Competition.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LocationController : ControllerBase
{

    private readonly ApplicationContext _context;
    
    public LocationController(ApplicationContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Location>>> GetLocations()
    {
        return Ok(await _context.Locations.ToListAsync());
    }

    [HttpPost]
    public async Task<ActionResult<List<Location>>> CreateLocation(Location location)
    {
        _context.Locations.Add(location);
        await _context.SaveChangesAsync();
        return Ok(await _context.Locations.ToListAsync());
    }
    
    [HttpPut]
    public async Task<ActionResult<List<Location>>> UpdateLocation(Location location)
    {
        var dbLocation = await _context.Locations.FindAsync(location.Id);
        if (dbLocation == null)
        {
            return NotFound();
        }

        dbLocation.Country = location.Country;
        dbLocation.City = location.City;
        dbLocation.Street = location.Street;
        dbLocation.District = location.District;
        dbLocation.NumberOfBuilding = location.NumberOfBuilding;

        await _context.SaveChangesAsync();
        return Ok(await _context.Locations.ToListAsync());
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Location>>> DeleteLocation(int id)
    {
        var dbLocation = await _context.Locations.FindAsync(id);
        if (dbLocation == null)
        {
            return NotFound();
        }

        _context.Locations.Remove(dbLocation);
        await _context.SaveChangesAsync();
        return Ok(await _context.Locations.ToListAsync());
    }
}