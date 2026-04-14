using CandidateService.Application.Models;

namespace CandidateService.Application.Abstract_Services
{
    public interface ICandidateService
    {
        Task CreateCandidate(NewCandidateModel newCandidate);
    }
}
