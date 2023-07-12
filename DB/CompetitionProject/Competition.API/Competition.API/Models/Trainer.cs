using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Competition.API.Models;

[PrimaryKey(nameof(Id))]
public class Trainer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string? MidName { get; set; }
    public string LastName { get; set; }
    public string TelephoneNumber { get; set; }
    
    [JsonIgnore]
    public virtual Team? Team { get; set; }
    public int TeamId { get; set; }
}