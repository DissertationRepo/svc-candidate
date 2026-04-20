using AutoMapper;
using CandidateService.Api.Models;
using CandidateService.Application.Models;
using static System.Net.Mime.MediaTypeNames;

namespace CandidateService.Api.Mappings
{
    public class NewCandidateMapping : Profile
    {
        public NewCandidateMapping() 
        {
            CreateMap<Models.NewCandidate, Application.Models.CandidateModel>()
                .ConstructUsing(src => CreateApplicationNewCandidateProfile(src));
        }

        private CandidateModel CreateApplicationNewCandidateProfile(NewCandidate src)
        {
            return new CandidateModel(
                userId: src.UserId,
                firstName: src.FirstName,
                lastName: src.LastName,
                email: src.Email,
                phoneNumber: src.PhoneNumber
            )
            {
                Summary = src.Summary,
                Location = src.Location
            };
        }
    }
}
