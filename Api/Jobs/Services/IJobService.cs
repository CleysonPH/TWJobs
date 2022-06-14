using TWJobs.Api.Common.Dtos;
using TWJobs.Api.Jobs.Dtos;
using TWJobs.Core.Repositories;

namespace TWJobs.Api.Jobs.Services;

public interface IJobService
{
    ICollection<JobSummaryResponse> FindAll();
    PagedResponse<JobSummaryResponse> FindAll(PaginationOptions options);
    JobDetailsResponse FindById(int id);
    JobDetailsResponse Create(JobRequest request);
    JobDetailsResponse UpdateById(int id, JobRequest request);
    void DeleteById(int id);
}