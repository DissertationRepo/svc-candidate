namespace CandidateService.Infrastructure.Entities;

public sealed class CandidateEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string FullName { get; set; } = null!;
    public string? Phone { get; set; }
    public string? Summary { get; set; }
    public string? Location { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
