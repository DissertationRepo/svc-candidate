using AutoMapper;

namespace CandidateService.Api.Mappings
{
    public class ExperiencesResponseMapping : Profile
    {
        public ExperiencesResponseMapping() 
        {
            CreateMap<Domain.Entities.ChildEntities.CandidateExperience, Api.Models.ExperiencesResponse>()
                .ConvertUsing(src => new Models.ExperiencesResponse()
                {
                    Id = src.Id.ToString(),
                    CandidateId = src.CandidateId.Value.ToString(),
                    Company = src.Company,
                    Position = src.Position,
                    Description = src.Description,
                    StartDate = src.StartDate,
                    EndDate = src.EndDate,
                    IsCurrent = src.IsCurrent,
                    CreatedAt = src.CreatedAt,
                    UpdatedAt = src.UpdatedAt
                });
        }
    }
}
