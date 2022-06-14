using TWJobs.Api.Candidates.Dtos;
using TWJobs.Api.Common.Assemblers;
using TWJobs.Api.Common.Dtos;
using TWJobs.Api.JobApplications.Mappers;
using TWJobs.Api.Jobs.Dtos;

namespace TWJobs.Api.JobApplications.Assemblers;

public class JobApplicationSummaryAssembler : IAssembler<JobApplicationSummaryResponse>
{
    private readonly LinkGenerator _linkGenerator;
    private readonly IAssembler<JobSummaryResponse> _jobSummaryAssembler;
    private readonly IAssembler<CandiateSummaryResponse> _candidateSummaryAssembler;

    public JobApplicationSummaryAssembler(
        LinkGenerator linkGenerator,
        IAssembler<JobSummaryResponse> jobSummaryAssembler,
        IAssembler<CandiateSummaryResponse> candidateSummaryAssembler)
    {
        _linkGenerator = linkGenerator;
        _jobSummaryAssembler = jobSummaryAssembler;
        _candidateSummaryAssembler = candidateSummaryAssembler;
    }

    public JobApplicationSummaryResponse ToResource(JobApplicationSummaryResponse resource, HttpContext httpContext)
    {
        var selfLink = new LinkResponse(
            "self",
            "GET",
            _linkGenerator.GetUriByName(httpContext, "FindJobApplicationById", new { id = resource.Id })
        );
        var deleteLink = new LinkResponse(
            "delete",
            "DELETE",
            _linkGenerator.GetUriByName(httpContext, "DeleteJobApplicationById", new { id = resource.Id })
        );
        resource.Job = _jobSummaryAssembler.ToResource(resource.Job, httpContext);
        resource.Candidate = _candidateSummaryAssembler.ToResource(resource.Candidate, httpContext);
        resource.AddLinks(selfLink, deleteLink);
        return resource;
    }
}