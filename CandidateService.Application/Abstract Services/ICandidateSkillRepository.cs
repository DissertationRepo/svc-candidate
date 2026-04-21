using CandidateService.Domain.Entities.ChildEntities;

namespace CandidateService.Application.Abstract_Services
{
    public interface ICandidateSkillRepository
    {
        Task AddCandidateSkillAsync(CandidateSkill candidateSkill);
        Task<ICollection<CandidateSkill>> GetSkillsById(Guid candidateId);
    }
}
