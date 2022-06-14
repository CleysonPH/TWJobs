using FluentValidation;
using TWJobs.Api.Candidates.Dtos;
using TWJobs.Core.Utils;

namespace TWJobs.Api.Candidates.Validators;

public class CandidateRequestValidator : AbstractValidator<CandidateRequest>
{
    public CandidateRequestValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Email).NotEmpty().EmailAddress();
        RuleFor(c => c.BirthDate)
            .NotEmpty()
            .Must(b => b.GetAge() >= 18).WithMessage("deve ter pelo menos 18 anos");
    }
}