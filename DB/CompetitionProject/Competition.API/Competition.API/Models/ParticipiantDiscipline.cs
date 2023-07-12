using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Competition.API.Models;

[PrimaryKey(nameof(Id))]
public class ParticipiantDiscipline
{
    public int Id { get; set; }
    
    [JsonIgnore]
    public virtual Discipline? Discipline { get; set; }
    public int DisciplineId { get; set; }
    
    [JsonIgnore]
    public virtual Participiant? Participiant { get; set; }
    public int ParticipiantId { get; set; }

    [JsonIgnore]
    public ICollection<CompetitionRequest> CompetitionRequests { get; set; } = new List<CompetitionRequest>();
}