using TWJobs.Api.Common.Dtos;

namespace TWJobs.Api.Common.Assemblers;

public interface IPagedAssembler<R> where R : ResourceResponse
{
    PagedResponse<R> ToPagedResource(PagedResponse<R> response, HttpContext context);
}