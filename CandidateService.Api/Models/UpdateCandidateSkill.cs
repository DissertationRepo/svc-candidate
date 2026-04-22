namespace CandidateService.Api.Models
{
    public class UpdateCandidateSkill
    {
        public string? Id { get; set; }
        public string? Name { get; set; } = null!;
        public string? Level { get; set; }
        public string? YearsOfExperience { get; set; }
    }
}
