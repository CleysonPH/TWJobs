using FluentValidation;
using TWJobs.Api.Candidates.Dtos;
using TWJobs.Api.Candidates.Validators;
using TWJobs.Api.JobApplications.Dtos;
using TWJobs.Api.JobApplications.Validators;
using TWJobs.Api.Jobs.Dtos;
using TWJobs.Api.Jobs.Validators;

namespace TWJobs.Core.Config;

public static class ValidatorsConfig
{
    public static void RegisterValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<JobRequest>, JobRequestValidator>();
        services.AddScoped<IValidator<CandidateRequest>, CandidateRequestValidator>();
        services.AddScoped<IValidator<JobApplicationRequest>, JobApplicationRequestValidator>();
    }
}