using TWJobs.Api.Candidates.Assemblers;
using TWJobs.Api.Candidates.Dtos;
using TWJobs.Api.Common.Assemblers;
using TWJobs.Api.JobApplications.Assemblers;
using TWJobs.Api.JobApplications.Dtos;
using TWJobs.Api.JobApplications.Mappers;
using TWJobs.Api.Jobs.Assemblers;
using TWJobs.Api.Jobs.Dtos;

namespace TWJobs.Core.Config;

public static class AssemblersConfig
{
    public static void RegisterAssemblers(this IServiceCollection services)
    {
        services.AddScoped<IAssembler<JobSummaryResponse>, JobSummaryAssembler>();
        services.AddScoped<IAssembler<JobDetailsResponse>, JobDetailsAssembler>();
        services.AddScoped<IAssembler<CandiateSummaryResponse>, CandidateSummaryAssembler>();
        services.AddScoped<IAssembler<CandiateDetailsResponse>, CandiadateDetailsAssembler>();
        services.AddScoped<IAssembler<JobApplicationSummaryResponse>, JobApplicationSummaryAssembler>();
        services.AddScoped<IAssembler<JobApplicationDetailsResponse>, JobApplicationDetailsAssembler>();
        services.AddScoped<IPagedAssembler<JobSummaryResponse>, JobSummaryPagedAssembler>();
    }
}