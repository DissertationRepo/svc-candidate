using CandidateService.Api.Models;
using FluentValidation;

namespace CandidateService.Api.ModelValidators
{
    public class AddCandidateSkillValidator : AbstractValidator<AddCandidateSkill>
    {
        public AddCandidateSkillValidator() 
        {
            RuleFor(x => x.CandidateId)
                .NotEmpty().WithMessage("CandidateId is required.");
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
