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
            CreateMap<Models.NewCandidate, Application.Models.NewCandidateModel>()
                .ConstructUsing(src => CreateApplicationNewCandidateProfile(src));
        }

        private NewCandidateModel CreateApplicationNewCandidateProfile(NewCandidate src)
        {
            return new NewCandidateModel(
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
