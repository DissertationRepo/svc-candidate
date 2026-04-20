namespace CandidateService.Application.Models
{
    public record CandidateModel 
    {
        private string _userId;
        private string _lastName;
        private string _firstName;
        private string _email;
        private string _phoneNumber;

        public CandidateModel(string userId, string firstName, string lastName, string email, string phoneNumber)
        {
            _userId = userId ?? throw new ArgumentNullException(nameof(UserId));
            _firstName = firstName ?? throw new ArgumentNullException(nameof(FirstName));
            _lastName = lastName ?? throw new ArgumentNullException(nameof(LastName));
            _email = email ?? throw new ArgumentNullException(nameof(Email));
            _phoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(PhoneNumber));
        }
        public string? UserId { get => _userId; }
        public string? FirstName { get => _firstName; }
        public string? LastName { get => _lastName; }
        public string? Email { get => _email; }
        public string? PhoneNumber { get => _phoneNumber; }
        public string? Summary { get; init; }
        public string? Location { get; init; }
    }
}
