using Domain.Models;

namespace Domain.DTOs.ChallengeDtos;

public class UpdateChallengeDto
{
    
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ICollection<Group>?Groups { get; set; }
}
