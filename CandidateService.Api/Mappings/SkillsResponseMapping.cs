using AutoMapper;

namespace CandidateService.Api.Mappings
{
    public class SkillsResponseMapping : Profile
    {
        public SkillsResponseMapping() 
        {
            CreateMap<Domain.Entities.ChildEntities.CandidateSkill, Models.SkillsResponse>()
                .ConvertUsing(src => new Models.SkillsResponse()
                {
                    Id = src.Id.ToString(),
                    CandidateId = src.CandidateId.Value.ToString(),
                    Name = src.Name,
                    Level = src.Level,
                    YearsOfExperience = src.YearsOfExperience.ToString(),
                    CreatedAt = src.CreatedAt.ToString()
                });
        }
    }
}
