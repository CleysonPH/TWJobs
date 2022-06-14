using FluentValidation;
using TWJobs.Api.Jobs.Dtos;

namespace TWJobs.Api.Jobs.Validators;

public class JobRequestValidator : AbstractValidator<JobRequest>
{
    public JobRequestValidator()
    {
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Salary).GreaterThan(0);
        RuleFor(x => x.Requirements).NotEmpty();
    }
}