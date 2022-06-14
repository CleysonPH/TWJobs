using TWJobs.Api.Candidates.Services;
using TWJobs.Api.JobApplications.Services;
using TWJobs.Api.Jobs.Services;

namespace TWJobs.Core.Config;

public static class ServicesConfig
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IJobService, JobService>();
        services.AddScoped<ICandidateService, CandidateService>();
        services.AddScoped<IJobApplicationService, JobApplicationService>();
    }
}