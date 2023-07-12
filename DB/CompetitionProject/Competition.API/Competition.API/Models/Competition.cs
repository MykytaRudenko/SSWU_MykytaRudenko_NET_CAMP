using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Competition.API.Models;

[PrimaryKey(nameof(Id))]
public class Competition
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    
    [JsonIgnore]
    public virtual Location? Location { get; set; }
    
    public int LocationId { get; set; }

    [JsonIgnore]
    public ICollection<CompetitionRequest> CompetitionRequests { get; set; } = new List<CompetitionRequest>();
}