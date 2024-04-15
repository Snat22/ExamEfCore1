namespace Domain.Models;

public class Group
{
    public int Id { get; set;}
    public string GroupNick { get; set; }
    public int ChallengeId { get; set; }
    public bool NeedMember { get; set; }
    public string TeamSlogan { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<Participant>? Participants { get; set; }
}
