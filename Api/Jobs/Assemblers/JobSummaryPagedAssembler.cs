using TWJobs.Api.Common.Assemblers;
using TWJobs.Api.Common.Dtos;
using TWJobs.Api.Jobs.Dtos;

namespace TWJobs.Api.Jobs.Assemblers;

public class JobSummaryPagedAssembler : IPagedAssembler<JobSummaryResponse>
{
    private readonly LinkGenerator _linkGenerator;
    private readonly IAssembler<JobSummaryResponse> _jobSummaryAssembler;

    public JobSummaryPagedAssembler(
        IAssembler<JobSummaryResponse> jobSummaryAssembler,
        LinkGenerator linkGenerator)
    {
        _jobSummaryAssembler = jobSummaryAssembler;
        _linkGenerator = linkGenerator;
    }

    public PagedResponse<JobSummaryResponse> ToPagedResource(PagedResponse<JobSummaryResponse> response, HttpContext context)
    {
        response.Items = _jobSummaryAssembler.ToResourceCollection(response.Items, context);

        var firstPageLink = new LinkResponse(
            "firstPage",
            "GET",
            _linkGenerator.GetUriByName(context, "FindAllJobs", new { pageNumber = response.FirstPage, pageSize = response.PageSize })
        );
        var lastPageLink = new LinkResponse(
            "lastPage",
            "GET",
            _linkGenerator.GetUriByName(context, "FindAllJobs", new { pageNumber = response.LastPage, pageSize = response.PageSize })
        );
        var nextPageLink = new LinkResponse(
            "nextPage",
            "GET",
            _linkGenerator.GetUriByName(context, "FindAllJobs", new { pageNumber = response.PageNumber + 1, pageSize = response.PageSize })
        );
        var previousPageLink = new LinkResponse(
            "previousPage",
            "GET",
            _linkGenerator.GetUriByName(context, "FindAllJobs", new { pageNumber = response.PageNumber - 1, pageSize = response.PageSize })
        );

        response.AddLinks(firstPageLink, lastPageLink);
        response.AddLinkIf(response.HasNextPage, nextPageLink);
        response.AddLinkIf(response.HasPreviousPage, previousPageLink);

        return response;
    }
}