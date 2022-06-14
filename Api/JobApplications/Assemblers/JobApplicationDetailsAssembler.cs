using TWJobs.Api.Common.Assemblers;
using TWJobs.Api.Common.Dtos;
using TWJobs.Api.JobApplications.Dtos;
using TWJobs.Api.Jobs.Dtos;
using TWJobs.Api.Candidates.Dtos;

namespace TWJobs.Api.JobApplications.Assemblers;

public class JobApplicationDetailsAssembler : IAssembler<JobApplicationDetailsResponse>
{
    private readonly LinkGenerator _linkGenerator;
    private readonly IAssembler<JobDetailsResponse> _jobDetailsAssembler;
    private readonly IAssembler<CandiateDetailsResponse> _candidateDetailsAssembler;

    public JobApplicationDetailsAssembler(
        LinkGenerator linkGenerator,
        IAssembler<JobDetailsResponse> jobDetailsAssembler,
        IAssembler<CandiateDetailsResponse> candidateDetailsAssembler)
    {
        _linkGenerator = linkGenerator;
        _jobDetailsAssembler = jobDetailsAssembler;
        _candidateDetailsAssembler = candidateDetailsAssembler;
    }

    public JobApplicationDetailsResponse ToResource(JobApplicationDetailsResponse resource, HttpContext httpContext)
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
        resource.Job = _jobDetailsAssembler.ToResource(resource.Job, httpContext);
        resource.Candidate = _candidateDetailsAssembler.ToResource(resource.Candidate, httpContext);
        resource.AddLinks(selfLink, deleteLink);
        return resource;
    }
}