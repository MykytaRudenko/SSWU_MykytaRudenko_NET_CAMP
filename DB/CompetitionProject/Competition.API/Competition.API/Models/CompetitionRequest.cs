using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Competition.API.Models;

[PrimaryKey(nameof(Id))]
public class CompetitionRequest
{
    public int Id { get; set; }
    public Status Status { get; set; }
    
    [JsonIgnore]
    public Competition? Competition { get; set; }
    public int CompetitionId { get; set; }
    
    [JsonIgnore]
    public ParticipiantDiscipline? ParticipiantDiscipline { get; set; }
    public int ParticipiantDisciplineId { get; set; }
}