using CandidateService.Domain.Entities.ChildEntities;

namespace CandidateService.Application.Abstract_Services
{
    public interface ICandidateExperienceRepository
    {
        Task AddExperienceAsync(CandidateExperience experience);
        Task<ICollection<CandidateExperience>> GetExperienceByIdAsync(Guid candidateId);
    }
}
