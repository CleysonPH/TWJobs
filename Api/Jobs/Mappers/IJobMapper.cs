using TWJobs.Api.Common.Dtos;
using TWJobs.Api.Jobs.Dtos;
using TWJobs.Core.Models;
using TWJobs.Core.Repositories;

namespace TWJobs.Api.Jobs.Mappers;

public interface IJobMapper
{
    JobSummaryResponse ToSummaryResponse(Job job);
    JobDetailsResponse ToDetailsResponse(Job job);
    Job ToModel(JobRequest request);
    PagedResponse<JobSummaryResponse> ToPagedSummaryResponse(PagedResult<Job> pagedResult);
}