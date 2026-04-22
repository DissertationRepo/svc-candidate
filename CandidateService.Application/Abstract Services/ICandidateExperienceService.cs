using CandidateService.Application.Models;
using CandidateService.Domain.Entities.ChildEntities;

namespace CandidateService.Application.Abstract_Services
{
    public interface ICandidateExperienceService
    {
        Task AddCandidateExperienceAsync(CandidateExperienceModel candidateExperienceModel);
        Task<ICollection<CandidateExperience>> GetCandidateExperiencesAsync(string candidateId);
        Task<bool> UpdateCandidateExperienceAsync(UpdateCandidateExperienceModel candidateExperienceModel);
        Task<bool> DeleteCandidateExperienceAsync(string experienceId);
    }
}
