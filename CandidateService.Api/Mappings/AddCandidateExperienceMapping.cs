using AutoMapper;
using CandidateService.Api.Models;

namespace CandidateService.Api.Mappings
{
    public class AddCandidateExperienceMapping : Profile
    {
        public AddCandidateExperienceMapping() 
        {
            CreateMap<Models.AddCandidateExperience, Application.Models.CandidateExperienceModel>()
                .ConvertUsing(src => CreateApplicationCandidateExperience(src));
        }

        private Application.Models.CandidateExperienceModel CreateApplicationCandidateExperience(AddCandidateExperience src)
        {
            if (!DateOnly.TryParse(src.StartDate, out var startDate))
                throw new ArgumentException("Invalid StartDate.");

            DateOnly? endDate = null;
            if (!string.IsNullOrWhiteSpace(src.EndDate))
            {
                if (!DateOnly.TryParse(src.EndDate, out var parsedEndDate))
                    throw new ArgumentException("Invalid EndDate.");

                endDate = parsedEndDate;
            }

            return new Application.Models.CandidateExperienceModel(
                src.CandidateId,
                src.Company,
                src.Position,
                startDate)
            {
                Description = src.Description,
                EndDate = endDate
            };
        }
    }
}
