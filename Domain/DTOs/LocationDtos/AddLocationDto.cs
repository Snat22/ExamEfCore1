using Domain.Models;

namespace Domain.DTOs.LocationDtos;

public class AddLocationDto
{
    
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Participant>? Participants { get; set; }
}
