using CandidateService.Application.Models;
using CandidateService.Domain.Entities.ChildEntities;

namespace CandidateService.Application.Abstract_Services
{
    public interface ICandidateSkillService
    {
        Task AddCandidateSkillAsync(CandidateSkillModel candidateSkillModel);
        Task<ICollection<CandidateSkill>> GetCandidateSkillsAsync(string candidateId);
        Task<bool> UpdateCandidateSkillAsync(UpdateCandidateSkillModel candidateSkillModel);
        Task<bool> DeleteCandidateSkillAsync(string skillId);
    }
}
