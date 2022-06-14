using TWJobs.Api.Common.Assemblers;
using TWJobs.Api.Common.Dtos;
using TWJobs.Api.Jobs.Dtos;

namespace TWJobs.Api.Jobs.Assemblers;

public class JobSummaryAssembler : IAssembler<JobSummaryResponse>
{
    private readonly LinkGenerator _linkGenerator;

    public JobSummaryAssembler(LinkGenerator linkGenerator)
    {
        _linkGenerator = linkGenerator;
    }

    public JobSummaryResponse ToResource(JobSummaryResponse resource, HttpContext httpContext)
    {
        var selfLink = new LinkResponse(
            "self",
            "GET",
            _linkGenerator.GetUriByName(httpContext, "FindJobById", new { id = resource.Id })
        );
        var updateLink = new LinkResponse(
            "update",
            "PUT",
            _linkGenerator.GetUriByName(httpContext, "UpdateJobById", new { id = resource.Id })
        );
        var deleteLink = new LinkResponse(
            "delete",
            "DELETE",
            _linkGenerator.GetUriByName(httpContext, "DeleteJobById", new { id = resource.Id })
        );
        resource.AddLinks(selfLink, updateLink, deleteLink);
        return resource;
    }
}