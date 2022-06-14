using TWJobs.Core.Repositories.Candidates;
using TWJobs.Core.Repositories.JobApplications;
using TWJobs.Core.Repositories.Jobs;

namespace TWJobs.Core.Config;

public static class RepositoriesConfig
{
    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IJobRepository, JobRepository>();
        services.AddScoped<ICandidateRepository, CandidateRepository>();
        services.AddScoped<IJobApplicationRepository, JobApplicationRepository>();
    }
}