using Domain.Models;

namespace Domain.DTOs.GroupDtos;

public class AddGroupDto
{
    public string GroupNick { get; set; }
    public int ChallengeId { get; set; }
    public bool NeedMember { get; set; }
    public string TeamSlogan { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<Participant>? Participants { get; set; }
}
