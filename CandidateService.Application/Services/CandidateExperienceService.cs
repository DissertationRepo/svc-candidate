using CandidateService.Application.Abstract_Services;
using CandidateService.Application.Models;
using CandidateService.Domain.Entities.ChildEntities;
using CandidateService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateService.Application.Services
{
    public class CandidateExperienceService : ICandidateExperienceService
    {
        private readonly ICandidateExperienceRepository _candidateExperienceRepository;

        public CandidateExperienceService(ICandidateExperienceRepository candidateExperienceRepository)
        {
            _candidateExperienceRepository = candidateExperienceRepository;
        }
        public async Task AddCandidateExperience(CandidateExperienceModel candidateExperienceModel)
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
    }
}
