using TWJobs.Api.Candidates.Mappers;
using TWJobs.Api.JobApplications.Dtos;
using TWJobs.Api.Jobs.Mappers;
using TWJobs.Core.Models;

namespace TWJobs.Api.JobApplications.Mappers;

public class JobApplicationMapper : IJobApplicationMapper
{
    private readonly IJobMapper _jobMapper;
    private readonly ICandidateMapper _candidateMapper;

    public JobApplicationMapper(IJobMapper jobMapper, ICandidateMapper candidateMapper)
    {
        _jobMapper = jobMapper;
        _candidateMapper = candidateMapper;
    }

    public JobApplicationDetailsResponse ToDetailsResponse(JobApplication jobApplication)
    {
        return new JobApplicationDetailsResponse
        {
            Id = jobApplication.Id,
            Job = _jobMapper.ToDetailsResponse(jobApplication.Job),
            Candidate = _candidateMapper.ToDetailsResponse(jobApplication.Candidate)
        };
    }

    public JobApplication ToModel(JobApplicationRequest request)
    {
        return new JobApplication
        {
            JobId = request.JobId,
            CandidateId = request.CandidateId
        };
    }

    public JobApplicationSummaryResponse ToSummaryResponse(JobApplication jobApplication)
    {
        return new JobApplicationSummaryResponse
        {
            Id = jobApplication.Id,
            Job = _jobMapper.ToSummaryResponse(jobApplication.Job),
            Candidate = _candidateMapper.ToSummaryResponse(jobApplication.Candidate)
        };
    }
}