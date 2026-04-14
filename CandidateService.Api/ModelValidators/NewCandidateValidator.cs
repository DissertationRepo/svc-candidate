using CandidateService.Api.Models;
using FluentValidation;

namespace CandidateService.Api.ModelValidators
{
    public class NewCandidateValidator : AbstractValidator<NewCandidate>
    {
        public NewCandidateValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required.");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("FirstName is required.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName is required.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("PhoneNumber is required.");
            RuleFor(x => x.Location).NotEmpty().WithMessage("Location is required.");
        }
    }
}
