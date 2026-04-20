using AutoMapper;
using CandidateService.Domain.Entities.Aggregates;
using CandidateService.Infrastructure.Entities;

namespace CandidateService.Infrastructure.Mappings
{
    public class DomainCandidateMapping : Profile
    {
        public DomainCandidateMapping()
        {
            CreateMap<Candidate, CandidateEntity>()
                .ConvertUsing(src => CreateInfrastructureCandidate(src));
        }

        private CandidateEntity CreateInfrastructureCandidate(Candidate src)
        {
            return new CandidateEntity
            {
                Id = src.Id.Value,
                UserId = src.UserId.Value,
                FirstName = src.FullName.FirstName.ToString(),
                LastName = src.FullName.LastName.ToString(),
                Email = src.Email.Value,
                Phone = src.PhoneNumber.ToString(),
                Summary = src.Summary?.ToString(),
                Location = src.Location?.ToString(),
                CreatedAt = src.CreatedAt,
                UpdatedAt = src.UpdatedAt
            };
        }
    }
}
