namespace CandidateService.Application.Models
{
    public record CandidateExperienceModel
    {
        private readonly string _candidateId;
        private readonly string _company;
        private readonly string _position;
        private readonly DateOnly _startDate;

        public CandidateExperienceModel(
            string candidateId,
            string company,
            string position,
            DateOnly startDate)
        {
            _candidateId = candidateId ?? throw new ArgumentNullException(nameof(candidateId));
            _company = company ?? throw new ArgumentNullException(nameof(company));
            _position = position ?? throw new ArgumentNullException(nameof(position));
            _startDate = startDate;
        }

        public string CandidateId { get => _candidateId; }
        public string Company { get => _company; }
        public string Position { get => _position; }
        public DateOnly StartDate { get => _startDate; }
        public string? Description { get; init; }
        public DateOnly? EndDate { get; init; }
    }
}
