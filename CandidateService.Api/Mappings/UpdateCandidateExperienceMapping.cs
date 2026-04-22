using AutoMapper;
using CandidateService.Api.Models;

namespace CandidateService.Api.Mappings
{
    public class UpdateCandidateExperienceMapping : Profile
    {
        public UpdateCandidateExperienceMapping()
        {
            CreateMap<UpdateCandidateExperience, Application.Models.UpdateCandidateExperienceModel>()
                .ConvertUsing(src => CreateApplicationCandidateExperience(src));
        }

        private Application.Models.UpdateCandidateExperienceModel CreateApplicationCandidateExperience(UpdateCandidateExperience src)
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

            return new Application.Models.UpdateCandidateExperienceModel(
                src.Id,
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
