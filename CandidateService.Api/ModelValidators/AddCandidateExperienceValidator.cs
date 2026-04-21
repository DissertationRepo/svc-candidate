using CandidateService.Api.Models;
using FluentValidation;

namespace CandidateService.Api.ModelValidators
{
    public class AddCandidateExperienceValidator : AbstractValidator<AddCandidateExperience>
    {
        public AddCandidateExperienceValidator() 
        {
            RuleFor(x => x.CandidateId)
                .NotEmpty().WithMessage("CandidateId is required.")
                .Must(id => Guid.TryParse(id, out _)).WithMessage("CandidateId must be a valid GUID.");
            RuleFor(x => x.Company)
                .NotEmpty().WithMessage("Company is required.")
                .MaximumLength(30).WithMessage("Company cannot exceed 30 characters.");
            RuleFor(x => x.Position)
                .NotEmpty().WithMessage("Position is required.")
                .MaximumLength(30).WithMessage("Position cannot exceed 30 characters.");
            RuleFor(x => x.StartDate)
                .NotNull().WithMessage("StartDate is required.");
        }
    }
}
