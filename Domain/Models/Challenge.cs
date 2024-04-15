namespace Domain.Models;

public class Challenge
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }

    public ICollection<Group>? Groups { get; set; }
}
