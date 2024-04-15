using Domain.Models;

namespace Domain.DTOs.ChallengeDtos;

public class AddChallengeDto
{
    
    public string Title { get; set; }
    public string Description { get; set; }
    public ICollection<Group>? Groups { get; set; }
}
