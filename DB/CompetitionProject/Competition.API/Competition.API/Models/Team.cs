using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Competition.API.Models;

[PrimaryKey(nameof(Id))]
public class Team
{
    public int Id { get; set; }
    public string Name { get; set; }

    [JsonIgnore]
    public virtual Location? Location { get; set; }
    public int LocationId { get; set; }

    [JsonIgnore]
    public ICollection<Trainer> Trainers = new List<Trainer>();
    [JsonIgnore]
    public ICollection<Participiant> Participiants = new List<Participiant>();
}