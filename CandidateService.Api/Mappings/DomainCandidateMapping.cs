using AutoMapper;

namespace CandidateService.Api.Mappings
{
    public class DomainCandidateMapping : Profile
    {
        public DomainCandidateMapping() 
        {
            CreateMap<Domain.Entities.Aggregates.Candidate, Application.Models.CandidateModel>()
                .ConvertUsing(src => ConvertToCandidateModel(src));
        }

        private Application.Models.CandidateModel ConvertToCandidateModel(Domain.Entities.Aggregates.Candidate candidate)
        {
            return new Application.Models.CandidateModel
            (
                candidate.UserId.Value.ToString(),
                candidate.FullName.FirstName,
                candidate.FullName.LastName,
                candidate.Email.Value,
                candidate.PhoneNumber.Value
            )
            {
                Location = candidate.Location?.Value,
                Summary = candidate.Summary
            };
        }
    }
}
