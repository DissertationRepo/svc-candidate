namespace CandidateService.Domain.ValueObjects;

public sealed record CandidateId
{
    public Guid Value { get; }

    public CandidateId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("CandidateId cannot be empty.", nameof(value));
        }

        Value = value;
    }

    public static CandidateId New() => new(Guid.NewGuid());

    public override string ToString() => Value.ToString();

    public static implicit operator Guid(CandidateId id) => id.Value;
}
