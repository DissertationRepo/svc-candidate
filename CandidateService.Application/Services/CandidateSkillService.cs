using CandidateService.Application.Abstract_Services;
using CandidateService.Application.Models;

namespace CandidateService.Application.Services
{
    public class CandidateSkillService : ICandidateSkillService
    {
        private readonly ICandidateSkillRepository _candidateSkillRepository;
        public CandidateSkillService(ICandidateSkillRepository candidateSkillRepository)
        {
            _candidateSkillRepository = candidateSkillRepository ?? throw new ArgumentNullException(nameof(candidateSkillRepository), "Candidate repository cannot be null.");
        }
        public async Task AddCandidateSkillAsync(CandidateSkillModel candidateSkillModel)
        {
            var domainCandidateSkill = Domain.Entities.ChildEntities.CandidateSkill.Create(
                new Domain.ValueObjects.CandidateId(Guid.Parse(candidateSkillModel.CandidateId)),
                candidateSkillModel.Name,
                candidateSkillModel.Level,
                candidateSkillModel.YearsOfExperience
            );

            await _candidateSkillRepository.AddCandidateSkillAsync(domainCandidateSkill);

        }
    }
}
