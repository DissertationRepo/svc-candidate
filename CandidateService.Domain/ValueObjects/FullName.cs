namespace CandidateService.Domain.ValueObjects;

public sealed record FullName
{
    public string FirstName { get; }
    public string LastName { get; }
    public string Value => $"{FirstName} {LastName}";

    public FullName(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new ArgumentException("First name is required.", nameof(firstName));
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentException("Last name is required.", nameof(lastName));
        }

        FirstName = firstName.Trim();
        LastName = lastName.Trim();
    }

    public override string ToString() => Value;
}
