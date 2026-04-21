using AutoMapper;

namespace CandidateService.Infrastructure.Mappings
{
    public class DomainCandiateExperienceMapping : Profile
    {
        public DomainCandiateExperienceMapping() 
        {
            CreateMap<Domain.Entities.ChildEntities.CandidateExperience, Entities.CandidateExperienceEntity>()
                .ConvertUsing(src => new Entities.CandidateExperienceEntity
                {
                    Id = src.Id,
                    CandidateId = src.CandidateId.Value,
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
