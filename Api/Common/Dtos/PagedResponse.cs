using System.Text.Json.Serialization;

namespace TWJobs.Api.Common.Dtos;

public class PagedResponse<R> : ResourceResponse
{
    public ICollection<R> Items { get; set; } = new List<R>();

    [JsonIgnore]
    public int PageNumber { get; set; }

    [JsonIgnore]
    public int PageSize { get; set; }

    [JsonIgnore]
    public int FirstPage { get; set; }

    [JsonIgnore]
    public int LastPage { get; set; }

    [JsonIgnore]
    public bool HasPreviousPage { get; set; }

    [JsonIgnore]
    public bool HasNextPage { get; set; }
}