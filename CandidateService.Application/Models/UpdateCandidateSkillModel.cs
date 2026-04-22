namespace CandidateService.Application.Models
{
    public record UpdateCandidateSkillModel
    {
        private readonly string _id;
        private readonly string _name;
        private readonly string _yearsOfExperience;

        public UpdateCandidateSkillModel(string id, string name, string yearsOfExperience)
        {
            _id = id ?? throw new ArgumentNullException(nameof(id), "Id is required.");
            _name = !string.IsNullOrEmpty(name) ? name : throw new ArgumentNullException(nameof(name), "Name is required.");
            _yearsOfExperience = int.TryParse(yearsOfExperience, out _)
                ? yearsOfExperience
                : throw new ArgumentException("Years of experience must be a valid integer.", nameof(yearsOfExperience));
        }

        public string Id => _id;
        public string Name => _name;
        public string? Level { get; init; }
        public int YearsOfExperience => int.Parse(_yearsOfExperience);
    }
}
