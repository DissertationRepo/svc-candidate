using CandidateService.Application.Models;

namespace CandidateService.Application.Abstract_Services
{
    public interface ICandidateExperienceService
    {
        Task AddCandidateExperience(CandidateExperienceModel candidateExperienceModel);
    }
}
