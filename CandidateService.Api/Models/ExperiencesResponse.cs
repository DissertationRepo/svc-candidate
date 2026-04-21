namespace CandidateService.Api.Models
{
    public class ExperiencesResponse
    {
        public string? Id { get; init; }
        public string? CandidateId { get; init;  }
        public string? Company { get; init; }
        public string? Position { get; init; }
        public string? Description { get; init; }
        public DateOnly? StartDate { get; init; }
        public DateOnly? EndDate { get; init; }
        public bool? IsCurrent { get; init; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
    }
}
