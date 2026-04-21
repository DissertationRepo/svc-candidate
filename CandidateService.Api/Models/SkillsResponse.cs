using CandidateService.Domain.ValueObjects;

namespace CandidateService.Api.Models
{
    public class SkillsResponse
    {
        public string? Id { get; init; }
        public string? CandidateId { get; init; }
        public string? Name { get; init; }
        public string? Level { get; init; }
        public string? YearsOfExperience { get; init; }
        public string? CreatedAt { get; init; }
    }
}
