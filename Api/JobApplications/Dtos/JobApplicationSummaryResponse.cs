using TWJobs.Api.Candidates.Dtos;
using TWJobs.Api.Common.Dtos;
using TWJobs.Api.Jobs.Dtos;

namespace TWJobs.Api.JobApplications.Mappers;

public class JobApplicationSummaryResponse : ResourceResponse
{
    public int Id { get; set; }
    public JobSummaryResponse Job { get; set; } = null!;
    public CandiateSummaryResponse Candidate { get; set; } = null!;
}