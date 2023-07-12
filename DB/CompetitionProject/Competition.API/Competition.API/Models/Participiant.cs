using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Competition.API.Models;

[PrimaryKey(nameof(Id))]
public class Participiant
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string? MidName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string SportCategory { get; set; }
    public string TelephoneNumber { get; set; }
    public Status Status { get; set; }
    
    [JsonIgnore]
    public virtual Team? Team { get; set; }
    public int TeamId { get; set; }

    [JsonIgnore]
    public ICollection<ParticipiantDiscipline> ParticipiantDisciplines = new List<ParticipiantDiscipline>();
}