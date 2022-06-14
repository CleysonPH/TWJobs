using TWJobs.Api.JobApplications.Dtos;
using TWJobs.Api.JobApplications.Mappers;

namespace TWJobs.Api.JobApplications.Services;

public interface IJobApplicationService
{
    JobApplicationDetailsResponse Create(JobApplicationRequest request);
    ICollection<JobApplicationSummaryResponse> FindAll();
    JobApplicationDetailsResponse FindById(int id);
    void DeleteById(int id);
}