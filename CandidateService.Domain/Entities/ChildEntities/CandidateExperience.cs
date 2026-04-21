namespace CandidateService.Domain.Entities.ChildEntities;

using CandidateService.Domain.ValueObjects;

public sealed class CandidateExperience
{
    public Guid Id { get; }
    public CandidateId CandidateId { get; }
    public string Company { get; private set; }
    public string Position { get; private set; }
    public string? Description { get; private set; }
    public DateOnly StartDate { get; private set; }
    public DateOnly? EndDate { get; private set; }
    public bool IsCurrent { get; private set; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; private set; }

    private CandidateExperience(
        Guid id,
        CandidateId candidateId,
        string company,
        string position,
        string? description,
        DateOnly startDate,
        DateOnly? endDate,
        bool isCurrent,
        DateTime createdAt,
        DateTime updatedAt)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Experience id cannot be empty.", nameof(id));

        CandidateId = candidateId ?? throw new ArgumentNullException(nameof(candidateId));

        if (string.IsNullOrWhiteSpace(company))
            throw new ArgumentException("Company is required.", nameof(company));

        if (string.IsNullOrWhiteSpace(position))
            throw new ArgumentException("Position is required.", nameof(position));

        if (!isCurrent && endDate is null)
            throw new ArgumentException("End date is required for past experiences.", nameof(endDate));

        if (endDate is not null && endDate < startDate)
            throw new ArgumentException("End date cannot be earlier than start date.", nameof(endDate));

        Id = id;
        Company = company.Trim();
        Position = position.Trim();
        Description = Normalize(description);
        StartDate = startDate;
        EndDate = isCurrent ? null : endDate;
        IsCurrent = isCurrent;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static CandidateExperience Create(
        CandidateId candidateId,
        string company,
        string position,
        string? description,
        DateOnly startDate,
        DateOnly? endDate)
    {
        var now = DateTime.UtcNow;

        return new CandidateExperience(
            Guid.NewGuid(),
            candidateId,
            company,
            position,
            description,
            startDate,
            endDate,
            isCurrent: endDate is null,
            now,
            now);
    }

    public void Update(
        string company,
        string position,
        string? description,
        DateOnly startDate,
        DateOnly? endDate,
        bool isCurrent)
    {
        if (string.IsNullOrWhiteSpace(company))
            throw new ArgumentException("Company is required.", nameof(company));

        if (string.IsNullOrWhiteSpace(position))
            throw new ArgumentException("Position is required.", nameof(position));

        if (!isCurrent && endDate is null)
            throw new ArgumentException("End date is required for past experiences.", nameof(endDate));

        if (endDate is not null && endDate < startDate)
            throw new ArgumentException("End date cannot be earlier than start date.", nameof(endDate));

        Company = company.Trim();
        Position = position.Trim();
        Description = Normalize(description);
        StartDate = startDate;
        EndDate = isCurrent ? null : endDate;
        IsCurrent = isCurrent;
        UpdatedAt = DateTime.UtcNow;
    }

    public static CandidateExperience Load(
        Guid id,
        CandidateId candidateId,
        string company,
        string position,
        string? description,
        DateOnly startDate,
        DateOnly? endDate,
        bool isCurrent,
        DateTime createdAt,
        DateTime updatedAt)
    {
        return new CandidateExperience(
            id,
            candidateId,
            company,
            position,
            description,
            startDate,
            endDate,
            isCurrent,
            createdAt,
            updatedAt);
    }

    private static string? Normalize(string? value)
    {
        return string.IsNullOrWhiteSpace(value) ? null : value.Trim();
    }
}
