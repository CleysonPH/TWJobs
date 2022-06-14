using TWJobs.Api.Common.Dtos;

namespace TWJobs.Api.Common.Assemblers;

public interface IAssembler<T> where T : ResourceResponse
{
    T ToResource(T resource, HttpContext httpContext);
    ICollection<T> ToResourceCollection(ICollection<T> resources, HttpContext httpContext)
    {
        return resources.Select(r => ToResource(r, httpContext)).ToList();
    }
}