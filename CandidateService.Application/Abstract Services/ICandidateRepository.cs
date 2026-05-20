using CandidateService.Domain.Entities.Aggregates;

namespace CandidateService.Application.Abstract_Services
{
    public interface ICandidateRepository
    {
        Task AddCandidate(Candidate candidate);
        Task<Candidate?> GetCandidateById(Guid id);
        Task<IReadOnlyList<Candidate>> SearchCandidatesByName(string name);
        Task<IReadOnlyList<Candidate>> SearchCandidatesByDescription(string description);
    }
}
