namespace TWJobs.Api.Common.Dtos;

public class LinkResponse
{
    public string? Href { get; set; }
    public string Type { get; set; }
    public string Rel { get; set; }

    public LinkResponse(string rel, string type, string? href)
    {
        Rel = rel;
        Type = type;
        Href = href;
    }
}