using CandidateService.Domain.Entities.ChildEntities;

namespace CandidateService.Application.Abstract_Services
{
    public interface ICandidateExperienceRepository
    {
        Task AddExperienceAsync(CandidateExperience experience);
        Task<ICollection<CandidateExperience>> GetExperienceByIdAsync(Guid candidateId);
        Task<bool> UpdateExperienceAsync(
            Guid experienceId,
            string company,
            string position,
            string? description,
            DateOnly startDate,
            DateOnly? endDate,
            bool isCurrent);
        Task<bool> DeleteExperienceAsync(Guid experienceId);
    }
}
