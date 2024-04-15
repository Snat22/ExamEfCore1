using Domain.Models;
namespace Domain.DTOs.ParticipantDtos;

public class AddPartipacipantDto
{
        public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }
    public int GroupId { get; set; }
    public Group?Group { get; set; }
    public int LocationId { get; set; }
    public Location? Location { get; set; }
}
