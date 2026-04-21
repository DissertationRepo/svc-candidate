using CandidateService.Domain.ValueObjects;

namespace CandidateService.Api.Models
{
    public record AddCandidateExperience
    {
        public string? CandidateId { get; init; }
        public string? Company { get; init; }
        public string? Position { get; init; }
        public string? Description { get; init; }
        public string? StartDate { get; init; }
        public string? EndDate { get; init; }
    }
}
