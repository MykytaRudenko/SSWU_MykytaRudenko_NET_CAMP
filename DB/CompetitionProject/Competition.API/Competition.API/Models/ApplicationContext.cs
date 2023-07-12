using Microsoft.EntityFrameworkCore;

namespace Competition.API.Models;

public class ApplicationContext: DbContext
{
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<CompetitionRequest> CompetitionRequests => Set<CompetitionRequest>();
    public DbSet<Competition> Competitions => Set<Competition>();
    public DbSet<Discipline> Disciplines => Set<Discipline>();
    public DbSet<ParticipiantDiscipline> ParticipiantDisciplines => Set<ParticipiantDiscipline>();
    public DbSet<Participiant> Participiants => Set<Participiant>();
    public DbSet<Team> Teams => Set<Team>();
    public DbSet<Trainer> Trainers => Set<Trainer>();
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ParticipiantDiscipline>()
            .HasMany(p => p.CompetitionRequests)
            .WithOne(cr => cr.ParticipiantDiscipline)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<CompetitionRequest>()
            .HasOne(cr => cr.Competition)
            .WithMany(c => c.CompetitionRequests)
            .OnDelete(DeleteBehavior.Restrict);
    }
    
}