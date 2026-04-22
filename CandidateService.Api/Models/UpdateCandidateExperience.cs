namespace CandidateService.Api.Models
{
    public record UpdateCandidateExperience
    {
        public string? Id { get; init; }
        public string? Company { get; init; }
        public string? Position { get; init; }
        public string? Description { get; init; }
        public string? StartDate { get; init; }
        public string? EndDate { get; init; }
    }
}
