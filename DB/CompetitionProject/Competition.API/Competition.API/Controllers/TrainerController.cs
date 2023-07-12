using Competition.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Competition.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TrainerController : ControllerBase
{

    private readonly ApplicationContext _context;
    
    public TrainerController(ApplicationContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Trainer>>> GetTrainers()
    {
        return Ok(await _context.Trainers.ToListAsync());
    }

    [HttpPost]
    public async Task<ActionResult<List<Trainer>>> CreateTrainer(Trainer trainer)
    {
        _context.Trainers.Add(trainer);
        await _context.SaveChangesAsync();
        return Ok(await _context.Trainers.ToListAsync());
    }
    
    [HttpPut]
    public async Task<ActionResult<List<Trainer>>> UpdateTrainer(Trainer trainer)
    {
        var dbTrainer = await _context.Trainers.FindAsync(trainer.Id);
        if (dbTrainer == null)
        {
            return NotFound();
        }

        dbTrainer.FirstName = trainer.FirstName;
        dbTrainer.MidName = trainer.MidName;
        dbTrainer.LastName = trainer.LastName;
        dbTrainer.TelephoneNumber = trainer.TelephoneNumber;
        dbTrainer.TeamId = trainer.Team.Id;

        await _context.SaveChangesAsync();
        return Ok(await _context.Trainers.ToListAsync());
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Trainer>>> DeleteTrainer(int id)
    {
        var dbTrainer = await _context.Trainers.FindAsync(id);
        if (dbTrainer == null)
        {
            return NotFound();
        }

        _context.Trainers.Remove(dbTrainer);
        await _context.SaveChangesAsync();
        return Ok(await _context.Trainers.ToListAsync());
    }
}