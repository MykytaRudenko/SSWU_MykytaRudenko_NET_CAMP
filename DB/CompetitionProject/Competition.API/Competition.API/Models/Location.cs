using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Competition.API.Models;

[PrimaryKey(nameof(Id))]
public class Location
{
    public int Id { get; set; }
    public string Country { get; set; }
    public string District { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public int NumberOfBuilding { get; set; }

    [JsonIgnore]
    public ICollection<Competition> Competitions = new List<Competition>();
    [JsonIgnore]
    public ICollection<Team> Teams = new List<Team>();
}