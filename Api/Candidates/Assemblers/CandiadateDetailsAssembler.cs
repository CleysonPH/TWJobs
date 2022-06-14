using TWJobs.Api.Candidates.Dtos;
using TWJobs.Api.Common.Assemblers;
using TWJobs.Api.Common.Dtos;

namespace TWJobs.Api.Candidates.Assemblers;

public class CandiadateDetailsAssembler : IAssembler<CandiateDetailsResponse>
{
    private readonly LinkGenerator _linkGenerator;

    public CandiadateDetailsAssembler(LinkGenerator linkGenerator)
    {
        _linkGenerator = linkGenerator;
    }

    public CandiateDetailsResponse ToResource(CandiateDetailsResponse resource, HttpContext httpContext)
    {
        var selfLink = new LinkResponse(
            "self",
            "GET",
            _linkGenerator.GetUriByName(httpContext, "FindCandidateById", new { id = resource.Id })
        );
        var updateLink = new LinkResponse(
            "update",
            "PUT",
            _linkGenerator.GetUriByName(httpContext, "UpdateCandidateById", new { id = resource.Id })
        );
        var deleteLink = new LinkResponse(
            "delete",
            "DELETE",
            _linkGenerator.GetUriByName(httpContext, "DeleteCandidateById", new { id = resource.Id })
        );
        resource.AddLinks(selfLink, updateLink, deleteLink);
        return resource;
    }
}