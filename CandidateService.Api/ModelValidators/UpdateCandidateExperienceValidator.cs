using CandidateService.Api.Models;
using FluentValidation;

namespace CandidateService.Api.ModelValidators
{
    public class UpdateCandidateExperienceValidator : AbstractValidator<UpdateCandidateExperience>
    {
        public UpdateCandidateExperienceValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.")
                .Must(id => Guid.TryParse(id, out _)).WithMessage("Id must be a valid GUID.");
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
