using CandidateService.Application.Models;
using CandidateService.Domain.Entities.Aggregates;

namespace CandidateService.Application.Abstract_Services
{
    public interface ICandidateService
    {
        Task CreateCandidateAsync(CandidateModel newCandidate);
        Task<Candidate?> GetCandidateByIdAsync(Guid id);
        Task<IReadOnlyList<Candidate>> SearchCandidatesByNameAsync(string name);
        Task<IReadOnlyList<Candidate>> SearchCandidatesByDescriptionAsync(string description);
    }
}
