namespace CandidateService.Domain.Entities.ChildEntities;

using CandidateService.Domain.ValueObjects;

public sealed class CandidateSkill
{
    public Guid Id { get; }
    public CandidateId CandidateId { get; }
    public string Name { get; private set; }
    public string? Level { get; private set; }
    public int YearsOfExperience { get; private set; }
    public DateTime CreatedAt { get; }

    private CandidateSkill(
        Guid id,
        CandidateId candidateId,
        string name,
        string? level,
        int yearsOfExperience,
        DateTime createdAt)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Skill id cannot be empty.", nameof(id));

        CandidateId = candidateId ?? throw new ArgumentNullException(nameof(candidateId));

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Skill name is required.", nameof(name));

        if (yearsOfExperience < 0)
            throw new ArgumentException("Years of experience cannot be negative.", nameof(yearsOfExperience));

        Id = id;
        Name = name.Trim();
        Level = Normalize(level);
        YearsOfExperience = yearsOfExperience;
        CreatedAt = createdAt;
    }

    public static CandidateSkill Create(
        CandidateId candidateId,
        string name,
        string? level,
        int yearsOfExperience)
    {
        return new CandidateSkill(
            Guid.NewGuid(),
            candidateId,
            name,
            level,
            yearsOfExperience,
            DateTime.UtcNow);
    }

    public void Update(string name, string? level, int yearsOfExperience)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Skill name is required.", nameof(name));

        if (yearsOfExperience < 0)
            throw new ArgumentException("Years of experience cannot be negative.", nameof(yearsOfExperience));

        Name = name.Trim();
        Level = Normalize(level);
        YearsOfExperience = yearsOfExperience;
    }

    private static string? Normalize(string? value)
    {
        return string.IsNullOrWhiteSpace(value) ? null : value.Trim();
    }
}
