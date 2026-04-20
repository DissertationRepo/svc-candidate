namespace CandidateService.Api.Models
{
    public class AddCandidateSkill
    {
        public string? CandidateId { get; set; }
        public string? Name { get; set; } = null!;
        public string? Level { get; set; }
        public string? YearsOfExperience { get; set; }
    }
}
