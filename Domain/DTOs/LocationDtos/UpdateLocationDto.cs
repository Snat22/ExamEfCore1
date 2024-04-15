using Domain.Models;

namespace Domain.DTOs.LocationDtos;

public class UpdateLocationDto
{
    
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Participant>? Participants { get; set; }
}
