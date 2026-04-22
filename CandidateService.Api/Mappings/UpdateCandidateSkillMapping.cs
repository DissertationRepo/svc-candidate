using AutoMapper;
using CandidateService.Api.Models;

namespace CandidateService.Api.Mappings
{
    public class UpdateCandidateSkillMapping : Profile
    {
        public UpdateCandidateSkillMapping()
        {
            CreateMap<UpdateCandidateSkill, Application.Models.UpdateCandidateSkillModel>()
                .ConvertUsing(src => new Application.Models.UpdateCandidateSkillModel(
                    src.Id,
                    src.Name,
                    src.YearsOfExperience)
                {
                    Level = src.Level
                });
        }
    }
}
