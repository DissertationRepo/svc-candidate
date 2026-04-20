namespace CandidateService.Application.Models
{
    public record CandidateSkillModel
    {
        private string _candidateId;
        private string _name;
        private string _yearsOfExperience;

        public CandidateSkillModel(string candidateId, string name, string yearsOfExperience)
        {
            _candidateId = candidateId ?? throw new ArgumentNullException(nameof(candidateId) , "CandidateId is required.");
            _name = !string.IsNullOrEmpty(name) ? name : throw new ArgumentNullException(nameof(name), "Name is required.");
            _yearsOfExperience = int.TryParse(yearsOfExperience, out _) ? yearsOfExperience
                : throw new ArgumentException("Years of experience must be a valid integer.", nameof(yearsOfExperience));
        }
        public string CandidateId { get => _candidateId; }
        public string Name { get => _name; }    
        public string? Level { get; init; }
        public int YearsOfExperience { get => int.Parse(_yearsOfExperience); }
    }
}
