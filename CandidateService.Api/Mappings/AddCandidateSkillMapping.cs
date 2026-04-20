using AutoMapper;
using CandidateService.Api.Models;

namespace CandidateService.Api.Mappings
{
    public class AddCandidateSkillMapping : Profile
    {
        public AddCandidateSkillMapping()
        {
            CreateMap<Models.AddCandidateSkill, Application.Models.CandidateSkillModel>()
                .ConvertUsing(src => CreateCandidateSkillModel(src));

        }

        private Application.Models.CandidateSkillModel CreateCandidateSkillModel(AddCandidateSkill src)
        {
            return new Application.Models.CandidateSkillModel(
                candidateId: src.CandidateId,
                name: src.Name,
                yearsOfExperience: src.YearsOfExperience
            )
            {
                Level = src.Level
            };
        }
    }
}
