
namespace CandidateService.Infrastructure.Entities
{
    public class CandidateExperienceEntity
    {
        public Guid Id { get; set; }

        public Guid CandidateId { get; set; }

        public string Company { get; set; }

        public string Position { get; set; }

        public string? Description { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly? EndDate { get; set; }

        public bool IsCurrent { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public CandidateEntity Candidate { get; set; } = null!;
    }
}
