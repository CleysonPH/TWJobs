using System.Text.Json.Serialization;

namespace TWJobs.Api.Common.Dtos;

public class ResourceResponse
{
    [JsonPropertyName("_links")]
    public ICollection<LinkResponse> Links { get; set; } = new List<LinkResponse>();

    public void AddLink(LinkResponse link)
    {
        Links.Add(link);
    }

    public void AddLinks(params LinkResponse[] links)
    {
        foreach (var link in links)
        {
            Links.Add(link);
        }
    }

    public void AddLink(string href, string type, string rel)
    {
        Links.Add(new LinkResponse(href, type, rel));
    }

    public void AddLinkIf(bool condition, LinkResponse link)
    {
        if (condition)
        {
            Links.Add(link);
        }
    }
}