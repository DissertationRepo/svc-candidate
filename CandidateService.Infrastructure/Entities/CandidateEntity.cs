namespace CandidateService.Infrastructure.Entities;

public sealed class CandidateEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string FirstName { get; set; } 
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string? Summary { get; set; }
    public string? Location { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public ICollection<CandidateSkillEntity> Skills { get; set; } = new List<CandidateSkillEntity>();
}
