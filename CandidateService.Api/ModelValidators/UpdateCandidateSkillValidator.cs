using CandidateService.Api.Models;
using FluentValidation;

namespace CandidateService.Api.ModelValidators
{
    public class UpdateCandidateSkillValidator : AbstractValidator<UpdateCandidateSkill>
    {
        public UpdateCandidateSkillValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.")
                .Must(id => Guid.TryParse(id, out _)).WithMessage("Id must be a valid GUID.");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Skill name is required.")
                .MaximumLength(100).WithMessage("Skill name cannot exceed 100 characters.");
            RuleFor(x => x.Level)
                .MaximumLength(50).WithMessage("Skill level cannot exceed 50 characters.");
            RuleFor(x => x.YearsOfExperience)
                .NotEmpty().WithMessage("Years of experience is required.");
        }
    }
}
