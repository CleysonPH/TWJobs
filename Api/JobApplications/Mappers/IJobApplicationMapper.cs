using TWJobs.Api.JobApplications.Dtos;
using TWJobs.Core.Models;

namespace TWJobs.Api.JobApplications.Mappers;

public interface IJobApplicationMapper
{
    JobApplication ToModel(JobApplicationRequest request);
    JobApplicationDetailsResponse ToDetailsResponse(JobApplication jobApplication);
    JobApplicationSummaryResponse ToSummaryResponse(JobApplication jobApplication);
}