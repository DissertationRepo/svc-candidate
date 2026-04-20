namespace CandidateService.Infrastructure.Entities
{
    public class CandidateSkillEntity
    {
        public Guid Id { get; set; }
        public Guid CandidateId { get; set; }
        public string Name { get; set; }
        public string? Level { get; set; }
        public int YearsOfExperience { get; set; }
        public DateTime CreatedAt { get; set; }
        public CandidateEntity Candidate { get; set; }
    }
}
