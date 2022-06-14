using TWJobs.Api.Candidates.Dtos;
using TWJobs.Api.Common.Dtos;
using TWJobs.Api.Jobs.Dtos;

namespace TWJobs.Api.JobApplications.Dtos;

public class JobApplicationDetailsResponse : ResourceResponse
{
    public int Id { get; set; }
    public JobDetailsResponse Job { get; set; } = null!;
    public CandiateDetailsResponse Candidate { get; set; } = null!;
}