using CandidateService.Application.Abstract_Services;
using CandidateService.Application.Models;
using CandidateService.Domain.Entities.ChildEntities;
using CandidateService.Domain.ValueObjects;

namespace CandidateService.Application.Services
{
    public class CandidateExperienceService : ICandidateExperienceService
    {
        private readonly ICandidateExperienceRepository _candidateExperienceRepository;

        public CandidateExperienceService(ICandidateExperienceRepository candidateExperienceRepository)
        {
            _candidateExperienceRepository = candidateExperienceRepository;
        }
        public async Task AddCandidateExperienceAsync(CandidateExperienceModel candidateExperienceModel)
        {
            var domainCandidateExperience = CandidateExperience.Create(
                new CandidateId(Guid.Parse(candidateExperienceModel.CandidateId)),
                candidateExperienceModel.Company,
                candidateExperienceModel.Position,
                candidateExperienceModel.Description,
                candidateExperienceModel.StartDate,
                candidateExperienceModel.EndDate
            );

            await _candidateExperienceRepository.AddExperienceAsync(domainCandidateExperience);

        }

        public async Task<ICollection<CandidateExperience>> GetCandidateExperiencesAsync(string candidateId)
        {
            return await _candidateExperienceRepository.GetExperienceByIdAsync(Guid.Parse(candidateId));
        }

        public async Task<bool> UpdateCandidateExperienceAsync(UpdateCandidateExperienceModel candidateExperienceModel)
        {
            return await _candidateExperienceRepository.UpdateExperienceAsync(
                Guid.Parse(candidateExperienceModel.Id),
                candidateExperienceModel.Company,
                candidateExperienceModel.Position,
                candidateExperienceModel.Description,
                candidateExperienceModel.StartDate,
                candidateExperienceModel.EndDate,
                candidateExperienceModel.EndDate is null);
        }

        public async Task<bool> DeleteCandidateExperienceAsync(string experienceId)
        {
            return await _candidateExperienceRepository.DeleteExperienceAsync(Guid.Parse(experienceId));
        }
    }
}
