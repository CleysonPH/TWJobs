using TWJobs.Api.Candidates.Mappers;
using TWJobs.Api.JobApplications.Mappers;
using TWJobs.Api.Jobs.Mappers;

namespace TWJobs.Core.Config;

public static class MappersConfig
{
    public static void RegisterMappers(this IServiceCollection services)
    {
        services.AddScoped<IJobMapper, JobMapper>();
        services.AddScoped<ICandidateMapper, CandidateMapper>();
        services.AddScoped<IJobApplicationMapper, JobApplicationMapper>();
    }
}