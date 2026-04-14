// CandidateService.Domain/Entities/Aggregates/Candidate.cs
using CandidateService.Domain.ValueObjects;

namespace CandidateService.Domain.Entities.Aggregates;

public sealed class Candidate
{
    public CandidateId Id { get; }
    public UserId UserId { get; }
    public FullName FullName { get; private set; }
    public PhoneNumber? PhoneNumber { get; private set; }
    public string? Summary { get; private set; }
    public Location? Location { get; private set; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; private set; }

    public Candidate(
        CandidateId id,
        UserId userId,
        FullName fullName,
        PhoneNumber? phoneNumber,
        string? summary,
        Location? location)
    {
        Id = id;
        UserId = userId;
        FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
        PhoneNumber = phoneNumber;
        Summary = NormalizeSummary(summary);
        Location = location;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }

    public static Candidate Create(
        UserId userId,
        string firstName,
        string lastName,
        string? phoneNumber,
        string? summary,
        string? location)
    {
        return new Candidate(
            CandidateId.New(),
            userId,
            new FullName(firstName, lastName),
            string.IsNullOrWhiteSpace(phoneNumber) ? null : new PhoneNumber(phoneNumber),
            summary,
            string.IsNullOrWhiteSpace(location) ? null : new Location(location));
    }

    public void UpdateProfile(
        FullName fullName,
        PhoneNumber? phoneNumber,
        string? summary,
        Location? location)
    {
        FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
        PhoneNumber = phoneNumber;
        Summary = NormalizeSummary(summary);
        Location = location;
        UpdatedAt = DateTime.UtcNow;
    }

    private static string? NormalizeSummary(string? summary)
    {
        return string.IsNullOrWhiteSpace(summary) ? null : summary.Trim();
    }
}
