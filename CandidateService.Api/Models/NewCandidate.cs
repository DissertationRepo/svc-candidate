namespace CandidateService.Api.Models
{
    public record NewCandidate
    {
        public string? UserId { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? Email { get; init; }
        public string? PhoneNumber { get; init; }
        public string? Summary { get; init; }
        public string? Location { get; init; }

    }
}
