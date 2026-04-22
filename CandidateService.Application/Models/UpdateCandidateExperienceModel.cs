namespace CandidateService.Application.Models
{
    public record UpdateCandidateExperienceModel
    {
        private readonly string _id;
        private readonly string _company;
        private readonly string _position;
        private readonly DateOnly _startDate;

        public UpdateCandidateExperienceModel(
            string id,
            string company,
            string position,
            DateOnly startDate)
        {
            _id = id ?? throw new ArgumentNullException(nameof(id));
            _company = company ?? throw new ArgumentNullException(nameof(company));
            _position = position ?? throw new ArgumentNullException(nameof(position));
            _startDate = startDate;
        }

        public string Id => _id;
        public string Company => _company;
        public string Position => _position;
        public DateOnly StartDate => _startDate;
        public string? Description { get; init; }
        public DateOnly? EndDate { get; init; }
    }
}
