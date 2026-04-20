using AutoMapper;
using CandidateService.Domain.Entities.ChildEntities;
using CandidateService.Infrastructure.Entities;

namespace CandidateService.Infrastructure.Mappings
{
    public class DomainCandidateSkillMapping : Profile
    {
        public DomainCandidateSkillMapping() 
        {
            CreateMap<Domain.Entities.ChildEntities.CandidateSkill, Infrastructure.Entities.CandidateSkillEntity>()
                .ConstructUsing(src => CreateCandidateSkillEntity(src));
        }

        private CandidateSkillEntity CreateCandidateSkillEntity(CandidateSkill src)
        {
            return new CandidateSkillEntity
            {
                Id = src.Id,
                CandidateId = src.CandidateId,
                Name = src.Name,
                Level = src.Level,
                YearsOfExperience = src.YearsOfExperience,
                CreatedAt = src.CreatedAt
            };
        }
    }
}
