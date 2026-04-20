using CandidateService.Application.Models;

namespace CandidateService.Application.Abstract_Services
{
    public interface ICandidateSkillService
    {
        Task AddCandidateSkillAsync(CandidateSkillModel candidateSkillModel);
    }
}
